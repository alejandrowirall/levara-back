
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Models;

namespace Levara.Application.Owners.GetForUpdate;

public class GetOwnerForUpdateQueryResponse
{
    public GetOwnerForUpdateQueryResponse(OwnerUpdateQueryResponse owner,
        List<ListModel> personTypes,
        List<ListModel> identificationTypes)
    {
        Owner = owner;
        PersonTypes = personTypes;
        IdentificationTypes = identificationTypes;
    }
    public OwnerUpdateQueryResponse Owner { get; }

    public List<ListModel> PersonTypes { get; }

    public List<ListModel> IdentificationTypes { get; }

}

public class OwnerUpdateQueryResponse
{
    public OwnerUpdateQueryResponse(Owner owner)
    {
        Id = owner.Id;
        Name = owner.Name;
        Surname = owner.Surname;
        CompanyName = owner.CompanyName;
        Identification = owner.Identification;
        IdentificationType = owner.IdentificationType;
        PersonType = owner.PersonType;
        MobilePhone = owner.MobilePhone;
        Email = owner.Email;
        Street = owner.Address.Street;
        AdditionalLine = owner.Address.AdditionalLine;
        City = owner.Address.City;
        State = owner.Address.State;
        PostalCode = owner.Address.PostalCode;
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

    public string? AdditionalLine { get; }

    public string City { get; }

    public string State { get; }

    public string PostalCode { get; }

}
