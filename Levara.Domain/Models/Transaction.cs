using Levara.Domain.Enum;
using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Domain.Models;

public class Transaction : Entity
{
    public TransactionType Type { get; set; }

    public TransactionSubType SubType { get; set; }

    public int PropertyId { get; set; }

    public Property Property { get; set; }

    public int EntityId { get; set; }

    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    [Required]
    [Length(1, 200)]
    public string Description { get; set; }
    public decimal RunningBalance { get; set; }
    public decimal EntityRunningBalance { get; set; }

    
    
    public static Transaction CreateExpenseCharge(int propertyId,
        decimal amount,
        int expenseId,
        string expenseName,
        decimal currentRunningBalance,
        decimal currentEntityRunningBalance,
        DateTime? date = null
        )
    {
        return new Transaction
        {
            Type = TransactionType.Expense,
            SubType = TransactionSubType.Charge,
            PropertyId = propertyId,
            Amount = amount,
            Date = date ?? DateTime.UtcNow,
            Description = $"Expense charge {expenseName}",
            RunningBalance = currentRunningBalance - amount,
            EntityRunningBalance = currentEntityRunningBalance - amount,
            EntityId = expenseId,
        };
    }

    public static Transaction CreateExpensePayment(int propertyId,
        decimal amount,
        int expenseId,
        string expenseName,
        decimal currentRunningBalance,
        decimal currentEntityRunningBalance,
        DateTime? date = null
        )
    {
        return new Transaction
        {
            Type = TransactionType.Expense,
            SubType = TransactionSubType.Payment,
            PropertyId = propertyId,
            Amount = amount,
            Date = date ?? DateTime.UtcNow,
            Description = $"Expense payment {expenseName}",
            RunningBalance = currentRunningBalance + amount,
            EntityRunningBalance = currentEntityRunningBalance + amount,
            EntityId = expenseId
        };
    }

    public static Transaction CreateLeaseCharge(int propertyId,
        decimal amount,
        int leaseId,
        string descripcion,
        decimal currentRunningBalance,
        decimal currentEntityRunningBalance,
        DateTime? date = null
        )
    {
        return new Transaction
        {
            Type = TransactionType.Lease,
            SubType = TransactionSubType.Charge,
            PropertyId = propertyId,
            Amount = amount,
            Date = date ?? DateTime.UtcNow,
            Description = $"Lease charge {descripcion}",
            RunningBalance = currentRunningBalance - amount,
            EntityRunningBalance = currentEntityRunningBalance - amount,
            EntityId = leaseId,
        };
    }

    public static Transaction CreateLeasePayment(int propertyId,
        decimal amount,
        int leaseId,
        string description,
        decimal nextRunningBalance,
        decimal nextEntityRunningBalance,
        DateTime? date = null
        )
    {
        return new Transaction
        {
            Type = TransactionType.Lease,
            SubType = TransactionSubType.Payment,
            PropertyId = propertyId,
            Amount = amount,
            Date = date ?? DateTime.UtcNow,
            Description = $"Expense payment {description}",
            RunningBalance = nextRunningBalance + amount,
            EntityRunningBalance = nextEntityRunningBalance + amount,
            EntityId = leaseId
        };
    }

    public static Transaction CreateMaintenanceCharge(int propertyId,
        decimal amount,
        int maintenanceId,
        string maintenanceTitle,
        decimal currentRunningBalance,
        decimal currentEntityRunningBalance,
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
            EntityRunningBalance = currentEntityRunningBalance - amount,
            EntityId = maintenanceId
        };
    }

    public static Transaction CreateMaintenancePayment(int propertyId,
        decimal amount,
        int maintenanceId,
        string maintenanceTitle,
        decimal currentRunningBalance,
        decimal currentEntityRunningBalance,
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
            EntityRunningBalance = currentEntityRunningBalance + amount,
            EntityId = maintenanceId
        };
    }

}
