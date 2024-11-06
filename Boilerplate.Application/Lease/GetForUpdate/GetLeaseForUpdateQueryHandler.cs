using Boilerplate.Domain.Contexts;
using Boilerplate.Domain.DAL.Repositories;
using Boilerplate.Shared.Domain.Bus.Queries;
using Boilerplate.Shared.Results;

namespace Boilerplate.Application.Leases.GetForUpdate;

public class GetLeaseForUpdateQueryHandler : IQueryHandler<GetLeaseForUpdateQuery, GetLeaseForUpdateQueryResponse>
{
    private readonly IUserContext _userContext;
    private readonly ILeaseRepository _leaseRepository;
    public GetLeaseForUpdateQueryHandler(IUserContext userContext,
        ILeaseRepository leaseRepository) 
    {
        _userContext = userContext;
        _leaseRepository = leaseRepository;
    }
    public async Task<OperationResult<GetLeaseForUpdateQueryResponse>> Handle(GetLeaseForUpdateQuery query)
    {
        var leaseQuery = _leaseRepository.GetAllLeases()
                                               .Where(p => p.Id == query.Id!.Value)
                                               .Select(p => new LeaseUpdateQueryResponse(p));

        LeaseUpdateQueryResponse? property = await _leaseRepository.FirstOrDefaultAsync(leaseQuery);
        if (property == null)
            return OperationResult<GetLeaseForUpdateQueryResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        if (_userContext.IsOwner && property.OwnerId != _userContext.OwnerId!.Value)
            return OperationResult<GetLeaseForUpdateQueryResponse>.ErrorResult(new ErrorDetails(403, "The owner does not have permissions to update this property."));

        GetLeaseForUpdateQueryResponse response = new(property);
        
        return OperationResult<GetLeaseForUpdateQueryResponse>.SuccessResult(response);

    }
}
