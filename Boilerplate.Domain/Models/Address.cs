
using System.ComponentModel.DataAnnotations;

namespace Levara.Domain.Models;

public class Address : Entity
{
    [Length(1, 200)]
    public required string Street { get; set; }

    [Length(1, int.MaxValue)]
    public required int Number { get; set; }

    [Length(1, 200)]
    public string? AdditionalLine { get; set; }

    [Length(1, 20)]
    public required string City { get; set; }

    [Length(1, 20)]
    public required string State { get; set; }

    [Length(1, 10)]
    public required string PostalCode { get; set; }      
}
