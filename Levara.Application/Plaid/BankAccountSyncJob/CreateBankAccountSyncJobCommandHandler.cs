
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Events;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Domain.Bus.Events;
using Levara.Shared.Results;

namespace Levara.Application.Plaid.BankAccountSyncJob;

public class CreateBankAccountSyncJobCommandHandler : ICommandHandler<CreateBankAccountSyncJobCommand, CreateBankAccountSyncJobCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOwnerBankAccountRepository _ownerBankAccountRepository;
    private readonly IDomainEventRepository _domainEventRepository;
    private readonly IEventBus _eventBus;
    public CreateBankAccountSyncJobCommandHandler(IUnitOfWork unitOfWork,
        IOwnerBankAccountRepository ownerBankAccountRepository,
        IDomainEventRepository domainEventRepository,
        IEventBus eventBus) 
    {
        _unitOfWork = unitOfWork;
        _ownerBankAccountRepository = ownerBankAccountRepository;
        _domainEventRepository = domainEventRepository;
        _eventBus = eventBus;
    }
    public async Task<OperationResult<CreateBankAccountSyncJobCommandResponse>> Handle(CreateBankAccountSyncJobCommand command)
    {
        //var startToday = DateTime.UtcNow.Date;
        //var endToday = DateTime.UtcNow.Date.AddDays(1).AddSeconds(-1);
        
        //var wasExecuted = await _domainEventRepository.AnyAsync(e => e.OccurredOn >= startToday &&
        //                                                             e.OccurredOn <= endToday &&
        //                                                             e.Name == typeof(PlaidBankAccountSyncJobCreated).Name);

        //if (wasExecuted)
        //    return OperationResult<CreateBankAccountSyncJobCommandResponse>.SuccessResult(new());

        var query = _ownerBankAccountRepository.GetAll().Select(account => new PlaidBankAccountSyncCreated(Guid.NewGuid(), account.Id, null) { OwnerId = account.OwnerId });

        var events = await _ownerBankAccountRepository.ToListAsync(query);

        var plaidBankAccountSyncEvent = new PlaidBankAccountSyncJobCreated(Guid.NewGuid(), 0);
        plaidBankAccountSyncEvent.Status = DomainEventStatus.Processed;

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _domainEventRepository.AddAsync([.. events, plaidBankAccountSyncEvent]);
            await _eventBus.PublishAsync([.. events]);
        });

        return OperationResult<CreateBankAccountSyncJobCommandResponse>.SuccessResult(new());

    }
}
