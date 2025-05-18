
namespace Levara.Domain.Models;

public class PlaidReconciliation : Entity
{
    public int TransactionId { get; set; }
    public Transaction Transaction { get; set; }
    public int PlaidTransactionId { get; set; }
    public PlaidTransaction PlaidTransaction { get; set; }
}
