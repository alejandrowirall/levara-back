
using Boilerplate.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Application.Owners.GetForUpdate
{
    public class GetOwnerForUpdateQuery : Query<GetOwnerForUpdateQueryResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? Id { get; set; }
    }
}
