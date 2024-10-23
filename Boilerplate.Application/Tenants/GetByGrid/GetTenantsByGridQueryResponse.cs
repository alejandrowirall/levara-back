
using Boilerplate.Domain.Models;
using Boilerplate.Shared.Extensions;

namespace Boilerplate.Application.Tenants.GetByGrid;

public class GetTenantsByGridQueryResponse
{
    public GetTenantsByGridQueryResponse(Tenant tenant)
    {
        Id = tenant.Id;
        Name = tenant.Name;
        Surname = tenant.Surname;
        CompanyName = tenant.CompanyName;
        Identification = tenant.Identification;
        IdentificationType = EnumExtensions.GetEnumDescription(tenant.IdentificationType);
        PersonType = EnumExtensions.GetEnumDescription(tenant.PersonType);
        Email = tenant.Email;
    }
    public int Id { get; }

    public string Name { get; }

    public string Surname { get; }

    public string CompanyName { get; }

    public string Email { get; }

    public string Identification { get; }

    public string IdentificationType { get; }

    public string PersonType { get; }

}