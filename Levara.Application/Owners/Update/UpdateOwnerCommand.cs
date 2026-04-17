
using Levara.Domain.Enum;
using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Owners.Update
{
    public class UpdateOwnerCommand : Command<UpdateOwnerCommandResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? Id {  get; set; }
        
        [Required]
        [Length(1, 50)]
        public string? Name { get; set; }

        [Required]
        [Length(1, 50)]
        public string? Surname { get; set; }

        [Required]
        [Length(1, 50)]
        public string? CompanyName { get; set; }

        [Required]
        [Length(1, 50)]
        public string? Identification { get; set; }

        [Required]
        public IdentificationType? IdentificationType { get; set; }

        [Required]
        public PersonType? PersonType { get; set; }

        [Required]
        [Length(1, 15)]
        [Phone]
        public string? MobilePhone { get; set; }

        [Required]
        [Length(1, 320)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [Length(1, 200)]
        public string? Street { get; set; }

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
