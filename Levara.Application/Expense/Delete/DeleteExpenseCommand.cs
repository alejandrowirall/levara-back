
using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Expenses.Delete
{
    public class DeleteExpenseCommand : Command<DeleteExpenseCommandResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? Id {  get; set; }
    }
}
