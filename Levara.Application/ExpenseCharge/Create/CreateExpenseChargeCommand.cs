using Levara.Shared.Domain.Bus.Commands;

namespace Levara.Application.ExpenseCharges.Create
{
    public class CreateExpenseChargeCommand : Command<CreateExpenseChargeCommandResponse>
    {

        public int PropertyId { get; set; }
       
        public int EntityId { get; set; }

        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int ExpenseId { get; set; }


    }
}
