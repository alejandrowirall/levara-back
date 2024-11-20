using Levara.Application.Owners.GetForCreate;
using Levara.Shared.Domain.Bus.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levara.Application.Plaid.GetLinkToken
{
    public class GetLinkTokenQuery : Query<GetLinkTokenQueryResponse>
    {
        public string ClientName { get; set; }
        public string ClientId { get; set; }
    }
    
}

