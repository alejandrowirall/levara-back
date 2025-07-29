
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Domain.Enum;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Leases.GetTransactionByGrid;

public class GetLeaseTransactionByGridQueryHandler : IQueryHandler<GetLeaseTransactionByGridQuery, PagedList<GetLeaseTransactionByGridQueryResponse>>
{
    private readonly ITransactionRepository _transactionRepository;
    
    public GetLeaseTransactionByGridQueryHandler(ITransactionRepository transactionRepository) 
    {
        _transactionRepository = transactionRepository;
    }
    public async Task<OperationResult<PagedList<GetLeaseTransactionByGridQueryResponse>>> Handle(GetLeaseTransactionByGridQuery query)
    {

        var transactionQuery = _transactionRepository.GetAllFull()
            .Where(t => t.Type == TransactionType.Lease);

        if (query.LeaseId.HasValue)
            transactionQuery = transactionQuery.Where(t => t.LeaseId == query.LeaseId!.Value);

        if (query.TenantId.HasValue)
        {
            transactionQuery = transactionQuery.Where(t => t.Lease != null && t.Lease.TenantId == query.TenantId!.Value);
        }

        var transactionQueryResponse = transactionQuery.OrderByDescending(t => t.Date)
                                                       .Select(t => new GetLeaseTransactionByGridQueryResponse(t));

        var response = await _transactionRepository.ToListPagedAsync(transactionQueryResponse, query.PageNumber!.Value, query.PageSize!.Value);

        return OperationResult<PagedList<GetLeaseTransactionByGridQueryResponse>>.SuccessResult(response);
    }
}


