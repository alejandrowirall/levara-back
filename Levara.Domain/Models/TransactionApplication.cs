namespace Levara.Domain.Models
{
    public class TransactionApplication : Entity
    {
        public int ChargeTransactionId { get; set; }

        public Transaction ChargeTransaction { get; set; }

        public int PaymentTransactionId { get; set; }

        public Transaction PaymentTransaction { get; set; }

        public decimal AppliedAmount { get; set; }

        public int PaymentId { get; set; }

        public Payment Payment { get; set; }
    }
}
