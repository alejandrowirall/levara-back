
using Levara.Domain.Enum;
using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Leases.Update;

public class UpdateLeaseCommand : Command<UpdateLeaseCommandResponse>
{
    [Required]
    [Range(1, int.MaxValue)]
    public int? Id {  get; set; }

    [Range(1, int.MaxValue)]
    public int? OwnerId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? TenantId { get; set; }

    [Required]
    public FrequencyType? Frequency { get; set; }

    [Required]
    public DateTime? DateFrom { get; set; }

    [Required]
    public DateTime? DateTo { get; set; }

    [Required]
    public decimal? Price { get; set; }

    [Required]
    public LeaseStatus? Status { get; set; }
    public List<string>? MatchTags { get; set; }
}
