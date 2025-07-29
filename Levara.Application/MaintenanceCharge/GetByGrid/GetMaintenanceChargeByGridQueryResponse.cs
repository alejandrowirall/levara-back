
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Extensions;

namespace Levara.Application.MaintenancesCharges.GetByGrid;

public class GetMaintenanceChargeByGridQueryResponse
{
    public GetMaintenanceChargeByGridQueryResponse(MaintenanceCharge maintenanceCharge)
    {
        Id = maintenanceCharge.Id;
        TransactionId = maintenanceCharge.TransactionId;
        Transaction = maintenanceCharge.Transaction;
        DueDate = maintenanceCharge.Transaction.DueDate ?? DateTime.MinValue;
        MaintenanceId = maintenanceCharge.MaintenanceId;
        Lease = maintenanceCharge.Maintenance;
        Status = maintenanceCharge.Transaction.Status;
        StatusDescription = EnumExtensions.GetEnumDescription(maintenanceCharge.Transaction.Status);
    }

    public int Id { get; set; }
    public int TransactionId { get; set; }
    public Transaction Transaction { get; set; }
    public DateTime DueDate { get; set; }
    public int MaintenanceId { get; set; }
    public Maintenance Lease { get; set; }
    public TransactionStatus Status { get; set; }
    public string StatusDescription { get; set; }
}