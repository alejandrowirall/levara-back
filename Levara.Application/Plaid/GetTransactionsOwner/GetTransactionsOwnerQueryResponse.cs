using Levara.Domain.Enum;
using Levara.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Levara.Application.Plaid.GetTransactionsOwner
{
    public class GetTransactionsOwnerQueryResponse
    {
        [JsonConstructor]
        public GetTransactionsOwnerQueryResponse(PlaidTransaction plaidtx)
        {
            Id = plaidtx.Id;
            TransactionId = plaidtx.TransactionId;
            Date = plaidtx.Date;
            Description = plaidtx.Description;
            Amount = plaidtx.Amount;
            Status = plaidtx.Status;
        }
        public int Id { get; set; }
        public string TransactionId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public double? Amount { get; set; }

        public PlaidTransactionStatus Status { get; set; }

    }
}
