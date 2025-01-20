
using Levara.Application.Transactions.Create;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Levara.Application.Maintenances.Create
{
    public class CreateMaintenanceCommand : Command<CreateMaintenanceCommandResponse>
    {

        public string Title { get; set; }

        [Required]
        [Length(1, 200)]
        public string Description { get; set; }

        public int TypeId { get; set; }

        public MaintenanceStatus Status { get; set; }

        public string DueDate { get; set; }

        public int PropertyId { get; set; }

        public DateTime? DueDateFromDate
        {
            get
            {
                if (string.IsNullOrWhiteSpace(DueDate))
                    return null;

                if (DateTime.TryParseExact(DueDate, "yyyy/dd/MM", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
                {
                    return parsedDate;
                }

                return null; // O lanzar una excepción 
            }
        }

    }
}
