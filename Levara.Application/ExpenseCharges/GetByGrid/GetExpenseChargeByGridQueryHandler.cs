
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

        var expenseChargeQuery = _expenseChargeRepository.GetAllFull();

        if (query.PropertyId.HasValue)
            expenseChargeQuery = expenseChargeQuery.Where(ec => ec.Transaction.PropertyId == query.PropertyId!.Value);

        if (query.OwnerId.HasValue)
            expenseChargeQuery = expenseChargeQuery.Where(ec => ec.Transaction.Property.OwnerId == query.OwnerId!.Value);

        if (query.Statuses != null && query.Statuses.Any())
            expenseChargeQuery = expenseChargeQuery.Where(ec => query.Statuses.Contains(ec.Transaction.Status));

        var responseQuery = expenseChargeQuery.OrderByDescending(ec => ec.CreatedDate)
                                              .Select(ec => new GetExpenseChargeByGridQueryResponse(ec));

        var response = await _expenseChargeRepository.ToListPagedAsync(responseQuery, query.PageNumber!.Value, query.PageSize!.Value);

        return OperationResult<PagedList<GetExpenseChargeByGridQueryResponse>>.SuccessResult(response);

    }
}


