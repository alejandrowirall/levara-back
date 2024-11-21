
using Levara.Application.Notifications.GetByBell;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Leases.GetByGrid;

public class GetNotificationsByBellQueryHandler : IQueryHandler<GetNotificationsByBellQuery, CursorPagedList<GetNotificationsByBellQueryResponse>>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IUnitOfWork _unitOfWork;
    public GetNotificationsByBellQueryHandler(INotificationRepository notificationRepository,
        IUnitOfWork unitOfWork) 
    {
        _notificationRepository = notificationRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<OperationResult<CursorPagedList<GetNotificationsByBellQueryResponse>>> Handle(GetNotificationsByBellQuery query)
    {

        var notificationQuery = _notificationRepository.GetAll()
                                                       .Where(n => n.ReceiverId == query.ReceiverId!.Value);

        CursorPagedList<Notification> cursorPagedList = await _notificationRepository.ToListCursorAsync(notificationQuery, query.PageSize!.Value, query.Cursor);

        var unreadNotifications = cursorPagedList.Items.Where(n => n.ShownAt == null);
        if (unreadNotifications.Any())
        {
            await _unitOfWork.ExecuteAsTransactionAsync(() =>
            {
                // TODO: Do with Bulk Update
                var currentDate = DateTime.UtcNow;
                foreach (var notification in unreadNotifications)
                {
                    notification.ShownAt = currentDate;
                    _notificationRepository.Update(notification);
                }

                return Task.CompletedTask;
            });
        }

        var displayNotifications = cursorPagedList.Items.Select(item => new GetNotificationsByBellQueryResponse(item.GetDisplayInfo()));

        CursorPagedList<GetNotificationsByBellQueryResponse> response = new(displayNotifications, cursorPagedList.NextCursor);

        return OperationResult<CursorPagedList<GetNotificationsByBellQueryResponse>>.SuccessResult(response);

    }
}


