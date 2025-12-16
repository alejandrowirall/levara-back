
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.RecurringCharges.GetRLeaseChargeForCreate
{
    public class GetRLeaseChargeForCreateQuery : Query<GetRLeaseChargeForCreateQueryResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? LeaseId { get; set; }
    }
}
