
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.OwnersBankAccounts.GetForCreate;

//TODO We still don't know if we will need this service.
public class GetOwnerBankAccountForCreateQueryHandler : IQueryHandler<GetOwnerBankAccountForCreateQuery, GetOwnerBankAccountForCreateQueryResponse>
{
    public GetOwnerBankAccountForCreateQueryHandler() 
    {
    }
    public Task<OperationResult<GetOwnerBankAccountForCreateQueryResponse>> Handle(GetOwnerBankAccountForCreateQuery query)
    {
        GetOwnerBankAccountForCreateQueryResponse response = new();
        
        return Task.FromResult(OperationResult<GetOwnerBankAccountForCreateQueryResponse>.SuccessResult(response));
    }
}
