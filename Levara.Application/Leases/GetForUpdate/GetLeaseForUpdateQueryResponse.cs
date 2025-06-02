
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Leases.GetForUpdate;

public class GetLeaseForUpdateQueryResponse
{
    public GetLeaseForUpdateQueryResponse(LeaseUpdateQueryResponse lease,
        IEnumerable<ListModel> properties,
        IEnumerable<ListModel> tenants,
        IEnumerable<ListModel> leaseStatuses,
        IEnumerable<ListModel> frequencyTypes)
    {
        Lease = lease;
        Properties = properties;
        Tenants = tenants;
        LeaseStatuses = leaseStatuses;
        FrequencyTypes = frequencyTypes;
    }

    public LeaseUpdateQueryResponse Lease { get; }
    public IEnumerable<ListModel> Properties { get; }
    public IEnumerable<ListModel> Tenants { get; }
    public IEnumerable<ListModel> LeaseStatuses { get; }
    public IEnumerable<ListModel> FrequencyTypes { get; }
}

public class LeaseUpdateQueryResponse
{
    public LeaseUpdateQueryResponse(Lease lease)
    {
        OwnerId = lease.OwnerId;
        PropertyId = lease.PropertyId;
        Frequency = lease.Frequency;
        TenantId = lease.TenantId;
        DateFrom = lease.DateFrom;
        DateTo = lease.DateTo;
        Price = lease.Amount;
        Status = lease.Status;
        MatchTags = lease.MatchTags;

    }
    [Range(1, int.MaxValue)]
    public int OwnerId { get; set; }

    [Range(1, int.MaxValue)]
    public int TenantId { get; set; }

    [Range(1, int.MaxValue)]
    public int PropertyId { get; set; }

    public FrequencyType Frequency { get; set; }

    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public decimal Price { get; set; }

    public LeaseStatus Status { get; set; }

    public List<string>? MatchTags { get; set; }

}
