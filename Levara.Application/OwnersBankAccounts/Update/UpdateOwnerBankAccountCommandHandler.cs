
using Levara.Domain.Contexts;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.OwnersBankAccounts.Update;

//TODO: I don't think editing is necessary. Maybe to activate or deactivate it.
public class UpdateOwnerBankAccountCommandHandler : ICommandHandler<UpdateOwnerBankAccountCommand, UpdateOwnerBankAccountCommandResponse>
{
    private readonly IUserContext _userContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOwnerBankAccountRepository _ownerBankAccountRepository;
    public UpdateOwnerBankAccountCommandHandler(IUserContext userContext,
        IUnitOfWork unitOfWork,
        IOwnerBankAccountRepository ownerBankAccountRepository) 
    {
        _userContext = userContext;
        _unitOfWork = unitOfWork;
        _ownerBankAccountRepository = ownerBankAccountRepository;
    }
    public async Task<OperationResult<UpdateOwnerBankAccountCommandResponse>> Handle(UpdateOwnerBankAccountCommand command)
    {

        if (await _ownerBankAccountRepository.AnyAsync(oba => oba.BankName == command.BankName &&
                                                              oba.PlaidAccountId == command.PlaidAccountId &&
                                                              oba.Id != command.Id))
            return OperationResult<UpdateOwnerBankAccountCommandResponse>.ErrorResult(new ErrorDetails(400, "Errors"));

        OwnerBankAccount? ownerBankAccount = await _ownerBankAccountRepository.GetByIdAsync(command.Id!.Value);
        if(ownerBankAccount == null)
            return OperationResult<UpdateOwnerBankAccountCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        if (_userContext.IsOwner && ownerBankAccount.OwnerId != _userContext.OwnerId!.Value)
            return OperationResult<UpdateOwnerBankAccountCommandResponse>.ErrorResult(new ErrorDetails(403, "The owner does not have permissions to update this bank account."));

        ownerBankAccount.BankName = command.BankName!;
        ownerBankAccount.AccountNumberMasked = "****" + command.AccountNumber![^4..];
        ownerBankAccount.PlaidAccountId = command.PlaidAccountId!;

        await _unitOfWork.ExecuteAsTransactionAsync(() =>
        {
            _ownerBankAccountRepository.Update(ownerBankAccount);
            return Task.CompletedTask;
        });

        var response = new UpdateOwnerBankAccountCommandResponse
        {
            Id = ownerBankAccount.Id
        };

        return OperationResult<UpdateOwnerBankAccountCommandResponse>.SuccessResult(response);

    }
}
