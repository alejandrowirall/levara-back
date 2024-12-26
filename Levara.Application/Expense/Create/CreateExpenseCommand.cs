
using Levara.Application.Expenses.Create;
using Levara.Application.Transactions.Create;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Levara.Application.Expenses.Create
{
    public class CreateExpenseCommand : Command<CreateExpenseCommandResponse>
    {

        public string Title { get; set; }

        [Required]
        [Length(1, 200)]
        public string Description { get; set; }

        public int TypeId { get; set; }
        public ExpenseType Type { get; set; }

        public ExpenseStatus Status { get; set; }

        public DateTime DueDate { get; set; }

        public int PropertyId { get; set; }

        public Property Property { get; set; }


    }
}
