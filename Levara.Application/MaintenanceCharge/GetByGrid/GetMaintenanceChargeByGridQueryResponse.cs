
using Levara.Domain.Enum;
using Levara.Domain.Models;

namespace Levara.Application.MaintenancesCharges.GetByGrid;

public class GetMaintenanceChargeByGridQueryResponse
{
    public GetMaintenanceChargeByGridQueryResponse(MaintenanceCharge maintenanceCharge)
    {
        TransactionId = maintenanceCharge.TransactionId;
        Transaction = maintenanceCharge.Transaction;
        DueDate = maintenanceCharge.DueDate;
        MaintenanceId = maintenanceCharge.MaintenanceId;
        Lease = maintenanceCharge.Maintenance;
        Status = maintenanceCharge.Status;
    }

    public int TransactionId { get; set; }
    public Transaction Transaction { get; set; }

    public DateTime DueDate { get; set; }

    public int MaintenanceId { get; set; }

    public Maintenance Lease { get; set; }

    public MaintenanceChargeStatus Status { get; set; }
}