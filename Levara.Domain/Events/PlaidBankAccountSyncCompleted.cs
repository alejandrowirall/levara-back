using Levara.Domain.Models;

namespace Levara.Domain.Events;

public class PlaidBankAccountSyncCompleted : DomainEvent
{
    public PlaidBankAccountSyncCompleted() { }

    public PlaidBankAccountSyncCompleted(Guid id, int ownerBankAccountId, DateTime? occurredOn = null)
        : base(id, ownerBankAccountId, occurredOn)
    {
    }

    public int NewTransactionsCount
    {
        get => Data.ContainsKey(nameof(NewTransactionsCount)) ? Convert.ToInt32(Data[nameof(NewTransactionsCount)]) : 0;
        set => Data[nameof(NewTransactionsCount)] = value;
    }
}
