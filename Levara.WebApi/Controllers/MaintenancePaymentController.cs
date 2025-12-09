
using Levara.Application.MaintenancePayments.Create;
using Levara.Application.MaintenancePayments.GetByGrid;
using Levara.Application.MaintenancePayments.GetForCreate;
using Levara.Domain.Authentication;
using Levara.Domain.Contexts;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Domain.Bus.Queries;
using Levara.WebApi.Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Levara.WebApi.Controllers
{
    [Route("api/maintenance-payment")]
    [ApiController]
    [AuthorizeAnyRoles(Roles.Admin, Roles.Owner)]
    public class MaintenancePaymentController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;
        private readonly IUserContext _userContext;
        public MaintenancePaymentController(ICommandBus commandBus,
            IQueryBus queryBus,
            IUserContext userContext) 
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
            _userContext = userContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetByGrid([FromQuery] GetMaintenancePaymentByGridQuery query)
        {
            if (_userContext.IsAdmin && (!query.OwnerId.HasValue|| !query.PropertyId.HasValue))
                return BadRequest();

            if (_userContext.IsOwner)
            {
                query.OwnerId = _userContext.OwnerId!;
            }
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


        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            var response = await _queryBus.Ask(new GetMaintenancePaymentForCreateQuery());
            if (!response.Success)
            {
                return new ObjectResult(response)
                {
                    StatusCode = response.Error!.StatusCode
                };
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMaintenancePaymentCommand command)
        {
            if (_userContext.IsAdmin && (!command.OwnerId.HasValue))
                return BadRequest();

            if (_userContext.IsOwner)
            {
                command.OwnerId = _userContext.OwnerId!;
            }

            var response = await _commandBus.Dispatch(command);
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
