using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.ExpensePayments.Create;

public class CreateExpensePaymentCommand : Command<CreateExpensePaymentCommandResponse>
{

    [Required]
    [Range(1, int.MaxValue)]
    public int? OwnerId { get; set; }

    [Range(1, int.MaxValue)]
    public int? ExpenseChargeId { get; set; }

    [Required]
    [Range(1, double.MaxValue)]
    public decimal? Amount { get; set; }

    public DateTime? Date { get; set; }
    public CreateExpenseCharge? CreateExpenseCharge { get; set; }

}

public class CreateExpenseCharge
{
    [Range(1, int.MaxValue)]
    public int? ExpenseId { get; set; }


    [Range(1, int.MaxValue)]
    public int? PropertyId { get; set; }
}
