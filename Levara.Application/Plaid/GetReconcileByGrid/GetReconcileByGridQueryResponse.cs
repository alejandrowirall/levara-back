
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Extensions;

namespace Levara.Application.Plaid.GetReconcileByGrid;

public class GetReconcileByGridQueryResponse
{
    public GetReconcileByGridQueryResponse(PlaidReconciliation plaidReconciliation)
    {

        Id = plaidReconciliation.Id;
        PlaidId = plaidReconciliation.PlaidTransactionId;
        TransactionId = plaidReconciliation.TransactionId;
        TransactionType = plaidReconciliation.Transaction.Type;
        Description = plaidReconciliation.Transaction.Description;
        Amount = plaidReconciliation.Transaction.Amount;

        Status = plaidReconciliation.Transaction.Status;
        StatusDescription = EnumExtensions.GetEnumDescription(plaidReconciliation.Transaction.Status);
        DueDate = plaidReconciliation.Transaction.DueDate!.Value;

        PropertyId = plaidReconciliation.Transaction.PropertyId;
        PropertyDescription = plaidReconciliation.Transaction.Property.OneLineDescription();
    }
    public int Id { get; set; }
    public int PlaidId { get; set; }
    public int TransactionId { get; set; }
    public int PropertyId { get; set; }
    public string PropertyDescription { get; set; }
    public int ChargeId { get; set; }
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
    public TransactionStatus Status { get; set; }
    public string StatusDescription { get; set; }
    public decimal Amount { get; set; }
}
