

namespace Levara.Domain.Models;

public class ExpensePayment : Entity
{
    public int TransactionId { get; set; }
    public Transaction Transaction {  get; set; }
    public int ExpenseId { get; set; }
    public Expense Expense { get; set; }
}
