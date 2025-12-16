using Levara.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Levara.Domain.Models;

public class LeaseCharge : Entity
{
    [Required]
    public string Description { get; set; }

    public int TransactionId { get; set; }
    public Transaction Transaction { get; set; }

    public int TypeId { get; set; }

    public LeaseChargeType Type { get; set; }



    public static Transaction CreateTransaction(int propertyId,
        decimal amount,
        int leaseId,
        string descripcion,
        decimal currentRunningBalance,
        decimal currentLeaseRunningBalance,
        DateTime dueDate,
        DateTime? date = null
        )
    {
        return new Transaction
        {
            Type = TransactionType.Lease,
            SubType = TransactionSubType.Charge,
            PropertyId = propertyId,
            LeaseId = leaseId,
            Amount = amount,
            Date = date ?? DateTime.UtcNow,
            Description = $"Lease charge {descripcion}",
            RunningBalance = currentRunningBalance - amount,
            LeaseRunningBalance = currentLeaseRunningBalance - amount,
            Status = TransactionStatus.Unpaid,
            DueDate = dueDate
        };
    }

}
