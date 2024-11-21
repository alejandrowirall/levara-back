using Levara.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Levara.Domain.Models;

public abstract class Notification : Entity
{
    public Notification()
    {
        Data = new();
    }
    public NotificationType Type { get; set; }

    [Required]
    [Length(1, 2048)]
    public string Link { get; set; }

    public int ReceiverId { get; set; }

    [Required]
    public ApplicationUser Receiver { get; set; }
    public DateTime? ClickedAt { get; set; }
    public DateTime? ShownAt { get; set; }
    public Dictionary<string, object> Data { get; set; } = new();
    public abstract DisplayNotificationInfo GetDisplayInfo();
}
