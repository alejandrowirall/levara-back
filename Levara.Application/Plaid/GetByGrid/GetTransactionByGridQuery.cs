using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Plaid.GetByGrid;

public class GetTransactionByGridQuery : Query<PagedList<GetTransactionByGridQueryResponse>>
{
    [Range(1, int.MaxValue)]
    public int? OwnerId { get; set; }

    [Range(1, int.MaxValue)]
    public int? BankAccountId { get; set; }

    public PlaidTransactionStatus? Status { get; set; }

    public DateTime? DateFrom { get; set; }

    public DateTime? DateTo { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? PageNumber { get; set; } = 1;

    [Required]
    [Range(1, int.MaxValue)]
    public int? PageSize { get; set; } = 10;
}


