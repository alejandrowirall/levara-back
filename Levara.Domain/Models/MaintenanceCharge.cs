using Levara.Domain.Enum;

namespace Levara.Domain.Models;

public class MaintenanceCharge : Entity
{
    public int TransactionId { get; set; }
    public Transaction Transaction { get; set; }

    public DateTime DueDate {  get; set; }

    public int MaintenanceId { get; set; }

    public Maintenance Maintenance { get; set; }

    public MaintenanceChargeStatus Status { get; set; }

}
