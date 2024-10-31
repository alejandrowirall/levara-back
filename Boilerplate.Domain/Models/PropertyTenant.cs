

namespace Boilerplate.Domain.Models;

public class PropertyTenant : Entity
{
    public int PropertyId { get; set; }

    public required Property Property { get; set; }

    public int TenantId { get; set; }

    public required Tenant Tenant { get; set; }
}
