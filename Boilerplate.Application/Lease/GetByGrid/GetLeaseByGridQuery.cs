
using Boilerplate.Domain.Enum;
using Boilerplate.Domain.Models;
using Boilerplate.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Application.Leases.GetByGrid
{
    public class GetLeaseByGridQuery : Query<PagedList<GetLeaseByGridQueryResponse>>
    {
        [Range(1, int.MaxValue)]
        public int? OwnerId { get; set; }

        [Range(1, int.MaxValue)]
        public int? TenantId { get; set; }

        [Range(1, int.MaxValue)]
        public int? PropertyId { get; set; }


        [Required]
        [Range(1, int.MaxValue)]
        public int? PageNumber { get; set; } = 1;
        
        [Required]
        [Range(1, int.MaxValue)]
        public int? PageSize { get; set; } = 10;
    }
}
