using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Transactions.GetByGrid;

public class GetTransactionsByGridQueryHandler : IQueryHandler<GetTransactionsByGridQuery, PagedList<GetTransactionsByGridQueryResponse>>
{
    private readonly ITransactionRepository _transactionRepository;
    public GetTransactionsByGridQueryHandler(ITransactionRepository transactionRepository) 
    {
        _transactionRepository = transactionRepository;
    }
    public async Task<OperationResult<PagedList<GetTransactionsByGridQueryResponse>>> Handle(GetTransactionsByGridQuery query)
    {
        var transactionQuery = _transactionRepository.GetAllFull();

        if (query.OwnerId.HasValue)
            transactionQuery = transactionQuery.Where(t => t.Property.OwnerId == query.OwnerId!.Value);

        if (query.PropertyId.HasValue)
            transactionQuery = transactionQuery.Where(t => t.PropertyId == query.PropertyId!.Value);

        if (query.DateFrom.HasValue)
            transactionQuery = transactionQuery.Where(t => t.Date >= query.DateFrom!.Value);

        if (query.DateTo.HasValue)
            transactionQuery = transactionQuery.Where(t => t.Date <= query.DateTo!.Value);

        if (query.Types != null && query.Types.Any())
            transactionQuery = transactionQuery.Where(t => query.Types.Contains(t.Type));

        if (query.SubTypes != null && query.SubTypes.Any())
            transactionQuery = transactionQuery.Where(t => query.SubTypes.Contains(t.SubType));

        if (query.ChargeStatuses != null && query.ChargeStatuses.Length != 0)
            transactionQuery = transactionQuery.Where(t =>query.ChargeStatuses.Contains((int)t.Status));


        var transactionQueryResponse = transactionQuery.OrderByDescending(t => t.Date)
                                                       .ThenByDescending(t => t.CreatedDate)
                                                       .Select(t => new GetTransactionsByGridQueryResponse(t));

        var response = await _transactionRepository.ToListPagedAsync(transactionQueryResponse, query.PageNumber!.Value, query.PageSize!.Value);

        return OperationResult<PagedList<GetTransactionsByGridQueryResponse>>.SuccessResult(response);

    }
}


