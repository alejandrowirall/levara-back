
using Levara.Domain.Models;

namespace Levara.Domain.Events;

public class DomainEventTestCreated : DomainEvent
{
    public DomainEventTestCreated() { }

    public DomainEventTestCreated(Guid id, int entityId,  DateTime occurredOn)
        : base(id, entityId, occurredOn)
    { 
    }
    
}
