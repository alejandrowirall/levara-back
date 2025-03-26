using Levara.Application.Owners.GetForCreate;
using Levara.Application.Plaid.GetLinkToken;
using Levara.Shared.Domain.Bus.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levara.Application.Plaid.GetTransactionsOwnerFromPlaid;

public class GetTransactionsOwnerFromPlaidQuery : Query<GetTransactionsOwnerQueryFromPlaidResponse>
{
    [Range(1, int.MaxValue)]
    public int? OwnerId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? BankAccountId { get; set; }
}


