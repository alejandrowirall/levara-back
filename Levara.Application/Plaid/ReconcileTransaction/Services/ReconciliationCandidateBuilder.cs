using Levara.Application.Plaid.ReconcileTransaction.Models;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;

namespace Levara.Application.Plaid.ReconcileTransaction.Services;

public class ReconciliationCandidateBuilder
{
    private readonly IRecurringChargeInstanceRepository _instanceRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IRecurringChargeRepository _recurringChargeRepository;

    public ReconciliationCandidateBuilder(
        IRecurringChargeInstanceRepository instanceRepository,
        ITransactionRepository transactionRepository,
        IRecurringChargeRepository recurringChargeRepository)
    {
        _instanceRepository = instanceRepository;
        _transactionRepository = transactionRepository;
        _recurringChargeRepository = recurringChargeRepository;
    }

    public async Task<List<ChargeCandidate>> BuildRealInstanceCandidatesAsync(
        IEnumerable<RecurringCharge> recurringCharges,
        DateTime utcNow)
    {
        var candidates = new List<ChargeCandidate>();
        foreach (var rc in recurringCharges)
        {
            var candidate = await GetOldestUnpaidInstanceAsync(rc, utcNow);
            if (candidate != null)
                candidates.Add(candidate);
        }
        return candidates;
    }

    public async Task<List<ChargeCandidate>> BuildClosestInstanceCandidatesAsync(
        IEnumerable<RecurringCharge> recurringCharges,
        DateTime utcNow,
        DateTime referenceDate)
    {
        var candidates = new List<ChargeCandidate>();
        foreach (var rc in recurringCharges)
        {
            var candidate = await GetClosestUnpaidInstanceAsync(rc, utcNow, referenceDate);
            if (candidate != null)
                candidates.Add(candidate);
        }
        return candidates;
    }

    public List<ChargeCandidate> BuildVirtualCandidates(
        IEnumerable<RecurringCharge> recurringCharges,
        DateTime referenceDate)
    {
        return recurringCharges.Select(rc => new ChargeCandidate
        {
            RecurringChargeId = rc.Id,
            TransactionId = null,
            ChargeDate = referenceDate,
            Amount = rc.Amount,
            Description = $"Virtual {rc.Type}",
            PropertyId = rc.PropertyId,
            LeaseId = rc.LeaseId,
            MatchTags = rc.MatchTags ?? new List<string>(),
            IsPending = true,
            IsSpliteable = rc.Spliteable,
            SourceRecurringCharge = rc
        }).ToList();
    }

    public async Task<List<ChargeCandidate>> BuildLooseTransactionCandidatesAsync(
        int ownerId,
        DateTime utcNow)
    {
        var query = _transactionRepository.GetAllFull()
            .Where(t => t.Property.OwnerId == ownerId)
            .Where(t => t.SubType == TransactionSubType.Charge)
            .Where(t => t.Status == TransactionStatus.Unpaid)
            .Where(t => t.Date <= utcNow)
            .Where(t => !_instanceRepository.GetAll()
                .Any(rci => rci.TransactionId == t.Id));

        var looseTransactions = await _transactionRepository.ToListAsync(query);

        return looseTransactions.Select(tx => new ChargeCandidate
        {
            RecurringChargeId = null,
            TransactionId = tx.Id,
            ChargeDate = tx.Date,
            Amount = tx.Amount,
            Description = tx.Description,
            PropertyId = tx.PropertyId,
            LeaseId = tx.LeaseId,
            MatchTags = new List<string>(),
            IsPending = false,
            SourceTransaction = tx
        }).ToList();
    }

    private async Task<ChargeCandidate?> GetOldestUnpaidInstanceAsync(
        RecurringCharge rc,
        DateTime utcNow)
    {
        var query = _instanceRepository.GetAllFull()
            .Where(i => i.RecurringChargeId == rc.Id)
            .Where(i => i.Transaction != null)
            .Where(i => i.Transaction!.Status == TransactionStatus.Unpaid)
            .Where(i => i.Transaction!.Date <= utcNow);

        var instance = await _instanceRepository.FirstOrDefaultAsync(
            query.OrderBy(i => i.Transaction!.Date));

        return instance != null ? MapInstanceToCandidate(rc, instance) : null;
    }

    private async Task<ChargeCandidate?> GetClosestUnpaidInstanceAsync(
        RecurringCharge rc,
        DateTime utcNow,
        DateTime referenceDate)
    {
        var query = _instanceRepository.GetAllFull()
            .Where(i => i.RecurringChargeId == rc.Id)
            .Where(i => i.Transaction != null)
            .Where(i => i.Transaction!.Status == TransactionStatus.Unpaid)
            .Where(i => i.Transaction!.Date <= utcNow);

        var allInstances = await _instanceRepository.ToListAsync(query);

        var closest = allInstances
            .OrderBy(i => Math.Abs((i.Transaction!.Date - referenceDate).Ticks))
            .FirstOrDefault();

        return closest != null ? MapInstanceToCandidate(rc, closest) : null;
    }

    private static ChargeCandidate MapInstanceToCandidate(
        RecurringCharge rc,
        RecurringChargeInstance instance)
    {
        return new ChargeCandidate
        {
            RecurringChargeId = rc.Id,
            TransactionId = instance.TransactionId,
            ChargeDate = instance.Transaction!.Date,
            Amount = instance.Transaction.Amount,
            Description = instance.Transaction.Description,
            PropertyId = instance.Transaction.PropertyId,
            LeaseId = instance.Transaction.LeaseId,
            MatchTags = rc.MatchTags ?? new List<string>(),
            IsPending = false,
            SourceRecurringCharge = rc,
            SourceTransaction = instance.Transaction
        };
    }
}
