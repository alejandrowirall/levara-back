


using Levara.Domain.Models;

namespace Levara.Domain.Events;

public class PlaidBankAccountSyncJobCreated : DomainEvent
{
    public PlaidBankAccountSyncJobCreated() { }

    public PlaidBankAccountSyncJobCreated( Guid id, int entityId, DateTime? occurredOn = null)
        : base(id, entityId, occurredOn)
    {
    }

}
