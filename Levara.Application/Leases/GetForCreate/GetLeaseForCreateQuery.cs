
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Leases.GetForCreate;

public class GetLeaseForCreateQuery : Query<GetLeaseForCreateQueryResponse>
{
    [Range(1, int.MaxValue)]
    public int? OwnerId { get; set; }
}
