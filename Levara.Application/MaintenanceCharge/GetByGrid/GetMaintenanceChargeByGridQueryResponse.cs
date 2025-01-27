
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
        DueDate = maintenanceCharge.DueDate;
        MaintenanceId = maintenanceCharge.MaintenanceId;
        Lease = maintenanceCharge.Maintenance;
        Status = maintenanceCharge.Status;
        StatusDescription = EnumExtensions.GetEnumDescription(maintenanceCharge.Status);
    }

    public int Id { get; set; }
    public int TransactionId { get; set; }
    public Transaction Transaction { get; set; }
    public DateTime DueDate { get; set; }
    public int MaintenanceId { get; set; }
    public Maintenance Lease { get; set; }
    public MaintenanceChargeStatus Status { get; set; }
    public string StatusDescription { get; set; }
}