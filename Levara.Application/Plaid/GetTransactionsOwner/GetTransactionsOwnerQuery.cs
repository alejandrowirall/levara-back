using Levara.Application.Owners.GetForCreate;
using Levara.Application.Plaid.GetLinkToken;
using Levara.Domain.Enum;
using Levara.Shared.Domain.Bus.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levara.Application.Plaid.GetTransactionsOwner
{
    public class GetTransactionsOwnerQuery : Query<List<GetTransactionsOwnerQueryResponse>>
    {
        public int OwnerId { get; set; }

        public PlaidTransactionStatus? Status { get; set; }
    }
    
}

