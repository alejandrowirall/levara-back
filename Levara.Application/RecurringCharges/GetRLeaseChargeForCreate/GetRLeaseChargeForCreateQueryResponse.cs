
using Levara.Domain.Models;
using Levara.Shared.Domain.Models;

namespace Levara.Application.RecurringCharges.GetRLeaseChargeForCreate;

public class GetRLeaseChargeForCreateQueryResponse
{
    public GetRLeaseChargeForCreateQueryResponse(Lease lease,
        IEnumerable<ListModel> frequencyTypes,
        IEnumerable<ListModel> leaseChargeTypes)
    {
        Description = lease.Property.OneLineDescription();
        StartDate = lease.DateFrom;    
        EndDate = lease.DateTo;
        FrequencyTypes = frequencyTypes;
        LeaseChargeTypes = leaseChargeTypes;
    }

    public string Description { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
    public IEnumerable<ListModel> FrequencyTypes { get; }
    public IEnumerable<ListModel> LeaseChargeTypes { get; }

}
