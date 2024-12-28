
using Levara.Application.JobScheduler.Schedule;
using Levara.Domain.DAL;
using Levara.Domain.Events;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Domain.Bus.Events;

namespace Levara.Application.OwnersBankAccounts.Sync;

public class ExecuteOnJobSchedulerCreated : IDomainEventSubscriber<JobSchedulerCreated>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICommandBus _commandBus;
    public ExecuteOnJobSchedulerCreated(IUnitOfWork unitOfWork,
        ICommandBus commandBus) 
    {
        _unitOfWork = unitOfWork;
        _commandBus = commandBus;
    }

    public async Task On(JobSchedulerCreated domainEvent)
    {
        var command = new ScheduleJobsCommand()
        {
        };

        await _commandBus.Dispatch(command);
    }
}
