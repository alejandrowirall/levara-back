using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Expenses.Create
{
    public class CreateExpenseCommand : Command<CreateExpenseCommandResponse>
    {
        [Required]
        [Length(1, 50)]
        public string Name { get; set; }

        [Required]
        [Length(1, 200)]
        public string Description { get; set; }

    }
}
