
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Extensions;

namespace Levara.Application.Leases.GetTransactionByGrid;

public class GetLeaseTransactionByGridQueryResponse
{
    public GetLeaseTransactionByGridQueryResponse(Transaction transaction)
    {
        Id = transaction.Id;
        LeaseId = transaction.LeaseId ?? 0;
        SubType = transaction.SubType;
        SubTypeDesc = EnumExtensions.GetEnumDescription(transaction.SubType);
        Date = transaction.Date;
        Description = transaction.Description;
        Amount = transaction.Amount;
        RunningBalance = transaction.LeaseRunningBalance ?? 0;
    }
    public int Id { get; }

    public int LeaseId { get; }

    public TransactionSubType SubType { get; set; }

    public string SubTypeDesc { get; set; }

    public DateTime Date { get; set; }

    public string Description { get; set; }

    public decimal Amount { get; set; }

    public decimal RunningBalance { get; set; }

}