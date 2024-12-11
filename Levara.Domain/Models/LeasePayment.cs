

namespace Levara.Domain.Models
{
    public class LeasePayment : Entity
    {
        public int TransactionId { get; set; }
        public Transaction Transaction {  get; set; }
        public int LeaseId { get; set; }
        public Lease Lease { get; set; }
    }
}
