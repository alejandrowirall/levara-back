using Levara.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levara.Domain.Models
{
    public class BankTransaction : Entity
    {
        public string TransactionId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public double? Amount { get; set; }

        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public int? LeaseId { get; set; }
        public Lease? Lease { get; set; }

        public int OwnerBankAccountId { get; set; }
        public OwnerBankAccount OwnerBankAccount { get; set; }

        public double? RunningBalance { get; set; }

        public int PlaidIdTransaction { get; set; }
    }
}
