using Levara.Domain.Enum;
using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.External.SyncEntities;

public class SyncEntitiesCommand : Command<SyncEntitiesCommandResponse>
{
    [Required]
    public SyncOwnerData Owner { get; set; } = null!;

    [Required]
    public SyncTenantData Tenant { get; set; } = null!;

    [Required]
    public SyncPropertyData Property { get; set; } = null!;
}

// ── Owner ──────────────────────────────────────────────────────────────────
public class SyncOwnerData
{
    [Required, MaxLength(100)]
    public string ExternalId { get; set; } = null!;

    // Obligatorios solo si el Owner no existe todavía
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? CompanyName { get; set; }
    public string? Identification { get; set; }
    public IdentificationType? IdentificationType { get; set; }
    public PersonType? PersonType { get; set; }
    public string? MobilePhone { get; set; }
    public string? Email { get; set; }
    public string? Street { get; set; }
    public string? AdditionalLine { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
}

// ── Tenant ─────────────────────────────────────────────────────────────────
public class SyncTenantData
{
    [Required, MaxLength(100)]
    public string ExternalId { get; set; } = null!;

    // Obligatorios solo si el Tenant no existe todavía
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? CompanyName { get; set; }
    public string? Identification { get; set; }
    public IdentificationType? IdentificationType { get; set; }
    public PersonType? PersonType { get; set; }
    public string? MobilePhone { get; set; }
    public string? Email { get; set; }
    public string? Street { get; set; }
    public string? AdditionalLine { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
}

// ── Property ───────────────────────────────────────────────────────────────
public class SyncPropertyData
{
    [Required, MaxLength(100)]
    public string ExternalId { get; set; } = null!;

    // OwnerId se toma automáticamente del Owner resuelto en el handler
    // Obligatorios solo si la Property no existe todavía
    public string? Street { get; set; }
    public string? AdditionalLine { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public decimal? Price { get; set; }
    public int? RoomsQuantity { get; set; }
    public int? BathroomQuantity { get; set; }
    public decimal? AreaQuantity { get; set; }
    public bool? HasPool { get; set; }
    public bool? HasBalcony { get; set; }
    public bool? HasGarage { get; set; }
    public DateTime? AvailableFrom { get; set; }
    public int? OwnerBankAccountId { get; set; }
}
