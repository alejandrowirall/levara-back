using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.RecurringCharges.GetRLeaseChargeByGrid
{
    public class GetRLeaseChargeByGridQuery : Query<PagedList<GetRLeaseChargeByGridQueryResponse>>
    {
        [Range(1, int.MaxValue)]
        public int? OwnerId { get; set; }

        public int[]? Ids { get; set; }


        [Range(1, int.MaxValue)]
        public int? PropertyId { get; set; }

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
