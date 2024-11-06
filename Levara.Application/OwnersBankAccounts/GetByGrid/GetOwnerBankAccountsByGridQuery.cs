
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.OwnersBankAccounts.GetByGrid
{
    public class GetOwnerBankAccountsByGridQuery : Query<PagedList<GetOwnerBankAccountsByGridQueryResponse>>
    {
        [Range(1, int.MaxValue)]
        public int? OwnerId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? PageNumber { get; set; } = 1;
        
        [Required]
        [Range(1, int.MaxValue)]
        public int? PageSize { get; set; } = 10;
    }
}
