
using Levara.Domain.Models;

namespace Levara.Domain.Events;

public class JobSchedulerCreated : DomainEvent
{
    public JobSchedulerCreated() { }

    public JobSchedulerCreated(Guid id, int entityId, DateTime occurredOn)
        : base(id, entityId, occurredOn)
    { 
    }
    
}
