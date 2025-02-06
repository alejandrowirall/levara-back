
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.BankTransactions.SummaryByMonth
{
    public class GetBankTransSummaryByMonthQuery : Query<GetBankTransSummaryByMonthQueryResponse>
    {
        [Range(1, int.MaxValue)]
        public int? OwnerId { get; set; }

        [Required]
        [Range(2000, 2100)]
        public int? Year { get; set; }

    }
}
