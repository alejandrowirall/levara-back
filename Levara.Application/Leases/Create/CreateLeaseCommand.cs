
using Levara.Domain.Enum;
using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Leases.Create;

public class CreateLeaseCommand : Command<CreateLeaseCommandResponse>
{
    [Range(1, int.MaxValue)]
    public int? OwnerId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? TenantId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? PropertyId { get; set; }

    [Required]
    public FrequencyType? Frequency { get; set; }

    [Required]
    public DateTime? DateFrom { get; set; }

    [Required]
    public DateTime? DateTo { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal? Price { get; set; }

    [Required]
    public LeaseStatus? Status { get; set; }

}
