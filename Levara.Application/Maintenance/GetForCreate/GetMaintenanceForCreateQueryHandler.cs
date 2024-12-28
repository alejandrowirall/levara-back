
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Maintenances.GetForCreate;

//TODO We still don't know if we will need this service.
public class GetMaintenanceForCreateQueryHandler : IQueryHandler<GetMaintenanceForCreateQuery, GetMaintenanceForCreateQueryResponse>
{
    public GetMaintenanceForCreateQueryHandler() 
    {
    }
    public Task<OperationResult<GetMaintenanceForCreateQueryResponse>> Handle(GetMaintenanceForCreateQuery query)
    {
        GetMaintenanceForCreateQueryResponse response = new();
        
        return Task.FromResult(OperationResult<GetMaintenanceForCreateQueryResponse>.SuccessResult(response));
    }
}
