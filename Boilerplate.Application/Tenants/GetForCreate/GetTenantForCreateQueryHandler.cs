
using Levara.Domain.Enum;
using Levara.Shared.Extensions;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Tenants.GetForCreate;

public class GetTenantForCreateQueryHandler : IQueryHandler<GetTenantForCreateQuery, GetTenantForCreateQueryResponse>
{
    public GetTenantForCreateQueryHandler() 
    {
    }
    public Task<OperationResult<GetTenantForCreateQueryResponse>> Handle(GetTenantForCreateQuery query)
    {
        GetTenantForCreateQueryResponse response = new(EnumExtensions.ToListModel<PersonType>(),
                                                       EnumExtensions.ToListModel<IdentificationType>());
        
        return Task.FromResult(OperationResult<GetTenantForCreateQueryResponse>.SuccessResult(response));
    }
}
