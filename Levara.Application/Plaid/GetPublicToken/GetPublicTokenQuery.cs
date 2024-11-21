using Levara.Application.Owners.GetForCreate;
using Levara.Application.Plaid.GetLinkToken;
using Levara.Shared.Domain.Bus.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levara.Application.Plaid.GetPublicToken
{
    public class GetPublicTokenQuery : Query<GetPublicTokenQueryResponse>
    {
        public string Public_token { get; set; }
    }
    
}

