
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.ExpenseCharges.GetForCreate;

//TODO We still don't know if we will need this service.
public class GetExpenseChargeForCreateQueryHandler : IQueryHandler<GetExpenseChargeForCreateQuery, GetExpenseChargeForCreateQueryResponse>
{
    public GetExpenseChargeForCreateQueryHandler() 
    {
    }
    public Task<OperationResult<GetExpenseChargeForCreateQueryResponse>> Handle(GetExpenseChargeForCreateQuery query)
    {
        GetExpenseChargeForCreateQueryResponse response = new();
        
        return Task.FromResult(OperationResult<GetExpenseChargeForCreateQueryResponse>.SuccessResult(response));
    }
}
