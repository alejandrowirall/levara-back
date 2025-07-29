
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Models;
using Levara.Shared.Extensions;

namespace Levara.Application.Plaid.GetForUpdate;

public class GetPlaidTransactionForUpdateQueryResponse
{
    public GetPlaidTransactionForUpdateQueryResponse(PliadTransactionUpdate plaidTransaction,
        List<ListModel> statuses,
        PliadTransactionCharge? pliadTransactionCharge = null
       )
    {
        PlaidTransaction = plaidTransaction;
        Statuses = statuses;
        PliadTransactionCharge = pliadTransactionCharge;
    }
    public PliadTransactionUpdate PlaidTransaction { get; }

    public List<ListModel> Statuses { get; }

    public PliadTransactionCharge? PliadTransactionCharge { get; }

}

public class PliadTransactionUpdate
{
    public PliadTransactionUpdate(PlaidTransaction transaction)
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
    public decimal Amount { get; set; }
    public PlaidTransactionStatus Status { get; set; }
}

public class PliadTransactionCharge
{
    public PliadTransactionCharge(TransactionApplication transactionApplication)
    {
        Id = transactionApplication.Payment.Id;
        PlaidId = transactionApplication.Payment.PlaidTransactionId!.Value;
        TransactionId = transactionApplication.ChargeTransactionId;
        TransactionType = transactionApplication.ChargeTransaction.Type;
        Description = transactionApplication.ChargeTransaction.Description;
        Amount = transactionApplication.ChargeTransaction.Amount;
        StatusDescription = EnumExtensions.GetEnumDescription(transactionApplication.ChargeTransaction.Status);
        DueDate = transactionApplication.ChargeTransaction.DueDate!.Value;
        PropertyId = transactionApplication.Payment.PropertyId;
        PropertyDescription = transactionApplication.Payment.Property.OneLineDescription();
    }

    public int Id { get; set; }
    public int PlaidId { get; set; }
    public int TransactionId { get; set; }
    public int PropertyId { get; set; }
    public string PropertyDescription { get; set; }
    public TransactionType TransactionType { get; set; }

    public string ChargeTypeDescription
    {
        get
        {
            return TransactionType switch
            {
                TransactionType.Lease => "LeaseCharge",
                TransactionType.Maintenance => "MaintenanceCharge",
                TransactionType.Expense => "ExpenseCharge",
                _ => string.Empty
            };
        }
    }
    public DateTime DueDate { get; set; }
    public string Description { get; set; }
    public string StatusDescription { get; set; }
    public decimal Amount { get; set; }
}

