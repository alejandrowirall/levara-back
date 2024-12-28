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
    private readonly IDomainEventPrimitiveRepository _domainEventPrimitiveRepository;
    private readonly IEventBus _eventBus;
    public ScheduleJobsCommandHandler(IUnitOfWork unitOfWork,
        IOwnerBankAccountRepository ownerBankAccountRepository,
        IDomainEventPrimitiveRepository domainEventPrimitiveRepository,
        IEventBus eventBus) 
    {
        _unitOfWork = unitOfWork;
        _ownerBankAccountRepository = ownerBankAccountRepository;
        _domainEventPrimitiveRepository = domainEventPrimitiveRepository;
        _eventBus = eventBus;
    }
    public async Task<OperationResult<ScheduleJobsCommandResponse>> Handle(ScheduleJobsCommand command)
    {
        var query = _ownerBankAccountRepository.GetAll().Select(a => a.Id);

        var ownerBankAccountIds = await _ownerBankAccountRepository.ToListAsync(query);

        List<DomainEvent> events = new()
        {
            new DomainEventTestCreated(0, Guid.NewGuid(), DateTime.UtcNow),
        };
        
        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _domainEventPrimitiveRepository.AddAsync(events);
        });

        await _eventBus.PublishAsync(events);

        return OperationResult<ScheduleJobsCommandResponse>.SuccessResult(new());

    }
}
