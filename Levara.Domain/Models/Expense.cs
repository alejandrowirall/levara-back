using Levara.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Levara.Domain.Models;

public class Expense : Entity
{
    [Required]
    [Length(1, 50)]
    public string Title { get; set; }

    [Required]
    [Length(1, 200)]
    public string Description { get; set; }

    public int TypeId { get; set; }
    public ExpenseType Type { get; set; }

    public int PropertyId { get; set; }

    public Property Property { get; set; }

    public ExpenseStatus Status { get; set; }

}
