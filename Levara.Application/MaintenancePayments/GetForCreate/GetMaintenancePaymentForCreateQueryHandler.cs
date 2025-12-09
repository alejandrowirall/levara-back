
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.MaintenancePayments.GetForCreate;

//TODO We still don't know if we will need this service.
public class GetMaintenancePaymentForCreateQueryHandler : IQueryHandler<GetMaintenancePaymentForCreateQuery, GetMaintenancePaymentForCreateQueryResponse>
{
    public GetMaintenancePaymentForCreateQueryHandler() 
    {
    }
    public Task<OperationResult<GetMaintenancePaymentForCreateQueryResponse>> Handle(GetMaintenancePaymentForCreateQuery query)
    {
        GetMaintenancePaymentForCreateQueryResponse response = new();
        
        return Task.FromResult(OperationResult<GetMaintenancePaymentForCreateQueryResponse>.SuccessResult(response));
    }
}
