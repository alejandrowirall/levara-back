using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Extensions;
using System.Text.Json.Serialization;

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
            StatusDescription = EnumExtensions.GetEnumDescription(plaidtx.Status);
        }
        public int Id { get; set; }
        public string TransactionId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public decimal Amount { get; set; }

        public PlaidTransactionStatus Status { get; set; }

        public string StatusDescription { get; set; }

    }
}
