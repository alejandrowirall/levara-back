using Levara.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Levara.Domain.Models;

public class Transaction : Entity
{
    public TransactionType Type { get; set; }

    public TransactionSubType SubType { get; set; }

    public int PropertyId { get; set; }

    public Property Property { get; set; }

    public int? LeaseId { get; set; }

    public Lease? Lease { get; set; }

    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public DateTime? DueDate { get; set; }
    public TransactionStatus Status { get; set; }

    [Required]
    [Length(1, 200)]
    public string Description { get; set; }
    public decimal RunningBalance { get; set; }
    public decimal? LeaseRunningBalance { get; set; }

}
