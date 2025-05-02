using Levara.Domain.Events;
using Levara.Shared.Domain.Bus.Events;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Plaid.GetTransactionsOwnerFromPlaid;

public class ExecuteOnPlaidBankAccountSyncJobCreated : IDomainEventSubscriber<PlaidBankAccountSyncJobCreated>
{
    private readonly IQueryBus _queryBus;

    public ExecuteOnPlaidBankAccountSyncJobCreated(IQueryBus queryBus) 
    {
        _queryBus = queryBus;
    }

    public async Task<OperationResult<bool>> On(PlaidBankAccountSyncJobCreated domainEvent)
    {
        GetTransactionsOwnerFromPlaidQuery query = new ()
        {
            BankAccountId = domainEvent.EntityId,
            OwnerId = domainEvent.OwnerId
        };

        var response = await _queryBus.Ask(query);
        if (!response.Success)
            return OperationResult<bool>.ErrorResult(response.Error!);

        return OperationResult<bool>.SuccessResult(true);

    }
}


