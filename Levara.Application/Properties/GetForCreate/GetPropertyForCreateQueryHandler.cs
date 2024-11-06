
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Properties.GetForCreate;

//TODO We still don't know if we will need this service.
public class GetPropertyForCreateQueryHandler : IQueryHandler<GetPropertyForCreateQuery, GetPropertyForCreateQueryResponse>
{
    public GetPropertyForCreateQueryHandler() 
    {
    }
    public Task<OperationResult<GetPropertyForCreateQueryResponse>> Handle(GetPropertyForCreateQuery query)
    {
        GetPropertyForCreateQueryResponse response = new();
        
        return Task.FromResult(OperationResult<GetPropertyForCreateQueryResponse>.SuccessResult(response));
    }
}
