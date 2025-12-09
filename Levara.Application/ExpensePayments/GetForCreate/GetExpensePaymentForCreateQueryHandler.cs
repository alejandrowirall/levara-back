
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.ExpensePayments.GetForCreate;

//TODO We still don't know if we will need this service.
public class GetExpensePaymentForCreateQueryHandler : IQueryHandler<GetExpensePaymentForCreateQuery, GetExpensePaymentForCreateQueryResponse>
{
    public GetExpensePaymentForCreateQueryHandler() 
    {
    }
    public Task<OperationResult<GetExpensePaymentForCreateQueryResponse>> Handle(GetExpensePaymentForCreateQuery query)
    {
        GetExpensePaymentForCreateQueryResponse response = new();
        
        return Task.FromResult(OperationResult<GetExpensePaymentForCreateQueryResponse>.SuccessResult(response));
    }
}
