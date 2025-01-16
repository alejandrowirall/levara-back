
using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Levara.Application.Properties.Create
{
    public class CreatePropertyCommand : Command<CreatePropertyCommandResponse>
    {
        [Range(1, int.MaxValue)]
        public int? OwnerId { get; set; }

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

        [Range(0, double.MaxValue)]
        public decimal? Price { get; set; }

        [Range(0, 100)]
        public int? RoomsQuantity { get; set; }
        [Range(0, 100)]
        public int? BathroomQuantity { get; set; }
        
        [Range(0, double.MaxValue)]
        public decimal? AreaQuantity { get; set; }

        public bool? HasPool { get; set; }

        public bool? HasBalcony { get; set; }
        public bool? HasGarage { get; set; }
        [Length(1, 800)]
        public string? DetailDepositAndAdittionalInfo {  get; set; }
        [Length(1, 800)]
        public string? PetsPoliticAndRate  { get; set; }
        [Length(1, 800)]
        public string? TenantRequirements { get; set; }

        public string AvaliableFrom { get; set; }

        public byte[] Img { get; set; }
        public DateTime? AvaliableFromDate
        {
            get
            {
                if (string.IsNullOrWhiteSpace(AvaliableFrom))
                    return null;

                if (DateTime.TryParseExact(AvaliableFrom, "yyyy/dd/MM", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
                {
                    return parsedDate;
                }

                return null; // O lanzar una excepción 
            }
        }
    }
}
