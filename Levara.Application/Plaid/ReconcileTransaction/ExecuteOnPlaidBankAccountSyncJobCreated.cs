using Levara.Application.Plaid.ReconcileTransaction;
using Levara.Domain.Events;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Domain.Bus.Events;
using Levara.Shared.Results;

namespace Levara.Application.Plaid.GetTransactionsOwnerFromPlaid;

public class ExecuteOnPlaidTransactionCreated : IDomainEventSubscriber<PlaidTransactionCreated>
{
    private readonly ICommandBus _commandBus;

    public ExecuteOnPlaidTransactionCreated(ICommandBus commandBus) 
    {
        _commandBus = commandBus;
    }

    public async Task<OperationResult<bool>> On(PlaidTransactionCreated domainEvent)
    {
        ReconcileTransactionCommand command = new ()
        {
            PlaidId = domainEvent.EntityId
        };

        var response = await _commandBus.Dispatch(command);
        if (!response.Success)
            return OperationResult<bool>.ErrorResult(response.Error!);

        return OperationResult<bool>.SuccessResult(true);

    }
}


