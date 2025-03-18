using Levara.Application.Owners.Create;
using Levara.Application.Owners.Delete;
using Levara.Application.Owners.GetBalance;
using Levara.Application.Owners.GetByGrid;
using Levara.Application.Owners.GetDashboard;
using Levara.Application.Owners.GetForCreate;
using Levara.Application.Owners.GetForUpdate;
using Levara.Application.Owners.Update;
using Levara.Domain.Authentication;
using Levara.Domain.Contexts;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Domain.Bus.Queries;
using Levara.WebApi.Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Levara.WebApi.Controllers
{
    [Route("api/owner")]
    [ApiController]
    [AuthorizeAnyRoles(Roles.Admin, Roles.Owner)]
    public class OwnerController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;
        private readonly IUserContext _userContext;
        public OwnerController(ICommandBus commandBus,
            IQueryBus queryBus,
            IUserContext userContext) 
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
            _userContext = userContext;
        }


        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboard([FromQuery] GetOwnerDashboardQuery query)
        {
            if (_userContext.IsAdmin && !query.Id.HasValue)
                return BadRequest();

            if(_userContext.IsOwner)
                query.Id = _userContext.OwnerId!;

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

        [HttpGet("balance")]
        public async Task<IActionResult> GetBalance([FromQuery] GetOwnerBalanceQuery query)
        {
            if (_userContext.IsAdmin && !query.Id.HasValue)
                return BadRequest();

            if (_userContext.IsOwner)
                query.Id = _userContext.OwnerId!;

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

        [HttpGet]
        public async Task<IActionResult> GetByGrid([FromQuery] GetOwnersByGridQuery query)
        {
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
            var response = await _queryBus.Ask(new GetOwnerForCreateQuery());
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
        public async Task<IActionResult> Create([FromBody] CreateOwnerCommand command)
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

        [HttpGet("Update/{Id}")]
        public async Task<IActionResult> Update([FromRoute] GetOwnerForUpdateQuery query)
        {
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

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOwnerCommand command)
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

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteOwnerCommand command)
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
