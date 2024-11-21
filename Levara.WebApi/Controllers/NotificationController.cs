using Levara.Application.Notifications.GetByBell;
using Levara.Application.Notifications.GetNewCount;
using Levara.Domain.Authentication;
using Levara.Domain.Contexts;
using Levara.Shared.Domain.Bus.Queries;
using Levara.WebApi.Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Levara.WebApi.Controllers;

[Route("api/notification")]
[ApiController]
[AuthorizeAnyRoles(Roles.Admin, Roles.Owner, Roles.Tenant)]
public class NotificationController : ControllerBase
{
    private readonly IQueryBus _queryBus;
    private readonly IUserContext _userContext;

    public NotificationController(IQueryBus queryBus,
        IUserContext userContext)
    {
        _queryBus = queryBus;
        _userContext = userContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetByBell([FromQuery] int? cursor, [FromQuery] int? pageSize)
    {

        var response = await _queryBus.Ask(new GetNotificationsByBellQuery
        {
            ReceiverId = _userContext.Id!,
            Cursor = cursor,
            PageSize = pageSize
        });
        if (!response.Success)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.Error!.StatusCode
            };
        }

        return Ok(response);
    }

    [HttpGet("news")]
    public async Task<IActionResult> GetNewCount()
    {

        var response = await _queryBus.Ask(new GetNewNotificationsCountQuery
        {
            ReceiverId = _userContext.Id!,
        });
        if (!response.Success)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.Error!.StatusCode
            };
        }

        return Ok(response);
    }
}
