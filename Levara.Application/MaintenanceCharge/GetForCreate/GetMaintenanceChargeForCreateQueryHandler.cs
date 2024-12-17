
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.MaintenancesCharges.GetForCreate;

//TODO We still don't know if we will need this service.
public class GetMaintenanceChargeForCreateQueryHandler : IQueryHandler<GetMaintenanceChargeForCreateQuery, GetMaintenanceChargeForCreateQueryResponse>
{
    public GetMaintenanceChargeForCreateQueryHandler() 
    {
    }
    public Task<OperationResult<GetMaintenanceChargeForCreateQueryResponse>> Handle(GetMaintenanceChargeForCreateQuery query)
    {
        GetMaintenanceChargeForCreateQueryResponse response = new();
        
        return Task.FromResult(OperationResult<GetMaintenanceChargeForCreateQueryResponse>.SuccessResult(response));
    }
}
