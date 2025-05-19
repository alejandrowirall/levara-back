

using System.ComponentModel.DataAnnotations;

namespace Levara.Domain.Models;

public class Property : Entity
{
    public int Number {  get; set; }

    public int AddressId { get; set; }

    [Required]
    public Address Address { get; set; }

    public int OwnerId { get; set; }

    [Required]
    public Owner Owner { get; set; }

    public decimal? Price { get; set; }

    public int? RoomsQuantity { get; set; }

    public int? BathroomQuantity { get; set; }


    public decimal? AreaQuantity { get; set; }

    public bool? HasPool { get; set; }

    public bool? HasBalcony { get; set; }
    public bool? HasGarage { get; set; }
   
    public string? DetailDepositAndAdittionalInfo { get; set; }
   
    public string? PetsPoliticAndRate { get; set; }
   
    public string? TenantRequirements { get; set; }

    public DateTime? AvaliableFrom { get; set; }

    public byte[]? Img { get; set; }

    public string OneLineDescription()
    {
        return $"{Number} - {Address.Street} {Address.Number}, {Address.City}, {Address.State}";
    }
}
