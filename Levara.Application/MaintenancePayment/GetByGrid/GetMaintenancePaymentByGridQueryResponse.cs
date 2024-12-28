
using Levara.Domain.Enum;
using Levara.Domain.Models;

namespace Levara.Application.MaintenancesPayments.GetByGrid;

public class GetMaintenancePaymentByGridQueryResponse
{
    public GetMaintenancePaymentByGridQueryResponse(MaintenancePayment maintenancePayment)
    {
        TransactionId = maintenancePayment.TransactionId;
        Transaction = maintenancePayment.Transaction;
        MaintenanceId = maintenancePayment.MaintenanceId;
        Lease = maintenancePayment.Maintenance;
    }

    public int TransactionId { get; set; }
    public Transaction Transaction { get; set; }

   
    public int MaintenanceId { get; set; }

    public Maintenance Lease { get; set; }

}