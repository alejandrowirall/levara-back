

using Levara.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Levara.Domain.Models;

public class Lease : Entity
{
    public int OwnerId { get; set; }

    [Required]
    public Owner Owner { get; set; }

    public int TenantId { get; set; }

    [Required]
    public Tenant Tenant { get; set; }

    public int PropertyId { get; set; }

    [Required]
    public Property Property { get; set; }

    [Required]
    public DateTime DateFrom { get; set; }

    [Required]
    public DateTime DateTo { get; set; }

    [Required]
    public FrequencyType Frequency { get; set; }

    [Required]
    public decimal Amount { get; set; }

    public LeaseStatus Status {  get; set; }

    public List<string>? MatchTags { get; set; } = new List<string>();

}
