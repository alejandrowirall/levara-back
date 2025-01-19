using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Domain.Models;
using Levara.Shared.Extensions;
using Levara.Shared.Results;

namespace Levara.Application.Expenses.GetForUpdate;

public class GetExpenseForUpdateQueryHandler : IQueryHandler<GetExpenseForUpdateQuery, GetExpenseForUpdateQueryResponse>
{
    private readonly IUserContext _userContext;
    private readonly IExpenseRepository _expenseRepository;
    public GetExpenseForUpdateQueryHandler(IUserContext userContext,
        IExpenseRepository expenseRepository) 
    {
        _userContext = userContext;
        _expenseRepository = expenseRepository;
    }
    public async Task<OperationResult<GetExpenseForUpdateQueryResponse>> Handle(GetExpenseForUpdateQuery query)
    {
        var expenseQuery = _expenseRepository.GetAll()
                                               .Where(p => p.Id == query.Id!.Value)
                                               .Select(p => new GetExpenseForUpdateQueryResponse(p));

        GetExpenseForUpdateQueryResponse? expense = await _expenseRepository.FirstOrDefaultAsync(expenseQuery);
        if (expense == null)
            return OperationResult<GetExpenseForUpdateQueryResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        
    
        
        return OperationResult<GetExpenseForUpdateQueryResponse>.SuccessResult(expense);

    }
}
