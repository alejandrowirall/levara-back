


using Levara.Domain.Models;

namespace Levara.Domain.Events;

public class PlaidTransactionCreated : DomainEvent
{
    public PlaidTransactionCreated() { }

    public PlaidTransactionCreated( Guid id, int entityId, DateTime? occurredOn = null)
        : base(id, entityId, occurredOn)
    {
    }
    
}
