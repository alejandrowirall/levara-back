
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.ExpenseCharges.GetByGrid;

public class GetExpenseChargeByGridQueryHandler : IQueryHandler<GetExpenseChargeByGridQuery, PagedList<GetExpenseChargeByGridQueryResponse>>
{
    private readonly IExpenseChargeRepository _expenseChargeRepository;
    public GetExpenseChargeByGridQueryHandler(IExpenseChargeRepository expenseChargeRepository) 
    {
        _expenseChargeRepository = expenseChargeRepository;
    }
    public async Task<OperationResult<PagedList<GetExpenseChargeByGridQueryResponse>>> Handle(GetExpenseChargeByGridQuery query)
    {

        var transactionQuery = _expenseChargeRepository.GetAllFull()
                                                       .Where(t => t.Transaction.PropertyId == query.PropertyId!.Value || 
                                                                  (t.Transaction.Property.OwnerId == query.OwnerId!.Value));

        if (query.Statuses != null && query.Statuses.Any())
            transactionQuery = transactionQuery.Where(t => query.Statuses.Contains(t.Status));

        var responseQuery = transactionQuery.OrderByDescending(e => e.CreatedDate)
                                            .Select(e => new GetExpenseChargeByGridQueryResponse(e));

        var response = await _expenseChargeRepository.ToListPagedAsync(responseQuery, query.PageNumber!.Value, query.PageSize!.Value);

        return OperationResult<PagedList<GetExpenseChargeByGridQueryResponse>>.SuccessResult(response);

    }
}


