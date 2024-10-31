

using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Domain.Models;

public class Property : Entity
{
    public int Number {  get; set; }

    public int AddressId { get; set; }

    [Required]
    public Address Address { get; set; }

    public int OwnerId { get; set; }

    [Required]
    public Owner Owner { get; set; }
}
