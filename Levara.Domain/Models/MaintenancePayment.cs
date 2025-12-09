using Levara.Domain.Enum;

namespace Levara.Domain.Models;

public class MaintenancePayment : Entity
{
    public int TransactionId { get; set; }
    public Transaction Transaction {  get; set; }
    public int MaintenanceId { get; set; }
    public Maintenance Maintenance { get; set; }

    public static Transaction CreateTransaction(int propertyId,
        decimal amount,
        string maintenanceTitle,
        decimal currentRunningBalance,
        DateTime? date = null
        )
    {
        return new Transaction
        {
            Type = TransactionType.Maintenance,
            SubType = TransactionSubType.Payment,
            PropertyId = propertyId,
            Amount = amount,
            Date = date ?? DateTime.UtcNow,
            Description = $"Maintenance payment {maintenanceTitle}",
            RunningBalance = currentRunningBalance + amount,
            LeaseRunningBalance = null,
            Status = TransactionStatus.Confirmed,
            DueDate = null
        };
    }
}
