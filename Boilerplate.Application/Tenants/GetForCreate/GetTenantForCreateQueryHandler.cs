
using Boilerplate.Domain.Enum;
using Boilerplate.Shared.Extensions;
using Boilerplate.Shared.Domain.Bus.Queries;
using Boilerplate.Shared.Results;

namespace Boilerplate.Application.Tenants.GetForCreate;

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
