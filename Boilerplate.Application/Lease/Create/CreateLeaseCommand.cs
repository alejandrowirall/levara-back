
using Boilerplate.Domain.Enum;
using Boilerplate.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Application.Leases.Create
{
    public class CreateLeaseCommand : Command<CreateLeaseCommandResponse>
    {
        [Range(1, int.MaxValue)]
        public int? OwnerId { get; set; }

        [Range(1, int.MaxValue)]
        public int? TenantId { get; set; }

        [Range(1, int.MaxValue)]
        public int? PropertyId { get; set; }

        public FrequencyType Frequency { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal? Price { get; set; }

        

    }
}
