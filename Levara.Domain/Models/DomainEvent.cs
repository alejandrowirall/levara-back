
using Levara.Domain.Enum;
using Levara.Shared.Domain.Bus.Events;

namespace Levara.Domain.Models;

public class DomainEvent : Entity, IDomainEvent
{
    public DomainEvent()
    {
        Name = GetType().Name;
    }

    public DomainEvent(Guid eventId, int? entityId, DateTime? occurredOn = null)
    {
        Name = GetType().Name;
        EventId = eventId;
        EntityId = entityId;
        OccurredOn = occurredOn ?? DateTime.UtcNow;
    }

    public Guid EventId { get; set; }
    public string Name { get; set; }
    public DomainEventStatus Status { get; set; } = DomainEventStatus.Created;
    public int? EntityId { get; set; }
    public DateTime OccurredOn { get; set; }
    public Dictionary<string, object> Data { get; set; } = new();

    
}
