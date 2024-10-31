
using Boilerplate.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Application.Owners.GetDashboard
{
    public class GetOwnerDashboardQuery : Query<GetOwnerDashboardQueryResponse>
    {
        [Range(1, int.MaxValue)]
        public int? Id { get; set; }
    }
}
