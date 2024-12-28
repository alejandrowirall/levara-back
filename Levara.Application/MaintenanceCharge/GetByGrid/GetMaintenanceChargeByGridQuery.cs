
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.MaintenancesCharges.GetByGrid
{
    public class GetMaintenanceChargeByGridQuery : Query<PagedList<GetMaintenanceChargeByGridQueryResponse>>
    {
        [Range(1, int.MaxValue)]
        public int? OwnerId { get; set; }


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
