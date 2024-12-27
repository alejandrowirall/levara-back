
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.ExpenseCharges.GetByGrid
{
    public class GetExpenseChargeByGridQuery : Query<PagedList<GetExpenseChargeByGridQueryResponse>>
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
