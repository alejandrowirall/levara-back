
using System.ComponentModel.DataAnnotations;

namespace Levara.Domain.Models;

public class OwnerBankAccount : Entity
{
    [Length(1, 50)]
    public required string BankName { get; set; }

    [Length(1, 50)]
    public required string AccountNumberMasked { get; set; }

    [Length(1, 50)]
    public required string PlaidAccountId { get; set; }

    public int OwnerId { get; set; }

    [Required]
    public Owner Owner { get; set; }
}
