using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.ExpenseCharges.Create
{
    public class CreateExpenseChargeCommand : Command<CreateExpenseChargeCommandResponse>
    {
        [Range(1, int.MaxValue)]
        public int? OwnerId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? PropertyId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal? Amount { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public DateTime? DueDate { get; set; }

        [Required]
        public int? ExpenseId { get; set; }


    }
}
