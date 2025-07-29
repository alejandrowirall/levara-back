using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Plaid.CreateExpensePayment;

public class CreateExpensePaymentCommand : Command<CreateExpensePaymentCommandResponse>
{
    [Required]
    [Range(1, int.MaxValue)]
    public int? PlaidId {  get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? OwnerId { get; set; }

    [Range(1, int.MaxValue)]
    public int? TransactionId { get; set; }

    [Required]
    [Range(1, double.MaxValue)]
    public decimal? Amount { get; set; }

    public CreateExpenseCharge? CreateExpenseCharge { get; set; }

}

public class CreateExpenseCharge
{
    [Range(1, int.MaxValue)]
    public int? ExpenseId { get; set; }


    [Range(1, int.MaxValue)]
    public int? PropertyId { get; set; }
}
