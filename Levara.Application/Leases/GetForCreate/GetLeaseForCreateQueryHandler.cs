
using Levara.Application.Leases.GetByGrid;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Domain.Models;
using Levara.Shared.Extensions;
using Levara.Shared.Results;

namespace Levara.Application.Leases.GetForCreate;

//TODO We still don't know if we will need this service.
public class GetLeaseForCreateQueryHandler : IQueryHandler<GetLeaseForCreateQuery, List<GetLeaseForCreateQueryResponse>>
{
    private readonly ILeaseRepository _leaseRepository;
    public GetLeaseForCreateQueryHandler(ILeaseRepository leaseRepository) 
    {
        _leaseRepository = leaseRepository;
    }
    public Task<OperationResult<List<GetLeaseForCreateQueryResponse>>> Handle(GetLeaseForCreateQuery query)
    {
        List<ListModel> listModels = EnumExtensions.ToListModel<LeaseStatus>();

        var leaseQuery = _leaseRepository.GetAllLeases()
                                          .Where(l => l.OwnerId == query.OwnerId!.Value)
                                          .OrderByDescending(p => p.CreatedDate)
                                          .Select(l => new GetLeaseForCreateQueryResponse(l, listModels)
                                          ).ToList<GetLeaseForCreateQueryResponse>();
        var ignoreduplicated = leaseQuery.DistinctBy(x => x.TenantId).ToList();
      //  List<GetLeaseForCreateQueryResponse> response = new();
        
        return Task.FromResult(OperationResult<List<GetLeaseForCreateQueryResponse>>.SuccessResult(ignoreduplicated));
    }
}
