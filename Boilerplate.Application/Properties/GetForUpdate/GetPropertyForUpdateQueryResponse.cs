
using Boilerplate.Domain.Models;

namespace Boilerplate.Application.Properties.GetForUpdate;

public class GetPropertyForUpdateQueryResponse
{
    public GetPropertyForUpdateQueryResponse(PropertyUpdateQueryResponse property)
    {
        Property = property;
    }

    public PropertyUpdateQueryResponse Property { get; }
}

public class PropertyUpdateQueryResponse
{
    public PropertyUpdateQueryResponse(Property property)
    {
        Id = property.Id;
        OwnerId = property.OwnerId;
        Number = property.Number;
        Street = property.Address.Street;
        City = property.Address.City;
        State = property.Address.State;
        PostalCode = property.Address.PostalCode;
    }
    public int Id { get; }

    public int OwnerId { get; }

    public int Number { get; }

    public string Street { get; }

    public string? AdditionalLine { get; }

    public string City { get; }

    public string State { get; }

    public string PostalCode { get; }

    public decimal? Price { get; set; }

}
