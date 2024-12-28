using Levara.Application.JobScheduler.Schedule;
using Levara.Domain.Authentication;
using Levara.Shared.Domain.Bus.Commands;
using Levara.WebApi.Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Levara.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeAnyRoles(Roles.Admin)]
    public class ScheduleJobController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        public ScheduleJobController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var response = await _commandBus.Dispatch(new ScheduleJobsCommand());
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
}
