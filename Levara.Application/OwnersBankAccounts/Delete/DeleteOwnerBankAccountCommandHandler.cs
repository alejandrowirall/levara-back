using Levara.Domain.Contexts;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.OwnersBankAccounts.Delete;

public class DeleteOwnerBankAccountCommandHandler : ICommandHandler<DeleteOwnerBankAccountCommand, DeleteOwnerBankAccountCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;
    private readonly IOwnerBankAccountRepository _ownerBankAccountRepository;
    public DeleteOwnerBankAccountCommandHandler(IUnitOfWork unitOfWork,
        IUserContext userContext,
        IOwnerBankAccountRepository ownerBankAccountRepository) 
    {
        _unitOfWork = unitOfWork;
        _userContext = userContext;
        _ownerBankAccountRepository = ownerBankAccountRepository;
    }
    public async Task<OperationResult<DeleteOwnerBankAccountCommandResponse>> Handle(DeleteOwnerBankAccountCommand command)
    {
        OwnerBankAccount? ownerBankAccount = await _ownerBankAccountRepository.GetByIdAsync(command.Id!.Value);
        if (ownerBankAccount == null)
            return OperationResult<DeleteOwnerBankAccountCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        if(_userContext.IsOwner && ownerBankAccount.OwnerId != _userContext.OwnerId!.Value)
            return OperationResult<DeleteOwnerBankAccountCommandResponse>.ErrorResult(new ErrorDetails(403, "The owner does not have permissions to delete this bank account."));

        await _unitOfWork.ExecuteAsTransactionAsync(() =>
        {
            _ownerBankAccountRepository.Delete(ownerBankAccount);

            return Task.CompletedTask;
        });

        var response = new DeleteOwnerBankAccountCommandResponse
        {
            Id = ownerBankAccount.Id
        };

        return OperationResult<DeleteOwnerBankAccountCommandResponse>.SuccessResult(response);
    }
}
