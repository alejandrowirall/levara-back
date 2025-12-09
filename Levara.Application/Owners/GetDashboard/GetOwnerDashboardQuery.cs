
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Owners.GetDashboard
{
    public class GetOwnerDashboardQuery : Query<GetOwnerDashboardQueryResponse>
    {
        [Range(1, int.MaxValue)]
        public int? OwnerId { get; set; }
    }
}
