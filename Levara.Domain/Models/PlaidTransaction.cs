using Levara.Domain.Enum;

namespace Levara.Domain.Models;

public class PlaidTransaction : Entity
{
    public string TransactionId { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }

    public decimal Amount { get; set; }

    public PlaidTransactionStatus Status { get; set; }

    public int OwnerBankAccountId { get; set; }
    public OwnerBankAccount OwnerBankAccount { get; set; }
}
