
using Levara.Domain.DAL;
using Levara.Domain.Events;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Domain.Bus.Events;

namespace Levara.Application.OwnersBankAccounts.Sync;

public class ExecuteOnBankAccountSyncJobCreated : IDomainEventSubscriber<BankAccountSyncJobCreated>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICommandBus _commandBus;
    public ExecuteOnBankAccountSyncJobCreated(IUnitOfWork unitOfWork,
        ICommandBus commandBus) 
    {
        _unitOfWork = unitOfWork;
        _commandBus = commandBus;
    }

    public async Task On(BankAccountSyncJobCreated domainEvent)
    {
        var command = new SyncOwnerBankAccountCommand()
        {
            Id = domainEvent.EntityId,
        };

        await _commandBus.Dispatch(command);
    }
}
