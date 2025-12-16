
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.RecurringCharges.GetRExpenseChargeForCreate
{
    public class GetRExpenseChargeForCreateQuery : Query<GetRExpenseChargeForCreateQueryResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? PropertyId { get; set; }
    }
}
