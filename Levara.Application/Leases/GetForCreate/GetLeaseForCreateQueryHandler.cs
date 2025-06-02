using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Domain.Models;
using Levara.Shared.Extensions;
using Levara.Shared.Results;

namespace Levara.Application.Leases.GetForCreate;

public class GetLeaseForCreateQueryHandler : IQueryHandler<GetLeaseForCreateQuery, GetLeaseForCreateQueryResponse>
{
    private readonly ITenantRepository _tenantRepository;
    private readonly IPropertyRepository _propertyRepository;
    public GetLeaseForCreateQueryHandler(ITenantRepository tenantRepository,
        IPropertyRepository propertyRepository) 
    {
        _tenantRepository = tenantRepository;
        _propertyRepository = propertyRepository;
    }
    public async Task<OperationResult<GetLeaseForCreateQueryResponse>> Handle(GetLeaseForCreateQuery query)
    {
        IEnumerable<ListModel> leaseStatuses = EnumExtensions.ToListModel<LeaseStatus>();
        IEnumerable<ListModel> frequencyTypes = EnumExtensions.ToListModel<FrequencyType>();

        var propertyQuery = _propertyRepository.GetAllWithAddress()
                                               .Where(p => p.OwnerId == query.OwnerId!.Value)
                                               .Select(p => new ListModel { Id = p.Id, Text = p.OneLineDescription() });

        IEnumerable<ListModel> properties = await _propertyRepository.ToListAsync(propertyQuery);

        var tenantQuery = _tenantRepository.GetAllWithAddress()
                                           .Select(t => new ListModel { Id = t.Id, Text = t.OneLineDescription() });

        IEnumerable<ListModel> tenants = await _tenantRepository.ToListAsync(tenantQuery);

        var response = new GetLeaseForCreateQueryResponse(properties, tenants, leaseStatuses, frequencyTypes);

        return OperationResult<GetLeaseForCreateQueryResponse>.SuccessResult(response);
    }
}
