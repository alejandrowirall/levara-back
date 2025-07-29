
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Extensions;

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
        FrequencyDesc = EnumExtensions.GetEnumDescription(lease.Frequency);
        Price = lease.Amount;
        DateTo = lease.DateTo;
        DateFrom = lease.DateFrom;
        PropertyAddress = lease.Property.OneLineDescription();

        PropertyStreet = $"{lease.Property.Address.Street} {lease.Property.Address.Number}";
        PropertyCity = $"{lease.Property.Address.City}, {lease.Property.Address.State}";

        OwnerName = $"{lease.Owner.Surname}, {lease.Owner.Name}";
        OwnerMail = lease.Owner.Email;
        OwnerPhone = lease.Owner.MobilePhone;
        Status = lease.Status;
        StatusDesc = EnumExtensions.GetEnumDescription(lease.Status);
        TenantFullName = $"{lease.Tenant.Surname}, {lease.Tenant.Name}";
    }
    public int Id { get; }

    public int OwnerId { get; set; }

    public int TenantId { get; set; }

    public int PropertyId { get; set; }

    public FrequencyType Frequency { get; set; }
    public string FrequencyDesc { get; set; }
    public decimal? Price { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }

    public string PropertyAddress { get; set; }
    public string PropertyStreet { get; set; }
    public string PropertyCity { get; set; }
    public string OwnerName { get; set; }
    public string OwnerMail { get; set; }
    public string OwnerPhone { get; set; }

    public string TenantFullName { get; set; }

    public LeaseStatus Status { get; set; }

    public string StatusDesc { get; set; }

    public decimal Balance { get; set; }
}