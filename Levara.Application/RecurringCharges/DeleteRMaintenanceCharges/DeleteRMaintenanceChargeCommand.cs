
using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.RecurringCharges.DeleteRMaintenanceCharges
{
    public class DeleteRMaintenanceChargeCommand : Command<DeleteRMaintenanceChargeCommandResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? Id { get; set; }
    }
}
