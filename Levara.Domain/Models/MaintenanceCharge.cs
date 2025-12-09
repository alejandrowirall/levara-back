using Levara.Domain.Enum;

namespace Levara.Domain.Models;

public class MaintenanceCharge : Entity
{
    public int TransactionId { get; set; }
    public Transaction Transaction { get; set; }

    public int MaintenanceId { get; set; }

    public Maintenance Maintenance { get; set; }

    public static Transaction CreateTransaction(int propertyId,
        decimal amount,
        string maintenanceTitle,
        decimal currentRunningBalance,
        DateTime dueDate,
        DateTime? date = null
        )
    {
        return new Transaction
        {
            Type = TransactionType.Maintenance,
            SubType = TransactionSubType.Charge,
            PropertyId = propertyId,
            Amount = amount,
            Date = date ?? DateTime.UtcNow,
            Description = $"Maintenance charge {maintenanceTitle}",
            RunningBalance = currentRunningBalance - amount,
            LeaseRunningBalance = null,
            Status = TransactionStatus.Unpaid,
            DueDate = dueDate
        };
    }

}
