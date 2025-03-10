
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.LeaseCharges.GetByGrid
{
    public class GetLeaseChargeByGridQuery : Query<PagedList<GetLeaseChargeByGridQueryResponse>>
    {
        [Range(1, int.MaxValue)]
        public int? OwnerId { get; set; }


        [Range(1, int.MaxValue)]
        public int? PropertyId { get; set; }

        public LeaseChargeStatus[]? Statuses { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? PageNumber { get; set; } = 1;
        
        [Required]
        [Range(1, int.MaxValue)]
        public int? PageSize { get; set; } = 10;
    }
}
