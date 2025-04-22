
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Owners.GetByGrid;

public class GetOwnersByGridQuery : Query<PagedList<GetOwnersByGridQueryResponse>>
{
    [Range(1, int.MaxValue)]
    public int? OwnerId { get; set; }

    [Required]
    public int? PageNumber { get; set; } = 1;
    
    [Required]
    public int? PageSize { get; set; } = 10;
}
