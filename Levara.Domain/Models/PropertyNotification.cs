using Levara.Domain.Enum;

namespace Levara.Domain.Models;

public class PropertyNotification : Notification
{
    public PropertyNotification()
    {
        Type = NotificationType.Property;
    }

    public string Property
    {
        get => Data.ContainsKey(nameof(Property)) ? Data[nameof(Property)].ToString() : string.Empty;
        set => Data[nameof(Property)] = value;
    }

    public DateTime Date
    {
        get => Data.ContainsKey(nameof(Date)) ? (DateTime)Data[nameof(Date)] : DateTime.MinValue;
        set => Data[nameof(Date)] = value;
    }

    public string Detail
    {
        get => Data.ContainsKey(nameof(Detail)) ? Data[nameof(Detail)].ToString() : string.Empty;
        set => Data[nameof(Detail)] = value;
    }

    public override DisplayNotificationInfo GetDisplayInfo()
    {
        return new DisplayNotificationInfo
        {
            Title = $"Important Notification for {Property}",
            Content = $"{Detail} - Date: {Date.ToShortDateString()}",
            CreatedDate = CreatedDate,
            Link = Link,
            Clicked = ClickedAt.HasValue,
        };
    }
}
