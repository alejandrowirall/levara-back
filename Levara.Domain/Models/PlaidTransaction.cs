using Levara.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levara.Domain.Models
{
    public class PlaidTransaction:Entity
    {
        public string TransactionId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public double? Amount { get; set; }

        public PlaidTransactionStatus Status { get; set; }
    }
}
