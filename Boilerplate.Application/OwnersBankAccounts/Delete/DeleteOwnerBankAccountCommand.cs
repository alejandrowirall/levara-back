
using Boilerplate.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Application.OwnersBankAccounts.Delete
{
    public class DeleteOwnerBankAccountCommand : Command<DeleteOwnerBankAccountCommandResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? Id {  get; set; }
    }
}
