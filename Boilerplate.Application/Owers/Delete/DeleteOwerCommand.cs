
using Boilerplate.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Application.Owers.Delete
{
    public class DeleteOwerCommand : Command<DeleteOwerCommandResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? Id {  get; set; }
    }
}
