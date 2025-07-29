
using Levara.Domain.Models;
using Levara.Shared.Extensions;

namespace Levara.Application.Transactions.GetByGrid;

public class GetTransactionsByGridQueryResponse
{
    public GetTransactionsByGridQueryResponse(Transaction transaction)
    {
        Id = transaction.Id;
        Description = transaction.Description;
        PropertyDesc = transaction.Property.OneLineDescription();
        Date = transaction.Date;
        TypeDesc = EnumExtensions.GetEnumDescription(transaction.Type);
        SubTypeDesc = EnumExtensions.GetEnumDescription(transaction.SubType);
        Amount = transaction.Amount;
        Status = (int)transaction.Status;
        StatusDesc = EnumExtensions.GetEnumDescription(transaction.Status);
    }

    public int Id { get; set; }
    public string TypeDesc { get; set; }
    public string SubTypeDesc { get; set; }
    public string PropertyDesc { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }

    public int Status { get; set; }
    public string StatusDesc { get; set; }
}