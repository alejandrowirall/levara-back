
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Leases.GetForUpdate;

public class GetLeaseForUpdateQueryResponse
{
    public GetLeaseForUpdateQueryResponse(LeaseUpdateQueryResponse property)
    {
        Property = property;
    }

    public LeaseUpdateQueryResponse Property { get; }
}

public class LeaseUpdateQueryResponse
{
    public LeaseUpdateQueryResponse(Lease lease)
    {
        OwnerId = lease.OwnerId!;
        PropertyId = lease.PropertyId!;
        TenantId = lease.TenantId!;
        DateFrom = lease.DateFrom!;
        DateTo = lease.DateTo!;
        Price = lease.Amount!;

        
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

}
