
using Boilerplate.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Application.Owners.Delete
{
    public class DeleteOwnerCommand : Command<DeleteOwnerCommandResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? Id {  get; set; }
    }
}
