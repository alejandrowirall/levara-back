using Levara.Application.Plaid.BankAccountSyncJob;
using Levara.Domain.Events;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Domain.Bus.Events;
using Levara.Shared.Results;

namespace Levara.Application.OwnersBankAccounts.Sync;

public class ExecuteOnPlaidBankAccountSyncJobCreated : IDomainEventSubscriber<PlaidBankAccountSyncJobCreated>
{
    private readonly ICommandBus _commandBus;
    public ExecuteOnPlaidBankAccountSyncJobCreated(ICommandBus commandBus) 
    {
        _commandBus = commandBus;
    }

    public async Task<OperationResult<bool>> On(PlaidBankAccountSyncJobCreated domainEvent)
    {
        var command = new CreateBankAccountSyncJobCommand()
        {
        };

        var response = await _commandBus.Dispatch(command);
        if(!response.Success)
            return OperationResult<bool>.ErrorResult(response.Error!);

        return OperationResult<bool>.SuccessResult(true);
    }
}
