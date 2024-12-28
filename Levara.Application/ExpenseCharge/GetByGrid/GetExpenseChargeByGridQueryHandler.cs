
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.ExpenseCharges.GetByGrid;

public class GetExpenseChargeByGridQueryHandler : IQueryHandler<GetExpenseChargeByGridQuery, PagedList<GetExpenseChargeByGridQueryResponse>>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IExpenseChargeRepository _expenseChargeRepository;
    public GetExpenseChargeByGridQueryHandler(ITransactionRepository transactionRepository, IExpenseChargeRepository expenseChargeRepository) 
    {
        _transactionRepository = transactionRepository;
        _expenseChargeRepository = expenseChargeRepository;
    }
    public async Task<OperationResult<PagedList<GetExpenseChargeByGridQueryResponse>>> Handle(GetExpenseChargeByGridQuery query)
    {

        var transactionQuery = _expenseChargeRepository.GetAll()
                                               .Where(t => t.Expense.PropertyId == query.PropertyId!.Value || (t.Expense.Property.OwnerId == query.OwnerId!.Value))
                                               .OrderByDescending(p => p.CreatedDate)
                                               .Select(p => new GetExpenseChargeByGridQueryResponse(p));

        var response = await _transactionRepository.ToListPagedAsync(transactionQuery, query.PageNumber!.Value, query.PageSize!.Value);


        return OperationResult<PagedList<GetExpenseChargeByGridQueryResponse>>.SuccessResult(response);

    }
}


