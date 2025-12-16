
using Levara.Domain.Models;

namespace Levara.Application.LeaseChargeTypes.Get;

public class GetLeaseChargeTypeQueryResponse
{
    public GetLeaseChargeTypeQueryResponse(LeaseChargeType leaseChargeType)
    {
        Id = leaseChargeType.Id;
        Description = leaseChargeType.Name; 
    }
    public int Id { get; set; }
    public string Description { get; set; }

}