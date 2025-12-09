
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Transactions.GetByGrid
{
    public class GetTransactionsByGridQuery : Query<PagedList<GetTransactionsByGridQueryResponse>>
    {
        [Range(1, int.MaxValue)]
        public int? OwnerId { get; set; }


        [Range(1, int.MaxValue)]
        public int? PropertyId { get; set; }

        public TransactionType[]? Types { get; set; }

        public TransactionSubType[]? SubTypes { get; set; }

        public int[]? ChargeStatuses { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? PageNumber { get; set; } = 1;
        
        [Required]
        [Range(1, int.MaxValue)]
        public int? PageSize { get; set; } = 10;
    }
}
