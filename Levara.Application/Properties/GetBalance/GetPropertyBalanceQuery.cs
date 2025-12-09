
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Properties.GetBalance
{
    public class GetPropertyBalanceQuery : Query<GetPropertyBalanceQueryResponse>
    {

        [Range(1, int.MaxValue)]
        public int? OwnerId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? PropertyId { get; set; }
    }
}
