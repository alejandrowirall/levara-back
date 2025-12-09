
using Levara.Application.JobScheduler.Schedule;
using Levara.Domain.DAL;
using Levara.Domain.Events;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Domain.Bus.Events;
using Levara.Shared.Results;

namespace Levara.Application.OwnersBankAccounts.Sync;

public class ExecuteOnJobSchedulerCreated : IDomainEventSubscriber<JobSchedulerCreated>
{
    private readonly ICommandBus _commandBus;
    public ExecuteOnJobSchedulerCreated(ICommandBus commandBus) 
    {
        _commandBus = commandBus;
    }

    public async Task<OperationResult<bool>> On(JobSchedulerCreated domainEvent)
    {
        var command = new ScheduleJobsCommand()
        {
        };

        var response = await _commandBus.Dispatch(command);
        if(!response.Success)
            return OperationResult<bool>.ErrorResult(response.Error!);

        return OperationResult<bool>.SuccessResult(true);
    }
}
