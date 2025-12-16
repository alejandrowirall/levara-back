
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.RecurringCharges.GetRMaintenanceChargeForCreate
{
    public class GetRMaintenanceChargeForCreateQuery : Query<GetRMaintenanceChargeForCreateQueryResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? PropertyId { get; set; }
    }
}
