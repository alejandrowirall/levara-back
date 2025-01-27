
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
        DueDate = expenseCharge.DueDate;
        ExpenseId = expenseCharge.ExpenseId;
        Lease = expenseCharge.Expense;
        Status = expenseCharge.Status;
        StatusDescription = EnumExtensions.GetEnumDescription(expenseCharge.Status);
    }

    public int Id { get; set; }
    public int TransactionId { get; set; }
    public Transaction Transaction { get; set; }
    public DateTime DueDate { get; set; }
    public int ExpenseId { get; set; }
    public Expense Lease { get; set; }
    public ExpenseChargeStatus Status { get; set; }
    public string StatusDescription { get; set; }
}