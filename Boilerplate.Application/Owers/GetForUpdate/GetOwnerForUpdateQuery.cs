
using Boilerplate.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Application.Owers.GetForUpdate
{
    public class GetOwnerForUpdateQuery : Query<GetOwnerForUpdateQueryResponse>
    {
        [Required]
        [Length(1, int.MaxValue)]
        public int? Id { get; set; }
    }
}
