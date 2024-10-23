
using Boilerplate.Domain.Models;
using Boilerplate.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Application.Owners.GetByGrid
{
    public class GetOwnersByGridQuery : Query<PagedList<GetOwnersByGridQueryResponse>>
    {
        [Required]
        public int? PageNumber { get; set; } = 1;
        
        [Required]
        public int? PageSize { get; set; } = 10;
    }
}
