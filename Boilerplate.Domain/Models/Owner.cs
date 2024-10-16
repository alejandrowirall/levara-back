using Boilerplate.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Domain.Models;

public class Owner : Entity
{
    [Length(1, 50)]
    public required string Name { get; set; }

    [Length(1, 50)]
    public required string Surname { get; set; }

    [Length(1, 50)]
    public required string CompanyName { get; set; }

    [Length(1, 50)]
    public required string Identification { get; set; }

    public required IdentificationType IdentificationType { get; set; }

    public required PersonType PersonType { get; set; }

    [Length(1, 15)]
    [Phone]
    public required string MobilePhone { get; set; }

    [Length(1, 320)]
    [EmailAddress]
    public required string Email { get; set; }

    public int AddressId { get; set; }

    public required Address Address { get; set; }

    public int? ApplicationUserId;
}
