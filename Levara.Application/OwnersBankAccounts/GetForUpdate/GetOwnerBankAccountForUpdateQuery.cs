
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.OwnersBankAccounts.GetForUpdate
{
    public class GetOwnerBankAccountForUpdateQuery : Query<GetOwnerBankAccountForUpdateQueryResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? Id { get; set; }
    }
}
