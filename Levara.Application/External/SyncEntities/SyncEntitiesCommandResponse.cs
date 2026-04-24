namespace Levara.Application.External.SyncEntities;

public class SyncEntitiesCommandResponse
{
    public int OwnerId { get; set; }
    public bool OwnerCreated { get; set; }

    public int TenantId { get; set; }
    public bool TenantCreated { get; set; }

    public int PropertyId { get; set; }
    public bool PropertyCreated { get; set; }
}
