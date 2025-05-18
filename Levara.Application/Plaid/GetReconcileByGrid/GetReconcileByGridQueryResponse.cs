
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.ExternalService.Plaid;

namespace Levara.Application.Plaid.GetReconcileByGrid;

public class GetReconcileByGridQueryResponse
{
    public GetReconcileByGridQueryResponse(PlaidReconciliation plaidReconciliation)
    {
        Address address = plaidReconciliation.Transaction.Property.Address;

        Id = plaidReconciliation.Id;
        PlaidId = plaidReconciliation.PlaidTransactionId;
        TransactionId = plaidReconciliation.TransactionId;
        TransactionType = plaidReconciliation.Transaction.Type;
        Description = plaidReconciliation.Transaction.Description;
        Amount = plaidReconciliation.Transaction.Amount;

        StatusDescription = string.Empty;
        PropertyId = plaidReconciliation.Transaction.PropertyId;
        PropertyDescription = $"{plaidReconciliation.Transaction.Property.Number} - {address.Street} {address.Number}, {address.City}, {address.State}";
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
    public string StatusDescription { get; set; }
    public decimal Amount { get; set; }
}
