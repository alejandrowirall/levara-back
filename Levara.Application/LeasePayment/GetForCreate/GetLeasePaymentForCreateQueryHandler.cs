
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.LeasesPayment.GetForCreate;

//TODO We still don't know if we will need this service.
public class GetLeasePaymentForCreateQueryHandler : IQueryHandler<GetLeasePaymentForCreateQuery, GetLeasePaymentForCreateQueryResponse>
{
    public GetLeasePaymentForCreateQueryHandler() 
    {
    }
    public Task<OperationResult<GetLeasePaymentForCreateQueryResponse>> Handle(GetLeasePaymentForCreateQuery query)
    {
        GetLeasePaymentForCreateQueryResponse response = new();
        
        return Task.FromResult(OperationResult<GetLeasePaymentForCreateQueryResponse>.SuccessResult(response));
    }
}
