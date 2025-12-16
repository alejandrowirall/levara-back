
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.RecurringCharges.GetRLeaseChargeForUpdate
{
    public class GetRLeaseChargeForUpdateQuery : Query<GetRLeaseChargeForUpdateQueryResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? Id { get; set; }
    }
}
