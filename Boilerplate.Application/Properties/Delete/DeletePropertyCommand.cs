
using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Properties.Delete
{
    public class DeletePropertyCommand : Command<DeletePropertyCommandResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? Id {  get; set; }
    }
}
