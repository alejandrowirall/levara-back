
using Boilerplate.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Application.OwnersBankAccounts.Create
{
    public class CreateOwnerBankAccountCommand : Command<CreateOwnerBankAccountCommandResponse>
    {
        [Required]
        [Length(1, 50)]
        public string? BankName { get; set; }

        [Required]
        [Length(4, 50)]
        public string? AccountNumber { get; set; }

        [Required]
        [Length(1, 50)]
        public string? PlaidAccountId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? OwnerId { get; set; }

    }
}
