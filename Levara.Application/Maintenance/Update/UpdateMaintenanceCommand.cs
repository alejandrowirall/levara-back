
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Levara.Application.Maintenances.Update
{
    public class UpdateMaintenanceCommand : Command<UpdateMaintenanceCommandResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? Id {  get; set; }
        public string Title { get; set; }

        [Required]
        [Length(1, 200)]
        public string Description { get; set; }

        public int TypeId { get; set; }
        public MaintenanceType Type { get; set; }

        public MaintenanceStatus Status { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public string DueDate { get; set; }

        public DateTime? DueDateDate
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
