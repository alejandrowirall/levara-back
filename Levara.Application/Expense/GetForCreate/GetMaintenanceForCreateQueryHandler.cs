
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Expenses.GetForCreate;

//TODO We still don't know if we will need this service.
public class GetExpensesForCreateQueryHandler : IQueryHandler<GetExpenseForCreateQuery, GetExpenseForCreateQueryResponse>
{
    public GetExpensesForCreateQueryHandler() 
    {
    }
    public Task<OperationResult<GetExpenseForCreateQueryResponse>> Handle(GetExpenseForCreateQuery query)
    {
        GetExpenseForCreateQueryResponse response = new();
        
        return Task.FromResult(OperationResult<GetExpenseForCreateQueryResponse>.SuccessResult(response));
    }
}
