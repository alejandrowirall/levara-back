using Levara.Domain.Enum;

namespace Levara.Domain.Models;

public class ExpensePayment : Entity
{
    public int TransactionId { get; set; }
    public Transaction Transaction {  get; set; }
    public int ExpenseId { get; set; }
    public Expense Expense { get; set; }

    public static Transaction CreateTransaction(int propertyId,
        decimal amount,
        string expenseName,
        decimal currentRunningBalance,
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
            LeaseRunningBalance = null,
            Status = TransactionStatus.Confirmed,
            DueDate = null
        };
    }
}
