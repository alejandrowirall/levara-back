using Levara.Application.Plaid.ReconcileTransaction.Models;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Microsoft.Extensions.Logging;

namespace Levara.Application.Plaid.ReconcileTransaction.Services;

public class LevelConfig
{
    public required Func<PlaidTransaction, Task<List<ChargeCandidate>>> BuildCandidatesAsync { get; init; }
    public required Func<ChargeCandidate, HashSet<int>, HashSet<int>, bool> IsAvailable { get; init; }
    public required Action<ChargeCandidate, HashSet<int>, HashSet<int>> ReserveCandidate { get; init; }
    public bool IsSplitLevel { get; init; }
    public HashSet<int>? PropertyIdSet { get; init; }
}

public class ReconciliationLevelProcessor
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPlaidRepository _plaidRepository;
    private readonly IPlaidReconciliationRepository _reconciliationRepository;
    private readonly IRecurringChargeRepository _recurringChargeRepository;
    private readonly ReconciliationScoreCalculator _scoreCalculator;
    private readonly ReconciliationPaymentApplier _paymentApplier;
    private readonly ILogger<ReconciliationLevelProcessor> _logger;

    public ReconciliationLevelProcessor(
        IUnitOfWork unitOfWork,
        IPlaidRepository plaidRepository,
        IPlaidReconciliationRepository reconciliationRepository,
        IRecurringChargeRepository recurringChargeRepository,
        ReconciliationScoreCalculator scoreCalculator,
        ReconciliationPaymentApplier paymentApplier,
        ILogger<ReconciliationLevelProcessor> logger)
    {
        _unitOfWork = unitOfWork;
        _plaidRepository = plaidRepository;
        _reconciliationRepository = reconciliationRepository;
        _recurringChargeRepository = recurringChargeRepository;
        _scoreCalculator = scoreCalculator;
        _paymentApplier = paymentApplier;
        _logger = logger;
    }

    public async Task ProcessLevelAsync(
        List<PlaidTransaction> pendingTransactions,
        LevelConfig config)
    {
        var usedTransactionIds = new HashSet<int>();
        var usedRcIds = new HashSet<int>();

        for (int pass = 1; pass <= ReconciliationScoreCalculator.MAX_RECONCILIATION_PASSES; pass++)
        {
            bool hasChanges = false;

            foreach (var plaidTx in pendingTransactions)
            {
                if (plaidTx.Status == PlaidTransactionStatus.AutoReconciled)
                    continue;
                if (plaidTx.Status == PlaidTransactionStatus.NoMatch && pass > 1)
                    continue;

                try
                {
                    await _unitOfWork.ExecuteAsTransactionAsync(async () =>
                    {
                        var allCandidates = await config.BuildCandidatesAsync(plaidTx);

                        var available = allCandidates
                            .Where(c => config.IsAvailable(c, usedTransactionIds, usedRcIds))
                            .ToList();

                        var scored = _scoreCalculator.ScoreAndFilter(plaidTx, available);

                        var best = _scoreCalculator.SelectAutoApplyCandidate(scored);

                        if (best == null) return;

                        if (config.IsSplitLevel && best.Candidate.IsSpliteable)
                        {
                            hasChanges = await ProcessSplitCandidateAsync(
                                plaidTx, best, config.PropertyIdSet!);
                        }
                        else
                        {
                            hasChanges = await ProcessSingleCandidateAsync(plaidTx, best);
                        }

                        if (hasChanges)
                        {
                            config.ReserveCandidate(best.Candidate, usedTransactionIds, usedRcIds);
                        }
                    });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing PlaidTx {Id} in level", plaidTx.Id);
                    plaidTx.Status = PlaidTransactionStatus.Error;
                    await _unitOfWork.SaveChangesAsync();
                }
            }

            if (!hasChanges) break;
        }
    }

    public async Task ProcessFinalPassAsync(
        List<PlaidTransaction> pendingTransactions,
        Func<PlaidTransaction, Task<List<ChargeCandidate>>> buildAllCandidatesAsync)
    {
        var needReviewTransactionIds = new HashSet<int>();

        foreach (var plaidTx in pendingTransactions)
        {
            if (plaidTx.Status == PlaidTransactionStatus.AutoReconciled)
                continue;

            try
            {
                await _unitOfWork.ExecuteAsTransactionAsync(async () =>
                {
                    var allCandidates = await buildAllCandidatesAsync(plaidTx);

                    // Filtrar candidatos ya asignados a NeedReview en esta ejecución
                    var available = allCandidates
                        .Where(c => !c.TransactionId.HasValue ||
                                    !needReviewTransactionIds.Contains(c.TransactionId.Value))
                        .ToList();

                    var scored = _scoreCalculator.ScoreAndFilter(plaidTx, available);

                    if (scored.Any())
                    {
                        var best = _scoreCalculator.SelectAutoApplyCandidate(scored);

                        if (best != null)
                        {
                            await ProcessSingleCandidateAsync(plaidTx, best);
                        }
                        else
                        {
                            var topCandidates = _scoreCalculator.TakeTop5WithTies(scored);

                            var reconciliations = topCandidates
                                .Select(sc =>
                                {
                                    var r = _scoreCalculator.CreatePlaidReconciliation(plaidTx, sc);
                                    r.Status = PlaidReconciliationStatus.Pending;
                                    return r;
                                })
                                .ToList();

                            await _reconciliationRepository.AddAsync(reconciliations);

                            // Deduplicación activa
                            foreach (var sc in topCandidates)
                            {
                                if (sc.Candidate.TransactionId.HasValue)
                                    needReviewTransactionIds.Add(sc.Candidate.TransactionId.Value);
                            }

                            plaidTx.Status = PlaidTransactionStatus.NeedReview;
                            _plaidRepository.Update(plaidTx);
                        }
                    }
                    else
                    {
                        plaidTx.Status = PlaidTransactionStatus.NoMatch;
                        _plaidRepository.Update(plaidTx);
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in final pass for PlaidTx {Id}", plaidTx.Id);
                plaidTx.Status = PlaidTransactionStatus.Error;
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }

    public async Task ProcessEquitableDistributionAsync(
        List<PlaidTransaction> pendingTransactions,
        List<List<RecurringCharge>> rcGroups,
        Func<RecurringCharge, PlaidTransaction, Task<ChargeCandidate>> resolveCandidateAsync)
    {
        foreach (var rcGroup in rcGroups)
        {
            if (rcGroup.Count < 2) continue;

            var orderedProperties = rcGroup.OrderBy(rc => rc.PropertyId).ToList();
            if (!orderedProperties[0].Amount.HasValue) continue;
            var groupAmount = Math.Abs(orderedProperties[0].Amount!.Value);

            var matchingTxs = pendingTransactions
                .Where(tx => tx.Status != PlaidTransactionStatus.AutoReconciled)
                .Where(tx => Math.Abs(tx.Amount) == groupAmount);

            var byMonth = matchingTxs
                .GroupBy(tx => (tx.Date.Year, tx.Date.Month))
                .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month);

            foreach (var monthGroup in byMonth)
            {
                var monthTxs = monthGroup.OrderBy(tx => tx.Date).ToList();
                var pairCount = Math.Min(monthTxs.Count, orderedProperties.Count);

                for (int i = 0; i < pairCount; i++)
                {
                    var plaidTx = monthTxs[i];
                    var rc = orderedProperties[i];

                    var candidate = await resolveCandidateAsync(rc, plaidTx);

                    _scoreCalculator.CalculateMatchScore(plaidTx, candidate, out var details);
                    var scored = new ScoredCandidate
                    {
                        Candidate = candidate,
                        Score = details.TagScore + details.AmountScore,
                        Details = details
                    };

                    try
                    {
                        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
                            await ProcessSingleCandidateAsync(plaidTx, scored));
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error in equitable distribution for PlaidTx {Id}", plaidTx.Id);
                        plaidTx.Status = PlaidTransactionStatus.Error;
                        await _unitOfWork.SaveChangesAsync();
                    }
                }
            }
        }
    }

    private async Task<bool> ProcessSingleCandidateAsync(
        PlaidTransaction plaidTx,
        ScoredCandidate best)
    {
        var reconciliation = _scoreCalculator.CreatePlaidReconciliation(plaidTx, best);
        reconciliation.Status = PlaidReconciliationStatus.AutoApplied;
        await _reconciliationRepository.AddAsync(reconciliation);

        var success = await _paymentApplier.ApplyAsync(reconciliation, best.Candidate, plaidTx);

        if (success)
        {
            plaidTx.Status = PlaidTransactionStatus.AutoReconciled;
            _plaidRepository.Update(plaidTx);
        }
        else
        {
            _reconciliationRepository.Delete(reconciliation);
            await _unitOfWork.SaveChangesAsync();
        }

        return success;
    }

    private async Task<bool> ProcessSplitCandidateAsync(
        PlaidTransaction plaidTx,
        ScoredCandidate best,
        HashSet<int> propertyIdSet)
    {
        if (propertyIdSet.Count == 0) return false;

        var sourceRc = best.Candidate.SourceRecurringCharge;
        var propertyList = propertyIdSet.ToList();

        // Snapshot del estado pre-split. Las PaymentServices validan que la Plaid Tx
        // esté en un estado "pre-conciliación" (Created/NeedReview/NoMatch/Error) y la
        // mutan a Reconciled en cada invocación. Para N splits necesitamos restaurar
        // ese estado antes de cada iteración; de lo contrario solo la primera pasa.
        var originalStatus = plaidTx.Status;

        // Redondeo a 2 decimales; el residuo queda en la última propiedad para cuadrar al total.
        decimal baseSplit = Math.Round(plaidTx.Amount / propertyList.Count, 2, MidpointRounding.AwayFromZero);
        decimal assigned = 0m;
        bool anyFailure = false;

        for (int i = 0; i < propertyList.Count; i++)
        {
            var propertyId = propertyList[i];
            decimal splitAmount = (i == propertyList.Count - 1)
                ? plaidTx.Amount - assigned
                : baseSplit;
            assigned += splitAmount;

            // Restaurar estado válido antes de invocar la PaymentService.
            if (plaidTx.Status != originalStatus)
            {
                plaidTx.Status = originalStatus;
                _plaidRepository.Update(plaidTx);
                await _unitOfWork.SaveChangesAsync();
            }

            var splitCandidate = new ChargeCandidate
            {
                RecurringChargeId = best.Candidate.RecurringChargeId,
                TransactionId = null,
                ChargeDate = plaidTx.Date,
                Amount = splitAmount,
                Description = $"Virtual Split {best.Candidate.Description}",
                PropertyId = propertyId,
                LeaseId = best.Candidate.LeaseId,
                MatchTags = best.Candidate.MatchTags,
                IsPending = true,
                IsSpliteable = true,
                SourceRecurringCharge = sourceRc
            };

            var splitScored = new ScoredCandidate
            {
                Candidate = splitCandidate,
                Score = best.Score,
                Details = best.Details
            };

            var reconciliation = _scoreCalculator.CreatePlaidReconciliation(plaidTx, splitScored);
            // Override: CreatePlaidReconciliation setea ActualAmount = plaidTx.Amount (total).
            // Para splits cada reconciliation debe reflejar su porción.
            reconciliation.ActualAmount = splitAmount;
            reconciliation.ExpectedAmount = splitAmount;
            reconciliation.Status = PlaidReconciliationStatus.AutoApplied;
            await _reconciliationRepository.AddAsync(reconciliation);

            var applied = await _paymentApplier.ApplyAsync(reconciliation, splitCandidate, plaidTx);
            if (!applied)
            {
                anyFailure = true;
                _logger.LogError(
                    "Split iteration failed for PlaidTx {PlaidId} property {PropertyId} amount {Amount}",
                    plaidTx.Id, propertyId, splitAmount);
            }
        }

        // Avanzar NextChargeDate solo si todas las iteraciones fueron exitosas.
        if (!anyFailure && sourceRc != null && sourceRc.IsRecurrent && sourceRc.NextChargeDate.HasValue)
        {
            sourceRc.NextChargeDate = sourceRc.CalculateNextDate(sourceRc.NextChargeDate.Value);
            _recurringChargeRepository.Update(sourceRc);
            await _unitOfWork.SaveChangesAsync();
        }

        // Estado final de la Plaid Tx: Error si algún split falló, AutoReconciled si todas ok.
        plaidTx.Status = anyFailure
            ? PlaidTransactionStatus.Error
            : PlaidTransactionStatus.AutoReconciled;
        _plaidRepository.Update(plaidTx);

        return !anyFailure;
    }
}
