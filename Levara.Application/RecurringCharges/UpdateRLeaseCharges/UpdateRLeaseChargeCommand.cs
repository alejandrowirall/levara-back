
using Levara.Domain.Enum;
using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.RecurringCharges.UpdateRLeaseCharges
{
    public class UpdateRLeaseChargeCommand : Command<UpdateRLeaseChargeCommandResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? Id { get; set; }

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
        public int? LeaseChargeTypeId { get; set; }

        [Required]
        public bool? Active { get; set; }

        // Requerido si IsRecurrent = false, opcional si IsRecurrent = true
        public List<string>? MatchTags { get; set; }
    }
}
