
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
        RecurringChargeId = plaidReconciliation.RecurringChargeId;
        MatchPercentage = plaidReconciliation.MatchPercentage;
        // Priorizar Transaction sobre RecurringCharge
        if (plaidReconciliation.Transaction != null)
        {
            TransactionType = (int)plaidReconciliation.Transaction.Type;
            Description = plaidReconciliation.Transaction.Description;
            Amount = plaidReconciliation.Transaction.Amount;
            Status = (int)plaidReconciliation.Transaction.Status;
            StatusDescription = EnumExtensions.GetEnumDescription(plaidReconciliation.Transaction.Status);
            DueDate = plaidReconciliation.Transaction.DueDate;
            PropertyId = plaidReconciliation.Transaction.PropertyId;
            PropertyDescription = plaidReconciliation.Transaction.Property.OneLineDescription();
        }
        else if (plaidReconciliation.RecurringCharge != null)
        {
            TransactionType = (int)plaidReconciliation.RecurringCharge.Type;
            Description = plaidReconciliation.RecurringCharge.GetChargeDescription();
            Amount = plaidReconciliation.RecurringCharge.Amount;
            Status = (int)TransactionStatus.Unpaid;
            StatusDescription = EnumExtensions.GetEnumDescription(TransactionStatus.Unpaid);
            DueDate = plaidReconciliation.RecurringCharge.NextChargeDate;
            PropertyId = plaidReconciliation.RecurringCharge.PropertyId;
            PropertyDescription = plaidReconciliation.RecurringCharge.Property?.OneLineDescription();
        }
    }
    public int Id { get; set; }
    public int PlaidId { get; set; }
    public int? TransactionId { get; set; }
    public int? RecurringChargeId { get; set; }
    public int? PropertyId { get; set; }
    public string? PropertyDescription { get; set; }
    public int ChargeId { get; set; }
    public int? TransactionType { get; set; }
    public decimal MatchPercentage { get; set; }

    public string ChargeTypeDescription
    {
        get
        {
            if(TransactionType == null)
                return string.Empty;

            // Si es Transaction, mostrar tipo normal
            if (TransactionId.HasValue)
            {
                return (TransactionType)TransactionType switch
                {
                    Levara.Domain.Enum.TransactionType.Lease => "LeaseCharge",
                    Levara.Domain.Enum.TransactionType.Maintenance => "MaintenanceCharge",
                    Levara.Domain.Enum.TransactionType.Expense => "ExpenseCharge",
                    _ => string.Empty
                };
            }

            // Si es RecurringCharge, agregar "Recurring" al tipo
            if (RecurringChargeId.HasValue)
            {
                return (TransactionType)TransactionType switch
                {
                    Levara.Domain.Enum.TransactionType.Lease => "Recurring LeaseCharge",
                    Levara.Domain.Enum.TransactionType.Maintenance => "Recurring MaintenanceCharge",
                    Levara.Domain.Enum.TransactionType.Expense => "Recurring ExpenseCharge",
                    _ => string.Empty
                };
            }

            return string.Empty;
        }
    }
    public DateTime? DueDate { get; set; }
    public string? Description { get; set; }
    public int? Status { get; set; }
    public string? StatusDescription { get; set; }
    public decimal? Amount { get; set; }
    
}
