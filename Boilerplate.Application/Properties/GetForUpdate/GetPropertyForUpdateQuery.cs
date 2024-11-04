
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Properties.GetForUpdate
{
    public class GetPropertyForUpdateQuery : Query<GetPropertyForUpdateQueryResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? Id { get; set; }
    }
}
