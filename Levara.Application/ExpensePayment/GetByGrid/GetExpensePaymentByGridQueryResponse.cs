
using Levara.Domain.Enum;
using Levara.Domain.Models;

namespace Levara.Application.ExpensePayments.GetByGrid;

public class GetExpensePaymentByGridQueryResponse
{
    public GetExpensePaymentByGridQueryResponse(ExpensePayment expensePayment)
    {
        TransactionId = expensePayment.TransactionId;
        Transaction = expensePayment.Transaction;
        ExpenseId = expensePayment.ExpenseId;
        Expense = expensePayment.Expense;
    }

    public int TransactionId { get; set; }
    public Transaction Transaction { get; set; }

   
    public int ExpenseId { get; set; }

    public Expense Expense { get; set; }

}