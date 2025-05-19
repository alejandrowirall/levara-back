
using Levara.Domain.Models;
using Levara.Shared.Extensions;

namespace Levara.Application.Transactions.GetByGrid;

public class GetTransactionsByGridQueryResponse
{
    public GetTransactionsByGridQueryResponse(Transaction transaction,
        ExpenseCharge? expenseCharge,
        LeaseCharge? leaseCharge,
        MaintenanceCharge? maintenanceCharge)
    {
        Id = transaction.Id;
        Description = transaction.Description;
        PropertyDesc = transaction.Property.OneLineDescription();
        Date = transaction.Date;
        TypeDesc = EnumExtensions.GetEnumDescription(transaction.Type);
        SubTypeDesc = EnumExtensions.GetEnumDescription(transaction.SubType);
        Amount = transaction.Amount;

        if (leaseCharge != null)
        {
            Status = (int)leaseCharge.Status;
            StatusDesc = EnumExtensions.GetEnumDescription(leaseCharge.Status);
            return;
        }

        if (expenseCharge != null)
        {
            Status = (int)expenseCharge.Status;
            StatusDesc = EnumExtensions.GetEnumDescription(expenseCharge.Status);
            return;
        }

        if (maintenanceCharge != null)
        {
            Status = (int)maintenanceCharge.Status;
            StatusDesc = EnumExtensions.GetEnumDescription(maintenanceCharge.Status);
            return;
        }

        Status = 0;
        StatusDesc = string.Empty;
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