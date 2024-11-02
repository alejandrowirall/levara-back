
using Boilerplate.Domain.Models;

namespace Boilerplate.Application.Properties.GetByGrid;

public class GetPropertiesByGridQueryResponse
{
    public GetPropertiesByGridQueryResponse(Property property)
    {
        Id = property.Id;
        Number = property.Number;
        Address = $"{property.Address.Street} {property.Address.Number}, {property.Address.City}, {property.Address.State}";
    }
    public int Id { get; }

    public int Number { get; set; }

    public string Address { get; set; }
}