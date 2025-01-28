
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Expenses.GetByGrid;

public class GetExpenseByGridQueryHandler : IQueryHandler<GetExpenseByGridQuery, PagedList<GetExpenseByGridQueryResponse>>
{
    private readonly IExpenseRepository _expenseRepository;
    public GetExpenseByGridQueryHandler(IExpenseRepository expenseRepository) 
    {
        _expenseRepository = expenseRepository;
    }
    public async Task<OperationResult<PagedList<GetExpenseByGridQueryResponse>>> Handle(GetExpenseByGridQuery query)
    {

        var expenseQuery = _expenseRepository.GetAll()
                                             .OrderByDescending(p => p.CreatedDate)
                                             .Select(p => new GetExpenseByGridQueryResponse(p));

        var response = await _expenseRepository.ToListPagedAsync(expenseQuery, query.PageNumber!.Value, query.PageSize!.Value);


        return OperationResult<PagedList<GetExpenseByGridQueryResponse>>.SuccessResult(response);

    }
}


