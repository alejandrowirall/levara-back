
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Plaid.GetForUpdate
{
    public class GetPlaidTransactionForUpdateQuery : Query<GetPlaidTransactionForUpdateQueryResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? PlaidId { get; set; }

        [Range(1, int.MaxValue)]
        public int? OwnerId { get; set; }
    }
}
