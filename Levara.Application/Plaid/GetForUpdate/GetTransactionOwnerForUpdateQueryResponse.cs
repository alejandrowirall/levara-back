
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Models;

namespace Levara.Application.Plaid.GetForUpdate;

public class GetTransactionOwnerForUpdateQueryResponse
{
    public GetTransactionOwnerForUpdateQueryResponse(TransactionOwnerUpdateQueryResponse transaction,
        List<ListModel> personTypes
       )
    {
        TransactionOwner = transaction;
        PlaidTransactionStatus = personTypes;
    }
    public TransactionOwnerUpdateQueryResponse TransactionOwner { get; }

    public List<ListModel> PlaidTransactionStatus { get; }

    

}

public class TransactionOwnerUpdateQueryResponse
{
    public TransactionOwnerUpdateQueryResponse(PlaidTransaction transaction)
    {
        Id = transaction.Id;
        TransactionId = transaction.TransactionId;
        Date = transaction.Date;
        Description = transaction.Description;
        Amount = transaction.Amount;
        Status = transaction.Status;
        
    }

    public int Id { get; }
    public string TransactionId { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }

    public double? Amount { get; set; }

    public PlaidTransactionStatus Status { get; set; }
}
