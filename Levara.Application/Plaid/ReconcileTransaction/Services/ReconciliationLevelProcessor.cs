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
    private readonly ReconciliationScoreCalculator _scoreCalculator;
    private readonly ReconciliationPaymentApplier _paymentApplier;
    private readonly ILogger<ReconciliationLevelProcessor> _logger;

    public ReconciliationLevelProcessor(
        IUnitOfWork unitOfWork,
        IPlaidRepository plaidRepository,
        IPlaidReconciliationRepository reconciliationRepository,
        ReconciliationScoreCalculator scoreCalculator,
        ReconciliationPaymentApplier paymentApplier,
        ILogger<ReconciliationLevelProcessor> logger)
    {
        _unitOfWork = unitOfWork;
        _plaidRepository = plaidRepository;
        _reconciliationRepository = reconciliationRepository;
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

                        var best = scored
                            .Where(sc => sc.Score >= ReconciliationScoreCalculator.AUTO_APPLY_THRESHOLD)
                            .FirstOrDefault();

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
                        var best = scored
                            .Where(sc => sc.Score >= ReconciliationScoreCalculator.AUTO_APPLY_THRESHOLD)
                            .FirstOrDefault();

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

        decimal splitAmount = plaidTx.Amount / propertyIdSet.Count;

        foreach (var propertyId in propertyIdSet)
        {
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
                SourceRecurringCharge = best.Candidate.SourceRecurringCharge
            };

            var splitScored = new ScoredCandidate
            {
                Candidate = splitCandidate,
                Score = best.Score,
                Details = best.Details
            };

            var reconciliation = _scoreCalculator.CreatePlaidReconciliation(plaidTx, splitScored);
            reconciliation.Status = PlaidReconciliationStatus.AutoApplied;
            await _reconciliationRepository.AddAsync(reconciliation);

            await _paymentApplier.ApplyAsync(reconciliation, splitCandidate, plaidTx);
        }

        plaidTx.Status = PlaidTransactionStatus.AutoReconciled;
        _plaidRepository.Update(plaidTx);

        return true;
    }
}
