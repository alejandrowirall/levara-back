
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Notifications.GetByBell;

public class GetNotificationsByBellQuery : Query<CursorPagedList<GetNotificationsByBellQueryResponse>>
{
    [Range(1, int.MaxValue)]
    public int? Cursor { get; set; }

    [Range(1, int.MaxValue)]
    public int? PageSize { get; set; } = 10;

    [Range(1, int.MaxValue)]
    public int? ReceiverId { get; set; }

}
