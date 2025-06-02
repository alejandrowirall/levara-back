
using Levara.Shared.Domain.Models;

namespace Levara.Application.Leases.GetForCreate;

public class GetLeaseForCreateQueryResponse
{
    public GetLeaseForCreateQueryResponse(IEnumerable<ListModel> properties,
        IEnumerable<ListModel> tenants,
        IEnumerable<ListModel> leaseStatuses,
        IEnumerable<ListModel> frequencyTypes)
    {
        Properties = properties;
        Tenants = tenants;
        LeaseStatuses = leaseStatuses;
        FrequencyTypes = frequencyTypes;
    }

    public IEnumerable<ListModel> Properties { get; }
    public IEnumerable<ListModel> Tenants { get; }
    public IEnumerable<ListModel> LeaseStatuses { get; }
    public IEnumerable<ListModel> FrequencyTypes { get; }

}
