
using Boilerplate.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Application.Properties.GetForUpdate
{
    public class GetPropertyForUpdateQuery : Query<GetPropertyForUpdateQueryResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? Id { get; set; }
    }
}
