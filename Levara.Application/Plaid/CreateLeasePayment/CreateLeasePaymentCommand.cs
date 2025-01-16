using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Plaid.CreateLeasePayment;

public class CreateLeasePaymentCommand : Command<CreateLeasePaymentCommandResponse>
{
    [Required]
    [Range(1, int.MaxValue)]
    public int? PlaidId {  get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? OwnerId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? LeaseChargeId { get; set; }

    [Required]
    [Range(1, Double.MaxValue)]
    public decimal? Amount { get; set; }

}
