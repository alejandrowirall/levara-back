
using Levara.Application.Notifications.GetNewCount;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Leases.GetByGrid;

public class GetNewNotificationsCountQueryHandler : IQueryHandler<GetNewNotificationsCountQuery, GetNewNotificationsCountQueryResponse>
{
    private readonly INotificationRepository _notificationRepository;
    public GetNewNotificationsCountQueryHandler(INotificationRepository notificationRepository) 
    {
        _notificationRepository = notificationRepository;
    }
    public async Task<OperationResult<GetNewNotificationsCountQueryResponse>> Handle(GetNewNotificationsCountQuery query)
    {

        int newNotificationsCount = await _notificationRepository.CountAsync(n =>
                n.ReceiverId == query.ReceiverId!.Value &&
                n.ReadAt == null &&
                n.Id > (
                    _notificationRepository.GetAll()
                        .Where(x => x.ReceiverId == query.ReceiverId!.Value && x.ReadAt != null)
                        .OrderByDescending(x => x.ReadAt)
                        .Select(x => x.Id)
                        .FirstOrDefault()
                )
            );

        GetNewNotificationsCountQueryResponse response = new(newNotificationsCount);
        return OperationResult<GetNewNotificationsCountQueryResponse>.SuccessResult(response);

    }
}


