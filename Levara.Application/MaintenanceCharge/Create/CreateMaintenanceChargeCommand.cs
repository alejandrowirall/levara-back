using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.MaintenancesCharges.Create;

public class CreateMaintenanceChargeCommand : Command<CreateMaintenanceChargeCommandResponse>
{

    [Required]
    [Range(1, int.MaxValue)]
    public int? PropertyId { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal? Amount { get; set; }

    public DateTime? Date { get; set; }

    [Required]
    public DateTime? DueDate { get; set; }

    [Required]
    public string? Title { get; set; }

    [Required]
    public string? Description { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? TypeId { get; set; }

}
