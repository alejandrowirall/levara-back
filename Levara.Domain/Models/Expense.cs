
using System.ComponentModel.DataAnnotations;

namespace Levara.Domain.Models;

public class Expense : Entity
{
    [Required]
    [Length(1, 50)]
    public string Name { get; set; }

    [Required]
    [Length(1, 200)]
    public string Description { get; set; }
}
