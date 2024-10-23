
using Boilerplate.Domain.Enum;
using Boilerplate.Domain.Models;
using Boilerplate.Shared.Domain.Models;

namespace Boilerplate.Application.Tenants.GetForUpdate;

public class GetTenantForUpdateQueryResponse
{
    public GetTenantForUpdateQueryResponse(TenantUpdateQueryResponse tenant,
        List<ListModel> personTypes,
        List<ListModel> identificationTypes)
    {
        Tenant = tenant;
        PersonTypes = personTypes;
        IdentificationTypes = identificationTypes;
    }
    public TenantUpdateQueryResponse Tenant { get; }

    public List<ListModel> PersonTypes { get; }

    public List<ListModel> IdentificationTypes { get; }

}

public class TenantUpdateQueryResponse
{
    public TenantUpdateQueryResponse(Tenant tenant)
    {
        Id = tenant.Id;
        Name = tenant.Name;
        Surname = tenant.Surname;
        CompanyName = tenant.CompanyName;
        Identification = tenant.Identification;
        IdentificationType = tenant.IdentificationType;
        PersonType = tenant.PersonType;
        MobilePhone = tenant.MobilePhone;
        Email = tenant.Email;
        Street = tenant.Address.Street;
        Number = tenant.Address.Number;
        AdditionalLine = tenant.Address.AdditionalLine;
        City = tenant.Address.City;
        State = tenant.Address.State;
        PostalCode = tenant.Address.PostalCode;
    }
    public int Id { get; }

    public string Name { get; }

    public string Surname { get; }

    public string CompanyName { get; }

    public string Identification { get; }

    public IdentificationType IdentificationType { get; }

    public PersonType PersonType { get; }

    public string MobilePhone { get; }

    public string Email { get; }

    public string Street { get; }

    public int Number { get; }

    public string? AdditionalLine { get; }

    public string City { get; }

    public string State { get; }

    public string PostalCode { get; }

}
