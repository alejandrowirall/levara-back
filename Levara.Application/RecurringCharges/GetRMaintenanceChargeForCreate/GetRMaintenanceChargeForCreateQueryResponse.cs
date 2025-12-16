
using Levara.Domain.Models;
using Levara.Shared.Domain.Models;

namespace Levara.Application.RecurringCharges.GetRMaintenanceChargeForCreate;

public class GetRMaintenanceChargeForCreateQueryResponse
{
    public GetRMaintenanceChargeForCreateQueryResponse(Property property,
        IEnumerable<ListModel> frequencyTypes,
        IEnumerable<ListModel> maintenanceTypes)
    {
        Description = property.OneLineDescription();
        StartDate = DateTime.UtcNow.Date;    
        EndDate = DateTime.UtcNow.Date.AddMonths(1);
        FrequencyTypes = frequencyTypes;
        MaintenanceTypes = maintenanceTypes;
    }

    public string Description { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
    public IEnumerable<ListModel> FrequencyTypes { get; }
    public IEnumerable<ListModel> MaintenanceTypes { get; }

}
