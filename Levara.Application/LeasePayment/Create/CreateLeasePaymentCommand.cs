
using Levara.Application.Transactions.Create;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Levara.Application.LeasesPayment.Create
{
    public class CreateLeasePaymentCommand : Command<CreateLeasePaymentCommandResponse>
    {

        public TransactionType Type { get; set; }

        public TransactionSubType SubType { get; set; }

        public int PropertyId { get; set; }
        public Property Property { get; set; }

        public int EntityId { get; set; }

        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal RunningBalance { get; set; }
        public decimal EntityRunningBalance { get; set; }
    }
}
