
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.RecurringCharges.GetRMaintenanceChargeForUpdate
{
    public class GetRMaintenanceChargeForUpdateQuery : Query<GetRMaintenanceChargeForUpdateQueryResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? Id { get; set; }
    }
}
