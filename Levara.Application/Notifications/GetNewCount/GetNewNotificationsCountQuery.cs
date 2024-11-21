
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Notifications.GetNewCount;

public class GetNewNotificationsCountQuery : Query<GetNewNotificationsCountQueryResponse>
{
    [Required]
    [Range(1, int.MaxValue)]
    public int? ReceiverId { get; set; }

}
