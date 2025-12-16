using Levara.Application.Plaid.ReconcileTransaction;
using Levara.Domain.Events;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Domain.Bus.Events;
using Levara.Shared.Results;

namespace Levara.Application.Plaid.GetTransactionsOwnerFromPlaid;

public class ExecuteOnPlaidBankAccountSyncCompleted : IDomainEventSubscriber<PlaidBankAccountSyncCompleted>
{
    private readonly ICommandBus _commandBus;

    public ExecuteOnPlaidBankAccountSyncCompleted(ICommandBus commandBus) 
    {
        _commandBus = commandBus;
    }

    public async Task<OperationResult<bool>> On(PlaidBankAccountSyncCompleted domainEvent)
    {
        ReconcileTransactionCommand command = new ()
        {
            OwnerBankAccountId = domainEvent.EntityId
        };

        var response = await _commandBus.Dispatch(command);
        if (!response.Success)
            return OperationResult<bool>.ErrorResult(response.Error!);

        return OperationResult<bool>.SuccessResult(true);

    }
}


