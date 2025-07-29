
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Extensions;

namespace Levara.Application.ExpenseCharges.GetByGrid;

public class GetExpenseChargeByGridQueryResponse
{
    public GetExpenseChargeByGridQueryResponse(ExpenseCharge expenseCharge)
    {
        Id = expenseCharge.Id;
        TransactionId = expenseCharge.TransactionId;
        Transaction = expenseCharge.Transaction;
        DueDate = expenseCharge.Transaction.DueDate ?? DateTime.MinValue;
        ExpenseId = expenseCharge.ExpenseId;
        Lease = expenseCharge.Expense;
        Status = expenseCharge.Transaction.Status;
        StatusDescription = EnumExtensions.GetEnumDescription(expenseCharge.Transaction.Status);
    }

    public int Id { get; set; }
    public int TransactionId { get; set; }
    public Transaction Transaction { get; set; }
    public DateTime DueDate { get; set; }
    public int ExpenseId { get; set; }
    public Expense Lease { get; set; }
    public TransactionStatus Status { get; set; }
    public string StatusDescription { get; set; }
}