using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Plaid.GetTransactionsOwnerFromPlaid;

public class GetTransactionsOwnerFromPlaidQuery : Query<GetTransactionsOwnerQueryFromPlaidResponse>
{
    [Range(1, int.MaxValue)]
    public int? OwnerId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? BankAccountId { get; set; }
}


