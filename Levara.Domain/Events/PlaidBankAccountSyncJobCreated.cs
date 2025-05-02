


using Levara.Domain.Models;

namespace Levara.Domain.Events;

public class PlaidBankAccountSyncJobCreated : DomainEvent
{
    public PlaidBankAccountSyncJobCreated() { }

    public PlaidBankAccountSyncJobCreated( Guid id, int entityId, DateTime? occurredOn = null)
        : base(id, entityId, occurredOn)
    {
    }

    public int OwnerId
    {
        get => Data.ContainsKey(nameof(OwnerId)) ? Convert.ToInt32(Data[nameof(OwnerId)]) : 0;
        set => Data[nameof(OwnerId)] = value;
    }
    
}
