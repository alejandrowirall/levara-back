using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Levara.Application.Plaid.GetTransactionsOwnerFromPlaid
{
    public class GetTransactionsOwnerQueryFromPlaidResponse
    {
        [JsonConstructor]
        public GetTransactionsOwnerQueryFromPlaidResponse(int total_Transactions)
        {
            Total_Transactions = total_Transactions;

        }
        
        public int Total_Transactions { get; set; }
        public string Request_id { get; set; }
        
    }
}
