
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Tenants.GetByGrid
{
    public class GetTenantsByGridQuery : Query<PagedList<GetTenantsByGridQueryResponse>>
    {
        [Required]
        public int? PageNumber { get; set; } = 1;
        
        [Required]
        public int? PageSize { get; set; } = 10;
    }
}
