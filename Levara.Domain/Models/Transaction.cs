using Levara.Domain.Enum;

namespace Levara.Domain.Models
{
    public class Transaction : Entity
    {
        public TransactionType Type { get; set; }

        public TransactionSubType SubType { get; set; }
   
        public int PropertyId { get; set; }
        public Property Property { get; set; }

        public int EntityId { get; set; }

        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal RunningBalance { get; set; }
        public decimal EntityRunningBalance { get; set; }

    }
}
