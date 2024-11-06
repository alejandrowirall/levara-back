
using Levara.Domain.Enum;
using Levara.Domain.Models;

namespace Levara.Application.Leases.GetByGrid;

public class GetLeaseByGridQueryResponse
{
    public GetLeaseByGridQueryResponse(Lease lease)
    {
        Id = lease.Id;
        OwnerId = lease.OwnerId;
        TenantId = lease.TenantId;
        PropertyId = lease.PropertyId;
        Frequency = lease.Frequency;
        Price = lease.Amount;
    }
    public int Id { get; }

    public int OwnerId { get; set; }

    public int TenantId { get; set; }

    public int PropertyId { get; set; }

    public FrequencyType Frequency { get; set; }
    public decimal? Price { get; set; }
}