
using Boilerplate.Domain.DAL;
using Boilerplate.Domain.Enum;
using Boilerplate.Shared.Extensions;
using Boilerplate.Shared.Domain.Bus.Queries;
using Boilerplate.Shared.Results;
using Boilerplate.Domain.DAL.Repositories;

namespace Boilerplate.Application.Tenants.GetForUpdate;

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
