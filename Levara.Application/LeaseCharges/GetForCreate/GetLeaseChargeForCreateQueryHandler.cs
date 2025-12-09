
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.LeaseCharges.GetForCreate;

//TODO We still don't know if we will need this service.
public class GetLeaseChargeForCreateQueryHandler : IQueryHandler<GetLeaseChargeForCreateQuery, GetLeaseChargeForCreateQueryResponse>
{
    public GetLeaseChargeForCreateQueryHandler() 
    {
    }
    public Task<OperationResult<GetLeaseChargeForCreateQueryResponse>> Handle(GetLeaseChargeForCreateQuery query)
    {
        GetLeaseChargeForCreateQueryResponse response = new();
        
        return Task.FromResult(OperationResult<GetLeaseChargeForCreateQueryResponse>.SuccessResult(response));
    }
}
