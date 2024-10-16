
namespace Boilerplate.Shared.Domain.Models;

public class ListModel
{
    public required int Id { get; set; }
    public required string Text { get; set; }
    public bool Selected { get; set; }
}
