
using System.ComponentModel.DataAnnotations;

namespace Levara.Domain.Models
{
    public class RecurringChargeInstance : Entity
    {
        [Required]
        public int RecurringChargeId { get; set; }

        [Required]
        public RecurringCharge RecurringCharge { get; set; }

        [Required]
        public int? TransactionId { get; set; }

        [Required]
        public Transaction? Transaction { get; set; }
    }
}
