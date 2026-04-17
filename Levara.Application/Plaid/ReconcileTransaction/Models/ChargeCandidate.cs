using Levara.Domain.Models;

namespace Levara.Application.Plaid.ReconcileTransaction.Models;

public class ChargeCandidate
{
    public int? RecurringChargeId { get; set; }
    public int? TransactionId { get; set; }
    public DateTime ChargeDate { get; set; }
    public decimal? Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public int PropertyId { get; set; }
    public int? LeaseId { get; set; }
    public List<string>? MatchTags { get; set; }
    public bool IsPending { get; set; }
    public bool IsSpliteable { get; set; }

    // Referencias directas para evitar null reference en ApplyPayment
    public RecurringCharge? SourceRecurringCharge { get; set; }
    public Transaction? SourceTransaction { get; set; }
}
