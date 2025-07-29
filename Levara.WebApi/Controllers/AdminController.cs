using Levara.Application.Admins.GetDashboard;
using Levara.Domain.Authentication;
using Levara.Shared.Domain.Bus.Queries;
using Levara.WebApi.Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Levara.WebApi.Controllers;

[Route("api/admin")]
[ApiController]
[AuthorizeAnyRoles(Roles.Admin)]
public class AdminController : ControllerBase
{
    private readonly IQueryBus _queryBus;

    public AdminController(IQueryBus queryBus)
    {
        _queryBus = queryBus;
    }

    [HttpGet("dashboard")]
    public async Task<IActionResult> GetDashboard()
    {
        var query = new GetAdminDashboardQuery();
        var response = await _queryBus.Ask(query);
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
