

namespace Levara.Shared.Domain.Bus.Events;

public abstract class DomainEvent
{
    public int EntityId { get; }
    public Guid EventId { get; }
    public DateTime OccurredOn { get; }

    protected DomainEvent(int entityId, Guid eventId, DateTime? occurredOn = null)
    {
        EntityId = entityId;
        EventId = eventId;
        OccurredOn = DateTime.UtcNow;
    }

    protected DomainEvent()
    {
    }

    public abstract string EventName();
    public abstract Dictionary<string, string> ToPrimitives();

    public abstract DomainEvent FromPrimitives(int entityId, Dictionary<string, string> body, Guid eventId,
        DateTime occurredOn);
}
