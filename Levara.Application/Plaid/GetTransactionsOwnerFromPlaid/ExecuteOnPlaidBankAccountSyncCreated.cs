using Levara.Domain.Events;
using Levara.Shared.Domain.Bus.Events;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Plaid.GetTransactionsOwnerFromPlaid;

public class ExecuteOnPlaidBankAccountSyncCreated : IDomainEventSubscriber<PlaidBankAccountSyncCreated>
{
    private readonly IQueryBus _queryBus;

    public ExecuteOnPlaidBankAccountSyncCreated(IQueryBus queryBus) 
    {
        _queryBus = queryBus;
    }

    public async Task<OperationResult<bool>> On(PlaidBankAccountSyncCreated domainEvent)
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


