
using Levara.Application.JobScheduler.Schedule;
using Levara.Domain.DAL;
using Levara.Domain.Events;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Domain.Bus.Events;

namespace Levara.Application.JobScheduler.DomainEventTest;

public class ExecuteOnDomainEventTestCreated : IDomainEventSubscriber<DomainEventTestCreated>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICommandBus _commandBus;
    public ExecuteOnDomainEventTestCreated(IUnitOfWork unitOfWork,
        ICommandBus commandBus) 
    {
        _unitOfWork = unitOfWork;
        _commandBus = commandBus;
    }

    public async Task On(DomainEventTestCreated domainEvent)
    {
        var command = new ScheduleJobsCommand()
        {
        };

        await _commandBus.Dispatch(command);
    }
}
