
using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.RecurringCharges.DeleteRLeaseCharges
{
    public class DeleteRLeaseChargeCommand : Command<DeleteRLeaseChargeCommandResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? Id { get; set; }
    }
}
