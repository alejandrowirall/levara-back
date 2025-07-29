
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Leases.GetTransactionByGrid
{
    public class GetLeaseTransactionByGridQuery : Query<PagedList<GetLeaseTransactionByGridQueryResponse>>
    {

        [Range(1, int.MaxValue)]
        public int? TenantId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? LeaseId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? PageNumber { get; set; } = 1;
        
        [Required]
        [Range(1, int.MaxValue)]
        public int? PageSize { get; set; } = 10;
    }
}
