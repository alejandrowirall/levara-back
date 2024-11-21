

namespace Levara.Application.Notifications.GetNewCount;

public class GetNewNotificationsCountQueryResponse
{
    public GetNewNotificationsCountQueryResponse(int count)
    {
        Count = count;
    }
    public int Count { get; set; }
}
