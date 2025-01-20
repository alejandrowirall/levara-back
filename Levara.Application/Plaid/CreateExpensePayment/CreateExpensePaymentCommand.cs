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

    [Required]
    [Range(1, int.MaxValue)]
    public int? ExpenseChargeId { get; set; }

    [Required]
    [Range(1, Double.MaxValue)]
    public decimal? Amount { get; set; }

}
