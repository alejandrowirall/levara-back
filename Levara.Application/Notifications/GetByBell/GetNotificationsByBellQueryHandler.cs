
using Levara.Application.Notifications.GetByBell;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Leases.GetByGrid;

public class GetNotificationsByBellQueryHandler : IQueryHandler<GetNotificationsByBellQuery, CursorPagedList<GetNotificationsByBellQueryResponse>>
{
    private readonly INotificationRepository _notificationRepository;
    public GetNotificationsByBellQueryHandler(INotificationRepository notificationRepository) 
    {
        _notificationRepository = notificationRepository;
    }
    public async Task<OperationResult<CursorPagedList<GetNotificationsByBellQueryResponse>>> Handle(GetNotificationsByBellQuery query)
    {

        var notificationQuery = _notificationRepository.GetAll()
                                                       .Where(n => n.ReceiverId == query.ReceiverId!.Value);

        CursorPagedList<Notification> cursorPagedList = await _notificationRepository.ToListCursorAsync(notificationQuery, query.PageSize!.Value, query.Cursor);

        var notifications = cursorPagedList.Items.Select(item => new GetNotificationsByBellQueryResponse(item.GetDisplayInfo()));

        CursorPagedList<GetNotificationsByBellQueryResponse> response = new(notifications, cursorPagedList.NextCursor);

        return OperationResult<CursorPagedList<GetNotificationsByBellQueryResponse>>.SuccessResult(response);

    }
}


