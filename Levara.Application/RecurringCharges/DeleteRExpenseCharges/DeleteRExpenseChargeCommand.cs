
using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.RecurringCharges.DeleteRExpenseCharges
{
    public class DeleteRExpenseChargeCommand : Command<DeleteRExpenseChargeCommandResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? Id { get; set; }
    }
}
