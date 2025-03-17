
using Levara.Domain.Enum;
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Payments.SummaryByMonth
{
    public class GetPaymentsSummaryByMonthQuery : Query<GetPaymentsSummaryByMonthQueryResponse>
    {
        [Range(1, int.MaxValue)]
        public int? OwnerId { get; set; }

        [Range(1, int.MaxValue)]
        public int? PropertyId { get; set; }

        [Required]
        [MinLength(1)]
        public List<int> Years { get; set; } = new();

        public List<TransactionType> TransactionTypes { get; set; } = new();
    }
}
