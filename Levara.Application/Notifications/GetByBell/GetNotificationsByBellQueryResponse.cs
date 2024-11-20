using Levara.Domain.Models;

namespace Levara.Application.Notifications.GetByBell;

public class GetNotificationsByBellQueryResponse
{
    public GetNotificationsByBellQueryResponse(DisplayNotificationInfo notificationInfo)
    {
        Title = notificationInfo.Title;
        Content = notificationInfo.Content;
        CreatedDate = notificationInfo.CreatedDate;
        Link = notificationInfo.Link;
    }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Link { get; set; }
}
