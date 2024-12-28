
using Levara.Application.Transactions.Create;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Levara.Application.MaintenancesCharges.Create
{
    public class CreateMaintenanceChargeCommand : Command<CreateMaintenanceChargeCommandResponse>
    {

        public int PropertyId { get; set; }
       
        public int EntityId { get; set; }

        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int MaintenanceId { get; set; }


    }
}
