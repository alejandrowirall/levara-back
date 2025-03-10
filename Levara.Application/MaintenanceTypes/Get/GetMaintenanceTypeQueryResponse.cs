
using Levara.Domain.Models;

namespace Levara.Application.MaintenanceTypes.Get;

public class GetMaintenanceTypeQueryResponse
{
    public GetMaintenanceTypeQueryResponse(MaintenanceType maintenanceType)
    {
        Id = maintenanceType.Id;
        Description = maintenanceType.Description; 
    }
    public int Id { get; set; }
    public string Description { get; set; }

}