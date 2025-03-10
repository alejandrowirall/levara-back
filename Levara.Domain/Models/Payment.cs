using Levara.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Levara.Domain.Models;

public class Payment : Entity
{
    public DateTime Date { get; set; }

    [Required]
    [Length(1, 200)]
    public string Description { get; set; }

    public decimal Amount { get; set; }

    public int PropertyId { get; set; }

    public Property Property { get; set; }

    public int? LeaseId { get; set; }

    public Lease? Lease { get; set; }

    public int? OwnerBankAccountId { get; set; }

    public OwnerBankAccount OwnerBankAccount { get; set; }

    public decimal RunningBalance { get; set; }

    public decimal? BankAccountBalance { get; set; }

    public TransactionType Type { get; set; }

    public PaymentMethod PaymentMethod { get; set; }

    public int? PlaidTransactionId { get; set; }

    public PlaidTransaction PlaidTransaction { get; set; }
}
