
using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.OwnersBankAccounts.Sync;

public class SyncOwnerBankAccountCommand : Command<SyncOwnerBankAccountCommandResponse>
{
    [Required]
    [Range(1, int.MaxValue)]
    public int? Id { get; set; }

}
