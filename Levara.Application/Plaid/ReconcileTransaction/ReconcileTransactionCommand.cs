using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Plaid.ReconcileTransaction;

public class ReconcileTransactionCommand : Command<ReconcileTransactionCommandResponse>
{
    [Required]
    [Range(1, int.MaxValue)]
    public int? OwnerBankAccountId {  get; set; }

}
