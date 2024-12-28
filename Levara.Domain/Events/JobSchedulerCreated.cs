
using Levara.Shared.Domain.Bus.Events;

namespace Levara.Domain.Events;

public class JobSchedulerCreated : DomainEvent
{
    public JobSchedulerCreated() { }

    public JobSchedulerCreated(int entityId, Guid eventId, DateTime occurredOn)
        : base(entityId, eventId, occurredOn)
    { 
    }
    public override string EventName()
    {
        return "job.scheduler.created";
    }

    public override DomainEvent FromPrimitives(int entityId, Dictionary<string, string> body, Guid eventId, DateTime occurredOn)
    {
        return new JobSchedulerCreated(entityId, eventId, occurredOn);
    }

    public override Dictionary<string, string> ToPrimitives()
    {
        return new Dictionary<string, string>();
    }
}
