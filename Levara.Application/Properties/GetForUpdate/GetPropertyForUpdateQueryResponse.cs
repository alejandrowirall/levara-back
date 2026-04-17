
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Properties.GetForUpdate;

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
        AdditionalLine = property.Address.AdditionalLine;
        Price = property.Price;
        RoomsQuantity = property.RoomsQuantity;
        BathroomQuantity = property.BathroomQuantity;
        AreaQuantity = property.AreaQuantity;
        HasPool = property.HasPool;
        HasBalcony = property.HasBalcony;
        HasGarage = property.HasGarage;
        DetailDepositAndAdittionalInfo = property.DetailDepositAndAdittionalInfo;
        PetsPoliticAndRate = property.PetsPoliticAndRate;
        TenantRequirements = property.TenantRequirements;
        AvailableFrom = property.AvailableFrom;
        OwnerBankAccount = property.OwnerBankAccount;
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

    public DateTime? AvailableFrom { get; set; }

    public int? RoomsQuantity { get; set; }
    public int? BathroomQuantity { get; set; }

    public decimal? AreaQuantity { get; set; }

    public bool? HasPool { get; set; }

    public bool? HasBalcony { get; set; }
    public bool? HasGarage { get; set; }

    public string? DetailDepositAndAdittionalInfo { get; set; }

    public string? PetsPoliticAndRate { get; set; }

    public string? TenantRequirements { get; set; }
    public OwnerBankAccount? OwnerBankAccount { get; set; }

}
