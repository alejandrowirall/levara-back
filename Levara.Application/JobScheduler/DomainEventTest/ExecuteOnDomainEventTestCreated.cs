using Levara.Domain.Events;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Domain.Bus.Events;
using Levara.Shared.Results;

namespace Levara.Application.JobScheduler.DomainEventTest;

public class ExecuteOnDomainEventTestCreated : IDomainEventSubscriber<DomainEventTestCreated>
{
    private readonly ICommandBus _commandBus;
    public ExecuteOnDomainEventTestCreated(ICommandBus commandBus) 
    {
        _commandBus = commandBus;
    }

    public async Task<OperationResult<bool>> On(DomainEventTestCreated domainEvent)
    {
        var command = new DomainEventTestCommand()
        {
        };

        var response = await _commandBus.Dispatch(command);
        if (!response.Success)
            return OperationResult<bool>.ErrorResult(response.Error!);

        return OperationResult<bool>.SuccessResult(true);
    }
}
