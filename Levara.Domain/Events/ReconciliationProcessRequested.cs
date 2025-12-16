using Levara.Domain.Models;

namespace Levara.Domain.Events;

public class ReconciliationProcessRequested : DomainEvent
{
    public ReconciliationProcessRequested() { }

    public ReconciliationProcessRequested(Guid id, int reconciliationProcessId, DateTime? occurredOn = null)
        : base(id, reconciliationProcessId, occurredOn)
    {
    }
}
