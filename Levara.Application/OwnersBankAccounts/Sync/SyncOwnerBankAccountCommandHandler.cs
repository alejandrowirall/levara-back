
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.OwnersBankAccounts.Sync;

public class SyncOwnerBankAccountCommandHandler : ICommandHandler<SyncOwnerBankAccountCommand, SyncOwnerBankAccountCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOwnerBankAccountRepository _ownerBankAccountRepository;
    public SyncOwnerBankAccountCommandHandler(IUnitOfWork unitOfWork,
        IOwnerBankAccountRepository ownerBankAccountRepository) 
    {
        _unitOfWork = unitOfWork;
        _ownerBankAccountRepository = ownerBankAccountRepository;
    }
    public async Task<OperationResult<SyncOwnerBankAccountCommandResponse>> Handle(SyncOwnerBankAccountCommand command)
    {
        var response = new SyncOwnerBankAccountCommandResponse
        {
            Id = command.Id!.Value
        };

        return OperationResult<SyncOwnerBankAccountCommandResponse>.SuccessResult(response);

    }
}
