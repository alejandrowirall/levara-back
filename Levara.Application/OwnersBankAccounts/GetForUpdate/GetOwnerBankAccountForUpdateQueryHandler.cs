using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.OwnersBankAccounts.GetForUpdate;

public class GetOwnerBankAccountForUpdateQueryHandler : IQueryHandler<GetOwnerBankAccountForUpdateQuery, GetOwnerBankAccountForUpdateQueryResponse>
{
    private readonly IUserContext _userContext;
    private readonly IOwnerBankAccountRepository _ownerBankAccountRepository;
    public GetOwnerBankAccountForUpdateQueryHandler(IUserContext userContext,
        IOwnerBankAccountRepository ownerBankAccountRepository) 
    {
        _userContext = userContext;
        _ownerBankAccountRepository = ownerBankAccountRepository;
    }
    public async Task<OperationResult<GetOwnerBankAccountForUpdateQueryResponse>> Handle(GetOwnerBankAccountForUpdateQuery query)
    {
        OwnerBankAccount? ownerBankAccount = await _ownerBankAccountRepository.GetByIdAsync(query.Id!.Value);
        if (ownerBankAccount == null)
            return OperationResult<GetOwnerBankAccountForUpdateQueryResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        if (_userContext.IsOwner && ownerBankAccount.OwnerId != _userContext.OwnerId!.Value)
            return OperationResult<GetOwnerBankAccountForUpdateQueryResponse>.ErrorResult(new ErrorDetails(403, "The owner does not have permissions to update this bank account."));

        GetOwnerBankAccountForUpdateQueryResponse response = new(new OwnerBankAccountUpdateQueryResponse(ownerBankAccount));
        
        return OperationResult<GetOwnerBankAccountForUpdateQueryResponse>.SuccessResult(response);

    }
}
