using Levara.Domain.Enum;

namespace Levara.Domain.Models;

public class ExpenseCharge : Entity
{
    public int TransactionId { get; set; }
    public Transaction Transaction { get; set; }

    public DateTime DueDate {  get; set; }

    public int ExpenseId { get; set; }

    public Expense Expense { get; set; }

    public ExpenseChargeStatus Status { get; set; }

}
