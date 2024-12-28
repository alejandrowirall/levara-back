
using Levara.Shared.Domain.Bus.Events;

namespace Levara.Domain.Events;

public class BankAccountSyncJobCreated : DomainEvent
{
    public BankAccountSyncJobCreated() { }

    public BankAccountSyncJobCreated(int entityId, Guid eventId, DateTime? occurredOn = null)
        : base(entityId, eventId, occurredOn)
    {
    }
    public override string EventName()
    {
        return "bank.account.sync.job.created";
    }

    public override DomainEvent FromPrimitives(int entityId, Dictionary<string, string> body, Guid eventId, DateTime occurredOn)
    {
        return new BankAccountSyncJobCreated(entityId, eventId, occurredOn);
    }

    public override Dictionary<string, string> ToPrimitives()
    {
        return new Dictionary<string, string>();
    }
}
