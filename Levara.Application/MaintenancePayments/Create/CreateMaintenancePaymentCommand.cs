using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.MaintenancePayments.Create;

public class CreateMaintenancePaymentCommand : Command<CreateMaintenancePaymentCommandResponse>
{
    [Range(1, int.MaxValue)]
    public int? OwnerId { get; set; }

    [Range(1, int.MaxValue)]
    public int? TransactionId { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal? Amount { get; set; }
    public DateTime? Date { get; set; }
    public CreateMaintenance? CreateMaintenance { get; set; }

}

public class CreateMaintenance
{
    [Required]
    [Length(1, 200)]
    public string Title { get; set; }

    [Required]
    [Length(1, 200)]
    public string Description { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? TypeId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? PropertyId { get; set; }
}
