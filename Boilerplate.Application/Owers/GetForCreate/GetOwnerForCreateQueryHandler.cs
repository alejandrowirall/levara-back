
using Boilerplate.Domain.Enum;
using Boilerplate.Shared.Extensions;
using Boilerplate.Shared.Domain.Bus.Queries;
using Boilerplate.Shared.Results;

namespace Boilerplate.Application.Owers.GetForCreate;

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
