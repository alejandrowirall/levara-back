
namespace Levara.Domain.Models;

public class DisplayNotificationInfo
{
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required DateTime CreatedDate { get; set; }
    public required string Link { get; set; }
    public required bool Clicked { get; set; }
}
