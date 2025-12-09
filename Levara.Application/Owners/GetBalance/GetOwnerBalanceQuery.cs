
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Owners.GetBalance
{
    public class GetOwnerBalanceQuery : Query<GetOwnerBalanceQueryResponse>
    {
        [Range(1, int.MaxValue)]
        public int? Id { get; set; }
    }
}
