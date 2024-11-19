using Levara.Domain.Enum;

namespace Levara.Domain.Models;

public class RentPaymentNotification : Notification
{
    public RentPaymentNotification()
    {
        Type = NotificationType.RentPayment;
    }

    public string Property
    {
        get => Data.ContainsKey(nameof(Property)) ? Data[nameof(Property)].ToString() : string.Empty;
        set => Data[nameof(Property)] = value;
    }

    public DateTime DueDate
    {
        get => Data.ContainsKey(nameof(DueDate)) ? (DateTime)Data[nameof(DueDate)] : DateTime.MinValue;
        set => Data[nameof(DueDate)] = value;
    }

    public string Status
    {
        get => Data.ContainsKey(nameof(Status)) ? Data[nameof(Status)].ToString() : string.Empty;
        set => Data[nameof(Status)] = value;
    }
    public override DisplayNotificationInfo GetDisplayInfo()
    {
        return new DisplayNotificationInfo
        {
            Title = "Rent Payment Due",
            Content = $"Rent payment for {Property} is due on {DueDate.ToShortDateString()}. Status: {Status}.",
            CreatedDate = CreatedDate
        };
    }
}
