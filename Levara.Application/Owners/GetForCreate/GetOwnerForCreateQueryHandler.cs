
using Levara.Domain.Enum;
using Levara.Shared.Extensions;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Owners.GetForCreate;

public class GetOwnerForCreateQueryHandler : IQueryHandler<GetOwnerForCreateQuery, GetOwnerForCreateQueryResponse>
{
    public GetOwnerForCreateQueryHandler() 
    {
    }
    public Task<OperationResult<GetOwnerForCreateQueryResponse>> Handle(GetOwnerForCreateQuery query)
    {
        GetOwnerForCreateQueryResponse response = new(EnumExtensions.ToListModel<PersonType>(),
                                                      EnumExtensions.ToListModel<IdentificationType>());
        
        return Task.FromResult(OperationResult<GetOwnerForCreateQueryResponse>.SuccessResult(response));

    }
}
