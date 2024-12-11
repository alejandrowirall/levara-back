using Levara.Domain.Enum;

namespace Levara.Domain.Models;

public class LeaseCharge : Entity
{
    public int TransactionId { get; set; }
    public Transaction Transaction { get; set; }

    public DateTime DueDate {  get; set; }

    public int LeaseId { get; set; }

    public Lease Lease { get; set; }

    public LeaseChargeStatus Status { get; set; }

}
