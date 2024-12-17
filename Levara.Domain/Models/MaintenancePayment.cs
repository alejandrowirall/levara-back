

namespace Levara.Domain.Models;

public class MaintenancePayment : Entity
{
    public int TransactionId { get; set; }
    public Transaction Transaction {  get; set; }
    public int MaintenanceId { get; set; }
    public Maintenance Maintenance { get; set; }
}
