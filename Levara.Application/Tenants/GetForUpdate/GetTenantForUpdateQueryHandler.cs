
using Levara.Domain.DAL;
using Levara.Domain.Enum;
using Levara.Shared.Extensions;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;
using Levara.Domain.DAL.Repositories;

namespace Levara.Application.Tenants.GetForUpdate;

public class GetTenantForUpdateQueryHandler : IQueryHandler<GetTenantForUpdateQuery, GetTenantForUpdateQueryResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantRepository _tenantRepository;
    public GetTenantForUpdateQueryHandler(IUnitOfWork unitOfWork,
        ITenantRepository tenantRepository) 
    {
        _unitOfWork = unitOfWork;
        _tenantRepository = tenantRepository;
    }
    public async Task<OperationResult<GetTenantForUpdateQueryResponse>> Handle(GetTenantForUpdateQuery query)
    {
        var tenantQuery = _tenantRepository.GetAllWithAddress()
                                           .Where(o => o.Id == query.Id!.Value)
                                           .Select(o => new TenantUpdateQueryResponse(o));

        TenantUpdateQueryResponse? tenant = await _tenantRepository.FirstOrDefaultAsync(tenantQuery);
        if (tenant == null)
            return OperationResult<GetTenantForUpdateQueryResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        GetTenantForUpdateQueryResponse response = new(tenant, 
                                                       EnumExtensions.ToListModel<PersonType>((int)tenant.PersonType), 
                                                       EnumExtensions.ToListModel<IdentificationType>((int)tenant.IdentificationType));
        
        return OperationResult<GetTenantForUpdateQueryResponse>.SuccessResult(response);

    }
}
