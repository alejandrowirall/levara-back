using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.LeasesCharges.Create
{
    public class CreateLeaseChargeCommand : Command<CreateLeaseChargeCommandResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? PropertyId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal? Amount { get; set; }
        
        [Required]
        public DateTime? DueDate { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? LeaseId { get; set; }


    }
}
