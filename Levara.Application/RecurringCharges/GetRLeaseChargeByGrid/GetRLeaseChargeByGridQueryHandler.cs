
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.RecurringCharges.GetRLeaseChargeByGrid;

public class GetRLeaseChargeByGridQueryHandler : IQueryHandler<GetRLeaseChargeByGridQuery, PagedList<GetRLeaseChargeByGridQueryResponse>>
{
    private readonly IRecurringChargeRepository _recurringChargeRepository;
    public GetRLeaseChargeByGridQueryHandler(IRecurringChargeRepository recurringChargeRepository) 
    {
        _recurringChargeRepository = recurringChargeRepository;
    }
    public async Task<OperationResult<PagedList<GetRLeaseChargeByGridQueryResponse>>> Handle(GetRLeaseChargeByGridQuery query)
    {

        var recurringChargeQuery = _recurringChargeRepository.GetAllFull();

        if(query.PropertyId.HasValue)
            recurringChargeQuery = recurringChargeQuery.Where(rc => rc.PropertyId == query.PropertyId!.Value);

        if (query.LeaseId.HasValue)
            recurringChargeQuery = recurringChargeQuery.Where(rc => rc.LeaseId == query.LeaseId!.Value);

        if (query.OwnerId.HasValue)
            recurringChargeQuery = recurringChargeQuery.Where(rc => rc.Property.OwnerId == query.OwnerId!.Value);


        if (query.Ids != null && query.Ids.Length != 0)
            recurringChargeQuery = recurringChargeQuery.Where(rc => query.Ids.Contains(rc.Id));

        var responseQuery = recurringChargeQuery.OrderByDescending(rc => rc.CreatedDate)
                                                .Select(rc => new GetRLeaseChargeByGridQueryResponse(rc));

        var response = await _recurringChargeRepository.ToListPagedAsync(responseQuery, query.PageNumber!.Value, query.PageSize!.Value);


        return OperationResult<PagedList<GetRLeaseChargeByGridQueryResponse>>.SuccessResult(response);

    }
}


