using Levara.Domain.Enum;

namespace Levara.Domain.Models
{
    public class LeasePayment : Entity
    {
        public int TransactionId { get; set; }
        public Transaction Transaction {  get; set; }
        public int LeaseId { get; set; }
        public Lease Lease { get; set; }

        public static Transaction CreateTransaction(int propertyId,
            decimal amount,
            int leaseId,
            string description,
            decimal currentRunningBalance,
            decimal currentLeaseRunningBalance,
            DateTime? date = null
            )
        {
            return new Transaction
            {
                Type = TransactionType.Lease,
                SubType = TransactionSubType.Payment,
                PropertyId = propertyId,
                LeaseId = leaseId,
                Amount = amount,
                Date = date ?? DateTime.UtcNow,
                Description = $"Lease payment {description}",
                RunningBalance = currentRunningBalance + amount,
                LeaseRunningBalance = currentLeaseRunningBalance + amount,
                Status = TransactionStatus.Confirmed,
                DueDate = null
            };
        }
    }
}
