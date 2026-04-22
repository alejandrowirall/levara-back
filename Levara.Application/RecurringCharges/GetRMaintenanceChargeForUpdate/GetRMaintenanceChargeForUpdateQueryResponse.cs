
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Models;

namespace Levara.Application.RecurringCharges.GetRMaintenanceChargeForUpdate;

public class GetRMaintenanceChargeForUpdateQueryResponse
{
    public GetRMaintenanceChargeForUpdateQueryResponse(RecurringCharge recurringCharge,
        Property property,
        IEnumerable<ListModel> frequencyTypes,
        IEnumerable<ListModel> maintenanceTypes)
    {
        Id = recurringCharge.Id;
        IsRecurrent = recurringCharge.IsRecurrent;
        Frequency = recurringCharge.Frequency;
        Amount = recurringCharge.Amount;
        MaintenanceTypeId = recurringCharge.MaintenanceTypeId!.Value;
        NextChargeDate = recurringCharge.NextChargeDate;
        Active = recurringCharge.Active;
        Spliteable = recurringCharge.Spliteable;

        Description = property.OneLineDescription();
        StartDate = recurringCharge.StartDate;
        EndDate = recurringCharge.EndDate;

        FrequencyTypes = frequencyTypes;
        MaintenanceTypes = maintenanceTypes;
        MatchTags = recurringCharge.MatchTags;
    }

    public int Id { get; }
    public bool IsRecurrent { get; set; }
    public FrequencyType? Frequency { get; set; }
    public decimal? Amount { get; set; }
    public DateTime? StartDate { get; }
    public DateTime? EndDate { get; }
    public int MaintenanceTypeId { get; set; }
    public DateTime? NextChargeDate { get; set; }
    public bool Active { get; set; }
    public bool Spliteable { get; set; }
    public string Description { get; }
    public IEnumerable<ListModel> FrequencyTypes { get; }
    public IEnumerable<ListModel> MaintenanceTypes { get; }
    public List<string>? MatchTags { get; }

}
