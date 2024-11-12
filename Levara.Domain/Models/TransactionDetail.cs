using Levara.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levara.Domain.Models
{
    public class TransactionDetail:Entity
    {
        [ForeignKey("Transaction")]
        public int TransactionId { get; set; }

        public string ReceiptNumber { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
        public ReceiptType ReceiptType { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public string Description { get; set; }

        // Navigation property to link to the Transaction entity
        public virtual Transaction Transaction { get; set; }
    }
}
