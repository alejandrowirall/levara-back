
using Boilerplate.Domain.DAL.Repositories;
using Boilerplate.Domain.Models;
using Boilerplate.Shared.Domain.Bus.Queries;
using Boilerplate.Shared.Results;

namespace Boilerplate.Application.OwnersBankAccounts.GetByGrid;

public class GetOwnerBankAccountsByGridQueryHandler : IQueryHandler<GetOwnerBankAccountsByGridQuery, PagedList<GetOwnerBankAccountsByGridQueryResponse>>
{
    private readonly IOwnerBankAccountRepository _ownerBankAccountRepository;
    public GetOwnerBankAccountsByGridQueryHandler(IOwnerBankAccountRepository ownerBankAccountRepository) 
    {
        _ownerBankAccountRepository = ownerBankAccountRepository;
    }
    public async Task<OperationResult<PagedList<GetOwnerBankAccountsByGridQueryResponse>>> Handle(GetOwnerBankAccountsByGridQuery query)
    {

        var ownerBankAccountQuery = _ownerBankAccountRepository.GetAll()
                                                               .Where(oba => oba.OwnerId == query.OwnerId!.Value)
                                                               .OrderByDescending(oba => oba.CreatedDate)
                                                               .Select(oba => new GetOwnerBankAccountsByGridQueryResponse(oba));

        var response = await _ownerBankAccountRepository.ToListPagedAsync(ownerBankAccountQuery, query.PageNumber!.Value, query.PageSize!.Value);


        return OperationResult<PagedList<GetOwnerBankAccountsByGridQueryResponse>>.SuccessResult(response);

    }
}


