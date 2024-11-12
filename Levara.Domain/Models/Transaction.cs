using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levara.Domain.Models
{
    public class Transaction : Entity
    {
        public int TransactionTypeId { get; set; }
        public TransactionType TransactionType { get; set; }
        public int OwnerId { get; set; }

        [Required]
        public Owner Owner { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TransactionDetail> TransactionDetails { get; set; }

        public Transaction()
        {
            TransactionDetails = new HashSet<TransactionDetail>();
        }
    }
}
