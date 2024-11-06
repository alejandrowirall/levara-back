
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Leases.GetForCreate;

//TODO We still don't know if we will need this service.
public class GetLeaseForCreateQueryHandler : IQueryHandler<GetLeaseForCreateQuery, GetLeaseForCreateQueryResponse>
{
    public GetLeaseForCreateQueryHandler() 
    {
    }
    public Task<OperationResult<GetLeaseForCreateQueryResponse>> Handle(GetLeaseForCreateQuery query)
    {
        GetLeaseForCreateQueryResponse response = new();
        
        return Task.FromResult(OperationResult<GetLeaseForCreateQueryResponse>.SuccessResult(response));
    }
}
