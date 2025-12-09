
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Leases.GetByGrid;

public class GetLeaseByGridQueryHandler : IQueryHandler<GetLeaseByGridQuery, PagedList<GetLeaseByGridQueryResponse>>
{
    private readonly ILeaseRepository _leaseRepository;
    private readonly ITransactionRepository _transactionRepository;
    
    public GetLeaseByGridQueryHandler(ILeaseRepository leaseRepository, ITransactionRepository transactionRepository) 
    {
        _leaseRepository = leaseRepository;
        _transactionRepository = transactionRepository;
    }
    public async Task<OperationResult<PagedList<GetLeaseByGridQueryResponse>>> Handle(GetLeaseByGridQuery query)
    {

        var leaseQuery = _leaseRepository.GetAllFull();

        if (query.OwnerId.HasValue)
            leaseQuery = leaseQuery.Where(l => l.OwnerId == query.OwnerId!.Value);

        if (query.TenantId.HasValue)
            leaseQuery = leaseQuery.Where(l => l.TenantId == query.TenantId!.Value);

        if (query.PropertyId.HasValue)
            leaseQuery = leaseQuery.Where(l => l.PropertyId == query.PropertyId!.Value);

        var leaseQueryResponse = leaseQuery.OrderByDescending(l => l.CreatedDate)
                                           .Select(l => new GetLeaseByGridQueryResponse(l));

        var response = await _leaseRepository.ToListPagedAsync(leaseQueryResponse, query.PageNumber!.Value, query.PageSize!.Value);

        var leaseIds = response.Items.Select(r => r.Id).ToList();
        var leaseBalances = await _transactionRepository.GetLastLeaseRunningBalancesAsync(leaseIds);

        foreach (var item in response.Items)
        {
            item.Balance = leaseBalances.GetValueOrDefault(item.Id, 0);
        }

        return OperationResult<PagedList<GetLeaseByGridQueryResponse>>.SuccessResult(response);

    }
}


