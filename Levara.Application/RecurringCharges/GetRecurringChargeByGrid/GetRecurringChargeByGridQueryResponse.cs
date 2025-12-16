
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Extensions;

namespace Levara.Application.RecurringCharges.GetRecurringChargeByGrid;

public class GetRecurringChargeByGridQueryResponse
{
    public GetRecurringChargeByGridQueryResponse(RecurringCharge recurringCharge)
    {
        Id = recurringCharge.Id;
        IsRecurrent = recurringCharge.IsRecurrent;
        Amount = recurringCharge.Amount;
        Frequency = recurringCharge.Frequency;
        FrequencyDescription = recurringCharge.Frequency.HasValue
            ? EnumExtensions.GetEnumDescription(recurringCharge.Frequency.Value)
            : string.Empty;
        Type = recurringCharge.Type;
        TypeDescription = EnumExtensions.GetEnumDescription(recurringCharge.Type);
        ChargeDescription = recurringCharge.GetChargeDescription();
        StartDate = recurringCharge.StartDate;
        EndDate = recurringCharge.EndDate;
        Active = recurringCharge.Active;
    }

    public int Id { get; set; }
    public bool IsRecurrent { get; set; }
    public decimal? Amount { get; set; }

    public FrequencyType? Frequency { get; set; }
    public string FrequencyDescription { get; set; }
    public TransactionType Type { get; set; }
    public string TypeDescription { get; set; }
    public string ChargeDescription { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool Active { get; set; }
}