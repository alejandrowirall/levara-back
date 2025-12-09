using Levara.Domain.DAL.Repositories;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Admins.GetDashboard;

public class GetAdminDashboardQueryHandler : IQueryHandler<GetAdminDashboardQuery, GetAdminDashboardResponse>
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly ITenantRepository _tenantRepository;
    private readonly IPropertyRepository _propertyRepository;
    private readonly ILeaseRepository _leaseRepository;

    public GetAdminDashboardQueryHandler(IOwnerRepository ownerRepository, ITenantRepository tenantRepository, IPropertyRepository propertyRepository, ILeaseRepository leaseRepository)
    {
        _ownerRepository = ownerRepository;
        _tenantRepository = tenantRepository;
        _propertyRepository = propertyRepository;
        _leaseRepository = leaseRepository;
    }

    public async Task<OperationResult<GetAdminDashboardResponse>> Handle(GetAdminDashboardQuery query)
    {
        var ownersCount = await _ownerRepository.CountAsync();
        var tenantsCount = await _tenantRepository.CountAsync();
        var propertiesCount = await _propertyRepository.CountAsync();
        var leasesCount = await _leaseRepository.CountAsync();

        var response = new GetAdminDashboardResponse
        {
            OwnersCount = ownersCount,
            TenantsCount = tenantsCount,
            PropertiesCount = propertiesCount,
            LeasesCount = leasesCount
        };

        return OperationResult<GetAdminDashboardResponse>.SuccessResult(response);
    }
}
