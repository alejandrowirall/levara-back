using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.RecurringCharges.CreateRMaintenanceCharges
{
    public class CreateRMaintenanceChargeCommand : Command<CreateRMaintenanceChargeCommandResponse>
    {
        [Required]
        public bool? IsRecurrent { get; set; }

        // Campos opcionales (requeridos solo si IsRecurrent = true)
        public FrequencyType? Frequency { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? Amount { get; set; }

        [Range(1, int.MaxValue)]
        public int? OwnerId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? PropertyId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? MaintenanceTypeId { get; set; }

        [Required]
        public bool? Active { get; set; }

        public List<string>? MatchTags { get; set; }
    }
}
