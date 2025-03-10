
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Payments.SummaryByMonth
{
    public class GetPaymentsSummaryByMonthQuery : Query<GetPaymentsSummaryByMonthQueryResponse>
    {
        [Range(1, int.MaxValue)]
        public int? OwnerId { get; set; }

        [Required]
        [Range(2000, 2100)]
        public int? Year { get; set; }

    }
}
