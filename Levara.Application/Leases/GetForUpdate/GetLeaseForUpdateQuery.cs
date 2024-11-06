
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Leases.GetForUpdate;

public class GetLeaseForUpdateQuery : Query<GetLeaseForUpdateQueryResponse>
{
    [Required]
    [Range(1, int.MaxValue)]
    public int? Id { get; set; }
}
