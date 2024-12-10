
using Levara.Domain.Models;
using Levara.Shared.Domain.Models;

namespace Levara.Application.Leases.GetForCreate;

public class GetLeaseForCreateQueryResponse
{
    private Lease l;
    private object collection;

    public GetLeaseForCreateQueryResponse(Lease lease, List<ListModel> leaseStatus)
    {
        TenantId = lease.TenantId;
        TenantName = $"{lease.Tenant.Name} {lease.Tenant.Surname}";
        LeaseStatus = leaseStatus;
    }

    public GetLeaseForCreateQueryResponse(Lease l, object collection)
    {
        this.l = l;
        this.collection = collection;
    }

    public int TenantId { get; set; }
    public string TenantName { get; set; }
    public List<ListModel> LeaseStatus { get; }

}
