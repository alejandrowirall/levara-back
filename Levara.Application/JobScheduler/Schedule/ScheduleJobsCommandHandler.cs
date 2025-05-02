using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Events;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Domain.Bus.Events;
using Levara.Shared.Results;

namespace Levara.Application.JobScheduler.Schedule;

public class ScheduleJobsCommandHandler : ICommandHandler<ScheduleJobsCommand, ScheduleJobsCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOwnerBankAccountRepository _ownerBankAccountRepository;
    private readonly IDomainEventRepository _domainEventRepository;
    private readonly IEventBus _eventBus;
    public ScheduleJobsCommandHandler(IUnitOfWork unitOfWork,
        IOwnerBankAccountRepository ownerBankAccountRepository,
        IDomainEventRepository domainEventRepository,
        IEventBus eventBus) 
    {
        _unitOfWork = unitOfWork;
        _ownerBankAccountRepository = ownerBankAccountRepository;
        _domainEventRepository = domainEventRepository;
        _eventBus = eventBus;
    }
    public async Task<OperationResult<ScheduleJobsCommandResponse>> Handle(ScheduleJobsCommand command)
    {
        var query = _ownerBankAccountRepository.GetAll().Select(account => new PlaidBankAccountSyncJobCreated(Guid.NewGuid(), account.Id, null) { OwnerId = account.OwnerId });

        var events = await _ownerBankAccountRepository.ToListAsync(query);

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _domainEventRepository.AddAsync([.. events]);
            await _eventBus.PublishAsync([.. events]);
        });

        return OperationResult<ScheduleJobsCommandResponse>.SuccessResult(new());

    }
}
