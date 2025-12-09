using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.LeasePayments.Create;

public class CreateLeasePaymentCommand : Command<CreateLeasePaymentCommandResponse>
{
    [Required]
    [Range(1, int.MaxValue)]
    public int? OwnerId { get; set; }


    [Range(1, int.MaxValue)]
    public int? TransactionId { get; set; }

    [Required]
    [Range(1, double.MaxValue)]
    public decimal? Amount { get; set; }

    public CreateLeaseCharge? CreateLeaseCharge { get; set; }

    public DateTime? Date { get; set; }
}

public class CreateLeaseCharge
{
    [Required]
    public string Description { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? LeaseId { get; set; }
}
