
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Leases.GetByGrid;

public class GetLeaseByGridQueryHandler : IQueryHandler<GetLeaseByGridQuery, PagedList<GetLeaseByGridQueryResponse>>
{
    private readonly ILeaseRepository _leaseRepository;
    public GetLeaseByGridQueryHandler(ILeaseRepository leaseRepository) 
    {
        _leaseRepository = leaseRepository;
    }
    public async Task<OperationResult<PagedList<GetLeaseByGridQueryResponse>>> Handle(GetLeaseByGridQuery query)
    {

        var leaseQuery = _leaseRepository.GetAllLeases()
                                               .Where(l => l.OwnerId == query.OwnerId!.Value)
                                               .OrderByDescending(p => p.CreatedDate)
                                               //.Select(l => new GetLeaseByGridQueryResponse(l));
                                               .Select(l => new GetLeaseByGridQueryResponse(l)
                                               );

        var response = await _leaseRepository.ToListPagedAsync(leaseQuery, query.PageNumber!.Value, query.PageSize!.Value);


        return OperationResult<PagedList<GetLeaseByGridQueryResponse>>.SuccessResult(response);

    }
}


