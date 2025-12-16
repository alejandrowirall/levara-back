
using Levara.Domain.Models;
using Levara.Shared.Domain.Models;

namespace Levara.Application.RecurringCharges.GetRExpenseChargeForCreate;

public class GetRExpenseChargeForCreateQueryResponse
{
    public GetRExpenseChargeForCreateQueryResponse(Property property,
        IEnumerable<ListModel> frequencyTypes,
        IEnumerable<ListModel> expenses)
    {
        Description = property.OneLineDescription();
        StartDate = DateTime.UtcNow.Date;    
        EndDate = DateTime.UtcNow.Date.AddMonths(1);
        FrequencyTypes = frequencyTypes;
        Expenses = expenses;
    }

    public string Description { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
    public IEnumerable<ListModel> FrequencyTypes { get; }
    public IEnumerable<ListModel> Expenses { get; }

}
