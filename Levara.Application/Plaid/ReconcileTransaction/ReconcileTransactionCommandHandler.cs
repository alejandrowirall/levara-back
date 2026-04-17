using Levara.Application.Plaid.ReconcileTransaction.Models;
using Levara.Application.Plaid.ReconcileTransaction.Services;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;
using Microsoft.Extensions.Logging;

namespace Levara.Application.Plaid.ReconcileTransaction;

public class ReconcileTransactionCommandHandler : ICommandHandler<ReconcileTransactionCommand, ReconcileTransactionCommandResponse>
{
    private readonly IOwnerBankAccountRepository _ownerBankAccountRepository;
    private readonly IPropertyRepository _propertyRepository;
    private readonly IRecurringChargeRepository _recurringChargeRepository;
    private readonly IPlaidRepository _plaidRepository;

    private readonly PendingChargeGenerator _chargeGenerator;
    private readonly ReconciliationCandidateBuilder _candidateBuilder;
    private readonly ReconciliationLevelProcessor _levelProcessor;
    private readonly ILogger<ReconcileTransactionCommandHandler> _logger;

    public ReconcileTransactionCommandHandler(
        IOwnerBankAccountRepository ownerBankAccountRepository,
        IPropertyRepository propertyRepository,
        IRecurringChargeRepository recurringChargeRepository,
        IPlaidRepository plaidRepository,
        PendingChargeGenerator chargeGenerator,
        ReconciliationCandidateBuilder candidateBuilder,
        ReconciliationLevelProcessor levelProcessor,
        ILogger<ReconcileTransactionCommandHandler> logger)
    {
        _ownerBankAccountRepository = ownerBankAccountRepository;
        _propertyRepository = propertyRepository;
        _recurringChargeRepository = recurringChargeRepository;
        _plaidRepository = plaidRepository;
        _chargeGenerator = chargeGenerator;
        _candidateBuilder = candidateBuilder;
        _levelProcessor = levelProcessor;
        _logger = logger;
    }

    public async Task<OperationResult<ReconcileTransactionCommandResponse>> Handle(ReconcileTransactionCommand command)
    {
        var utcNow = DateTime.UtcNow;

        // 1. Cargar OwnerBankAccount
        var ownerBankAccount = await _ownerBankAccountRepository.FirstOrDefaultAsync(
            oba => oba.Id == command.OwnerBankAccountId!.Value);

        if (ownerBankAccount == null)
            return OperationResult<ReconcileTransactionCommandResponse>.ErrorResult(
                new ErrorDetails(404, "OwnerBankAccount not found"));

        // 2. Cargar propiedades del bank account
        var propertiesQuery = _propertyRepository.GetAll()
            .Where(p => p.OwnerBankAccountId == ownerBankAccount.Id);
        var properties = await _propertyRepository.ToListAsync(propertiesQuery);
        var propertyIdSet = properties.Select(p => p.Id).ToHashSet();

        // 3. Clasificar RecurringCharges
        var rcRecurrent = await LoadRecurringChargesAsync(
            propertyIdSet, isRecurrent: true, spliteable: false);

        var rcNonRecurrent = await LoadRecurringChargesAsync(
            propertyIdSet, isRecurrent: false, spliteable: false, ownerId: ownerBankAccount.OwnerId);

        var rcSpliteable = await LoadRecurringChargesAsync(
            propertyIdSet, isRecurrent: false, spliteable: true, ownerId: ownerBankAccount.OwnerId);

        // 4. Generar cargos pendientes para recurrentes
        await _chargeGenerator.GenerateAsync(rcRecurrent, utcNow);

        // 5. Cargar transacciones pendientes
        var pendingTxs = await LoadPendingTransactionsAsync(command.OwnerBankAccountId!.Value);
        if (!pendingTxs.Any())
            return OperationResult<ReconcileTransactionCommandResponse>.SuccessResult(new());

        // 6. Level 1: Recurrentes con instancias reales
        await _levelProcessor.ProcessLevelAsync(pendingTxs, new LevelConfig
        {
            BuildCandidatesAsync = async _ =>
                await _candidateBuilder.BuildRealInstanceCandidatesAsync(rcRecurrent, utcNow),

            IsAvailable = (c, usedTxIds, _) =>
                !c.TransactionId.HasValue || !usedTxIds.Contains(c.TransactionId.Value),

            ReserveCandidate = (c, usedTxIds, _) =>
            {
                if (c.TransactionId.HasValue)
                    usedTxIds.Add(c.TransactionId.Value);
            }
        });

        // 7. Level 2: No-recurrentes virtuales
        await _levelProcessor.ProcessLevelAsync(pendingTxs, new LevelConfig
        {
            BuildCandidatesAsync = plaidTx =>
                Task.FromResult(_candidateBuilder.BuildVirtualCandidates(rcNonRecurrent, plaidTx.Date)),

            IsAvailable = (c, _, usedRcIds) =>
                !c.RecurringChargeId.HasValue || !usedRcIds.Contains(c.RecurringChargeId.Value),

            ReserveCandidate = (c, _, usedRcIds) =>
            {
                if (c.RecurringChargeId.HasValue)
                    usedRcIds.Add(c.RecurringChargeId.Value);
            }
        });

        // 8. Level 3: Spliteables
        await _levelProcessor.ProcessLevelAsync(pendingTxs, new LevelConfig
        {
            BuildCandidatesAsync = plaidTx =>
                Task.FromResult(_candidateBuilder.BuildVirtualCandidates(rcSpliteable, plaidTx.Date)),

            IsAvailable = (c, _, usedRcIds) =>
                !c.RecurringChargeId.HasValue || !usedRcIds.Contains(c.RecurringChargeId.Value),

            ReserveCandidate = (c, _, usedRcIds) =>
            {
                if (c.RecurringChargeId.HasValue)
                    usedRcIds.Add(c.RecurringChargeId.Value);
            },

            IsSplitLevel = true,
            PropertyIdSet = propertyIdSet
        });

        // 9. Final Pass: NeedReview con candidatos de todos los niveles
        await _levelProcessor.ProcessFinalPassAsync(pendingTxs, async plaidTx =>
        {
            var allCandidates = new List<ChargeCandidate>();

            // Nivel 1: instancias reales más cercanas a la fecha de la PlaidTx
            var realCandidates = await _candidateBuilder.BuildClosestInstanceCandidatesAsync(
                rcRecurrent, utcNow, plaidTx.Date);
            allCandidates.AddRange(realCandidates);

            // Nivel 2: virtuales no-recurrentes
            allCandidates.AddRange(
                _candidateBuilder.BuildVirtualCandidates(rcNonRecurrent, plaidTx.Date));

            // Nivel 3: transacciones sueltas
            var looseCandidates = await _candidateBuilder.BuildLooseTransactionCandidatesAsync(
                ownerBankAccount.OwnerId, utcNow);
            allCandidates.AddRange(looseCandidates);

            return allCandidates;
        });

        return OperationResult<ReconcileTransactionCommandResponse>.SuccessResult(new());
    }

    private async Task<List<RecurringCharge>> LoadRecurringChargesAsync(
        HashSet<int> propertyIdSet,
        bool isRecurrent,
        bool spliteable,
        int? ownerId = null)
    {
        var query = _recurringChargeRepository.GetAllFull()
            .Where(rc => propertyIdSet.Contains(rc.PropertyId) &&
                         rc.Active &&
                         rc.IsRecurrent == isRecurrent &&
                         rc.Spliteable == spliteable);

        if (ownerId.HasValue)
            query = query.Where(rc => rc.Property.OwnerId == ownerId.Value);

        var result = await _recurringChargeRepository.ToListAsync(query);
        return result.ToList();
    }

    private async Task<List<PlaidTransaction>> LoadPendingTransactionsAsync(int ownerBankAccountId)
    {
        var query = _plaidRepository.GetAll()
            .Where(pt => pt.OwnerBankAccountId == ownerBankAccountId &&
                         (pt.Status == PlaidTransactionStatus.Created ||
                          pt.Status == PlaidTransactionStatus.NoMatch ||
                          pt.Status == PlaidTransactionStatus.Error))
            .OrderBy(pt => pt.Date);

        var result = await _plaidRepository.ToListAsync(query);
        return result.ToList();
    }
}
