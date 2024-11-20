using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Levara.Application.Plaid.GetLinkToken
{
    public class GetLinkTokenQueryResponse
    {
        [JsonConstructor]
        public GetLinkTokenQueryResponse (DateTime expiration, string linkToken, string request_id)
        {
            Expiration = expiration;
            Link_token = linkToken;
            Request_id = request_id;

        }
        public DateTime Expiration { get; set; }
        public string Link_token { get; set; }
        public string Request_id { get; set; }
    }
}
