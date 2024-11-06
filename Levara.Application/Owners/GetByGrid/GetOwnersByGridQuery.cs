
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Owners.GetByGrid
{
    public class GetOwnersByGridQuery : Query<PagedList<GetOwnersByGridQueryResponse>>
    {
        [Required]
        public int? PageNumber { get; set; } = 1;
        
        [Required]
        public int? PageSize { get; set; } = 10;
    }
}
