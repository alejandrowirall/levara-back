
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Transactions.GetForCreate;

//TODO We still don't know if we will need this service.
public class GetTransactionForCreateQueryHandler : IQueryHandler<GetTransactionForCreateQuery, GetTransactionForCreateQueryResponse>
{
    public GetTransactionForCreateQueryHandler() 
    {
    }
    public Task<OperationResult<GetTransactionForCreateQueryResponse>> Handle(GetTransactionForCreateQuery query)
    {
        GetTransactionForCreateQueryResponse response = new();
        
        return Task.FromResult(OperationResult<GetTransactionForCreateQueryResponse>.SuccessResult(response));
    }
}
