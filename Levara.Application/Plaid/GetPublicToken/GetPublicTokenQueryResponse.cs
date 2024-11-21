using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Levara.Application.Plaid.GetPublicToken
{
    public class GetPublicTokenQueryResponse
    {
        [JsonConstructor]
        public GetPublicTokenQueryResponse(string access_token, string item_id, string request_id)
        {
            Access_Token = access_token;
            Item_id = item_id;
            Request_id = request_id;

        }
        
        public string Access_Token { get; set; }
        public string Item_id { get; set; }
        public string Request_id { get; set; }
        
    }
}
