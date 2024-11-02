
using Boilerplate.Domain.DAL;
using Boilerplate.Domain.DAL.Repositories;
using Boilerplate.Domain.Models;
using Boilerplate.Shared.Domain.Bus.Commands;
using Boilerplate.Shared.Results;

namespace Boilerplate.Application.OwnersBankAccounts.Create;

public class CreateOwnerBankAccountCommandHandler : ICommandHandler<CreateOwnerBankAccountCommand, CreateOwnerBankAccountCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOwnerBankAccountRepository _ownerBankAccountRepository;
    public CreateOwnerBankAccountCommandHandler(IUnitOfWork unitOfWork,
        IOwnerBankAccountRepository ownerBankAccountRepository) 
    {
        _unitOfWork = unitOfWork;
        _ownerBankAccountRepository = ownerBankAccountRepository;
    }
    public async Task<OperationResult<CreateOwnerBankAccountCommandResponse>> Handle(CreateOwnerBankAccountCommand command)
    {
        if (await _ownerBankAccountRepository.AnyAsync(oba => oba.BankName == command.BankName &&
                                                              oba.PlaidAccountId == command.PlaidAccountId))
            return OperationResult<CreateOwnerBankAccountCommandResponse>.ErrorResult(new ErrorDetails(400, "Errores"));

        OwnerBankAccount ownerBankAccount = new()
        {
            BankName = command.BankName!,
            AccountNumberMasked = "****" + command.AccountNumber![^4..],
            PlaidAccountId = command.PlaidAccountId!,
            OwnerId = command.OwnerId!.Value,
        };

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _ownerBankAccountRepository.AddAsync(ownerBankAccount);

        });

        var response = new CreateOwnerBankAccountCommandResponse
        {
            Id = ownerBankAccount.Id
        };

        return OperationResult<CreateOwnerBankAccountCommandResponse>.SuccessResult(response);

    }
}
