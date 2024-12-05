
using Levara.Domain.Models;

namespace Levara.Application.Leases.GetForCreate;

public class GetLeaseForCreateQueryResponse
{
    public GetLeaseForCreateQueryResponse(Lease lease)
    {
        TenantId = lease.TenantId;
        TenantName = $"{lease.Tenant.Name} {lease.Tenant.Surname}";
    }



    public int TenantId { get; set; }
    public string TenantName { get; set; }


}
