
using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Tenants.Delete
{
    public class DeleteTenantCommand : Command<DeleteTenantCommandResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? Id {  get; set; }
    }
}
