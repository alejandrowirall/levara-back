
using Levara.Domain.Enum;
using Levara.Domain.Models;
using System.ComponentModel.DataAnnotations;

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
        DateTo=lease.DateTo;
        DateFrom = lease.DateFrom;
        PropertyAddress = $"{lease.Property.Address.Street} {lease.Property.Address.Number} {lease.Property.Address.City} {lease.Property.Address.PostalCode}";
        OwnerName = $"{lease.Owner.Name} {lease.Owner.Surname}";
        OwnerMail = lease.Owner.Email;
        OwnerPhone = lease.Owner.MobilePhone;
    }
    public int Id { get; }

    public int OwnerId { get; set; }

    public int TenantId { get; set; }

    public int PropertyId { get; set; }

    public FrequencyType Frequency { get; set; }
    public decimal? Price { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }

    public string PropertyAddress { get; set; }
    public string OwnerName { get; set; }
    public string OwnerMail { get; set; }
    public string OwnerPhone { get; set; }

}