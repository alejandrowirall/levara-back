using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Plaid.GetReconcileByGrid;

public class GetReconcileByGridQuery : Query<List<GetReconcileByGridQueryResponse>>
{
    [Required]
    [Range(1, int.MaxValue)]
    public int? PlaidId {  get; set; }

    [Range(1, int.MaxValue)]
    public int? OwnerId { get; set; }

}
