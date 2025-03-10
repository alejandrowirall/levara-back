
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.LeaseCharges.GetByGrid;

public class GetLeaseChargeByGridQueryHandler : IQueryHandler<GetLeaseChargeByGridQuery, PagedList<GetLeaseChargeByGridQueryResponse>>
{
    private readonly ILeaseChargeRepository _leaseChargeRepository;
    public GetLeaseChargeByGridQueryHandler(ILeaseChargeRepository leaseChargeRepository) 
    {
        _leaseChargeRepository = leaseChargeRepository;
    }
    public async Task<OperationResult<PagedList<GetLeaseChargeByGridQueryResponse>>> Handle(GetLeaseChargeByGridQuery query)
    {

        var leaseChargeQuery = _leaseChargeRepository.GetAllFull();

        if(query.PropertyId.HasValue)
            leaseChargeQuery = leaseChargeQuery.Where(t => t.Lease.PropertyId == query.PropertyId!.Value);

        if (query.OwnerId.HasValue)
            leaseChargeQuery = leaseChargeQuery.Where(t => t.Lease.OwnerId == query.OwnerId!.Value);

        if (query.Statuses != null && query.Statuses.Any())
            leaseChargeQuery = leaseChargeQuery.Where(t => query.Statuses.Contains(t.Status));

        var responseQuery = leaseChargeQuery.OrderByDescending(p => p.CreatedDate)
                                            .Select(p => new GetLeaseChargeByGridQueryResponse(p));

        var response = await _leaseChargeRepository.ToListPagedAsync(responseQuery, query.PageNumber!.Value, query.PageSize!.Value);


        return OperationResult<PagedList<GetLeaseChargeByGridQueryResponse>>.SuccessResult(response);

    }
}


