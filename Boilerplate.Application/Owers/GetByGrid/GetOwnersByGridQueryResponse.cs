
using Boilerplate.Domain.Models;
using Boilerplate.Shared.Extensions;

namespace Boilerplate.Application.Owers.GetByGrid;

public class GetOwnersByGridQueryResponse
{
    public GetOwnersByGridQueryResponse(Owner owner)
    {
        Id = owner.Id;
        Name = owner.Name;
        Surname = owner.Surname;
        CompanyName = owner.CompanyName;
        Identification = owner.Identification;
        IdentificationType = EnumExtensions.GetEnumDescription(owner.IdentificationType);
        PersonType = EnumExtensions.GetEnumDescription(owner.PersonType);
        Email = owner.Email;
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