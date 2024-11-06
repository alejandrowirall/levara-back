
using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Properties.Update
{
    public class UpdatePropertyCommand : Command<UpdatePropertyCommandResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? Id {  get; set; }

        [Required]
        [Length(1, 200)]
        public string? Street { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? StreetNumber { get; set; }

        public string? AdditionalLine { get; set; }

        [Required]
        [Length(1, 20)]
        public string? City { get; set; }

        [Required]
        [Length(1, 20)]
        public string? State { get; set; }

        [Required]
        [Length(1, 20)]
        public string? PostalCode { get; set; }

    }
}
