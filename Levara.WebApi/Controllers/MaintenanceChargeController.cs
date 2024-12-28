using Levara.Application.LeasesCharges.Create;
using Levara.Application.LeasesCharges.GetByGrid;
using Levara.Application.LeasesCharges.GetForCreate;
using Levara.Application.MaintenancesCharges.Create;
using Levara.Application.MaintenancesCharges.GetByGrid;
using Levara.Application.MaintenancesCharges.GetForCreate;
using Levara.Application.Transactions.Create;
using Levara.Application.Transactions.GetByGrid;
using Levara.Application.Transactions.GetForCreate;
using Levara.Domain.Authentication;
using Levara.Domain.Contexts;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Domain.Bus.Queries;
using Levara.WebApi.Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Levara.WebApi.Controllers
{
    [Route("api/maintenance-charge")]
    [ApiController]
    [AuthorizeAnyRoles(Roles.Admin, Roles.Owner)]
    public class MaintenanceChargeController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;
        private readonly IUserContext _userContext;
        public MaintenanceChargeController(ICommandBus commandBus,
            IQueryBus queryBus,
            IUserContext userContext) 
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
            _userContext = userContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetByGrid([FromQuery] GetMaintenanceChargeByGridQuery query)
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
            var response = await _queryBus.Ask(new GetMaintenanceChargeForCreateQuery());
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
        public async Task<IActionResult> Create([FromBody] CreateMaintenanceChargeCommand command)
        {
            
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
