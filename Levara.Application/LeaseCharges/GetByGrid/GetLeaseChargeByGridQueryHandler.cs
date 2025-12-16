
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
            leaseChargeQuery = leaseChargeQuery.Where(lc => lc.Transaction.PropertyId == query.PropertyId!.Value);

        if (query.OwnerId.HasValue)
            leaseChargeQuery = leaseChargeQuery.Where(lc => lc.Transaction.Lease!.OwnerId == query.OwnerId!.Value);

        if (query.Statuses != null && query.Statuses.Length != 0)
            leaseChargeQuery = leaseChargeQuery.Where(lc => query.Statuses.Contains(lc.Transaction.Status));

        if (query.Ids != null && query.Ids.Length != 0)
            leaseChargeQuery = leaseChargeQuery.Where(lc => query.Ids.Contains(lc.Id));

        var responseQuery = leaseChargeQuery.OrderByDescending(lc => lc.CreatedDate)
                                            .Select(lc => new GetLeaseChargeByGridQueryResponse(lc));

        var response = await _leaseChargeRepository.ToListPagedAsync(responseQuery, query.PageNumber!.Value, query.PageSize!.Value);


        return OperationResult<PagedList<GetLeaseChargeByGridQueryResponse>>.SuccessResult(response);

    }
}


