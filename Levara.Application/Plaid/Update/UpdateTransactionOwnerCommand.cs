
using Levara.Domain.Enum;
using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Plaid.Update
{
    public class UpdateTransactionOwnerCommand : Command<UpdateTransactionOwnerCommandResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? PlaidId {  get; set; }
        
        [Required]
        public PlaidTransactionStatus Status { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? PropertyId { get; set; }

        public int? LeaseId { get; set; }

        public TransactionType Category { get; set; }

    }
}
