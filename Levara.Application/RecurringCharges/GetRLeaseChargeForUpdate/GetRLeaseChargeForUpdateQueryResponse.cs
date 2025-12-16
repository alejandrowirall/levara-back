
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Models;

namespace Levara.Application.RecurringCharges.GetRLeaseChargeForUpdate;

public class GetRLeaseChargeForUpdateQueryResponse
{
    public GetRLeaseChargeForUpdateQueryResponse(RecurringCharge recurringCharge,
        Lease lease,
        IEnumerable<ListModel> frequencyTypes,
        IEnumerable<ListModel> leaseChargeTypes)
    {
        Id = recurringCharge.Id;
        IsRecurrent = recurringCharge.IsRecurrent;
        Frequency = recurringCharge.Frequency;
        Amount = recurringCharge.Amount;
        LeaseChargeTypeId = recurringCharge.LeaseChargeTypeId!.Value;
        NextChargeDate = recurringCharge.NextChargeDate;
        Active = recurringCharge.Active;

        Description = lease.Property.OneLineDescription();
        StartDate = recurringCharge.StartDate;
        EndDate = recurringCharge.EndDate;

        FrequencyTypes = frequencyTypes;
        LeaseChargeTypes = leaseChargeTypes;
        MatchTags = recurringCharge.MatchTags;
    }

    public int Id { get; }
    public bool IsRecurrent { get; set; }
    public FrequencyType? Frequency { get; set; }
    public decimal? Amount { get; set; }
    public DateTime? StartDate { get; }
    public DateTime? EndDate { get; }
    public int LeaseChargeTypeId { get; set; }
    public DateTime? NextChargeDate { get; set; }
    public bool Active { get; set; }
    public string Description { get; }
    public IEnumerable<ListModel> FrequencyTypes { get; }
    public IEnumerable<ListModel> LeaseChargeTypes { get; }
    public List<string>? MatchTags { get; }

}
