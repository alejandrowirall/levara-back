using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Expenses.Update
{
    public class UpdateExpenseCommand : Command<UpdateExpenseCommandResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? Id {  get; set; }

        [Required]
        [Length(1, 50)]
        public string Name { get; set; }

        [Required]
        [Length(1, 200)]
        public string Description { get; set; }
    }
}
