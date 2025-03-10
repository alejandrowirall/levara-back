
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.ExpensePayments.GetByGrid;

public class GetExpensePaymentByGridQueryHandler : IQueryHandler<GetExpensePaymentByGridQuery, PagedList<GetExpensePaymentByGridQueryResponse>>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IExpensePaymentRepository _expensePaymentRepository;
    public GetExpensePaymentByGridQueryHandler(ITransactionRepository transactionRepository, IExpensePaymentRepository expensePaymentRepository) 
    {
        _transactionRepository = transactionRepository;
        _expensePaymentRepository = expensePaymentRepository;
    }
    public async Task<OperationResult<PagedList<GetExpensePaymentByGridQueryResponse>>> Handle(GetExpensePaymentByGridQuery query)
    {

        var transactionQuery = _expensePaymentRepository.GetAll()
                                               .Where(t => t.Transaction.PropertyId == query.PropertyId!.Value || 
                                                          (t.Transaction.Property.OwnerId == query.OwnerId!.Value))
                                               .OrderByDescending(p => p.CreatedDate)
                                               .Select(p => new GetExpensePaymentByGridQueryResponse(p));

        var response = await _transactionRepository.ToListPagedAsync(transactionQuery, query.PageNumber!.Value, query.PageSize!.Value);


        return OperationResult<PagedList<GetExpensePaymentByGridQueryResponse>>.SuccessResult(response);

    }
}


