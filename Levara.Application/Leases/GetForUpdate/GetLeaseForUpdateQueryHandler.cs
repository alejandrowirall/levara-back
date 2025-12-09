using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Domain.Models;
using Levara.Shared.Extensions;
using Levara.Shared.Results;

namespace Levara.Application.Leases.GetForUpdate;

public class GetLeaseForUpdateQueryHandler : IQueryHandler<GetLeaseForUpdateQuery, GetLeaseForUpdateQueryResponse>
{
    private readonly ILeaseRepository _leaseRepository;
    private readonly ITenantRepository _tenantRepository;
    private readonly IPropertyRepository _propertyRepository;
    public GetLeaseForUpdateQueryHandler(ILeaseRepository leaseRepository,
        ITenantRepository tenantRepository,
        IPropertyRepository propertyRepository)
    {
        _leaseRepository = leaseRepository;
        _tenantRepository = tenantRepository;
        _propertyRepository = propertyRepository;
    }
    public async Task<OperationResult<GetLeaseForUpdateQueryResponse>> Handle(GetLeaseForUpdateQuery query)
    {
        var leaseResponseQuery = _leaseRepository.GetAllFull().Where(l => l.Id == query.Id!.Value &&
                                                                          l.Property.OwnerId == query.OwnerId!.Value)
                                                              .Select(l => new LeaseUpdateQueryResponse(l));

        var leaseResponse = await _leaseRepository.FirstOrDefaultAsync(leaseResponseQuery);
        if (leaseResponse == null)
            return OperationResult<GetLeaseForUpdateQueryResponse>.ErrorResult(new ErrorDetails(404, "Lease not found or does not belong to the specified owner."));


        IEnumerable<ListModel> leaseStatuses = EnumExtensions.ToListModel<LeaseStatus>();
        IEnumerable<ListModel> frequencyTypes = EnumExtensions.ToListModel<FrequencyType>();

        var propertyQuery = _propertyRepository.GetAllWithAddress()
                                               .Where(p => p.OwnerId == query.OwnerId!.Value)
                                               .Select(p => new ListModel { Id = p.Id, Text = p.OneLineDescription() });

        IEnumerable<ListModel> properties = await _propertyRepository.ToListAsync(propertyQuery);

        var tenantQuery = _tenantRepository.GetAllWithAddress()
                                           .Select(t => new ListModel { Id = t.Id, Text = t.OneLineDescription() });

        IEnumerable<ListModel> tenants = await _tenantRepository.ToListAsync(tenantQuery);

        var response = new GetLeaseForUpdateQueryResponse(leaseResponse, properties, tenants, leaseStatuses, frequencyTypes);

        return OperationResult<GetLeaseForUpdateQueryResponse>.SuccessResult(response);

    }
}
