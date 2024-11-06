
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
    public int OwnerId { get; set; }

    [Range(1, int.MaxValue)]
    public int TenantId { get; set; }

    [Range(1, int.MaxValue)]
    public int PropertyId { get; set; }

    public FrequencyType Frequency { get; set; }

    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public decimal Price { get; set; }

}
