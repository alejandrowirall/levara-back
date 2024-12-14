
using Levara.Domain.Enum;
using Levara.Domain.Models;

namespace Levara.Application.Transactions.GetByGrid;

public class GetTransactionsByGridQueryResponse
{
    public GetTransactionsByGridQueryResponse(Transaction transaction)
    {
        Id = transaction.Id;
        Type = transaction.Type;
        SubType = transaction.SubType;
        PropertyId=transaction.PropertyId;
        Property=transaction.Property;
        Amount=transaction.Amount;
        Date=transaction.Date;
        Description=transaction.Description;
        RunningBalance=transaction.RunningBalance;
        EntityRunningBalance=transaction.EntityRunningBalance;
        
    }

    public int Id { get; set; }
    public TransactionType Type { get; set; }

    public TransactionSubType SubType { get; set; }

    public int PropertyId { get; set; }
    public Property Property { get; set; }

    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public decimal RunningBalance { get; set; }
    public decimal EntityRunningBalance { get; set; }
}