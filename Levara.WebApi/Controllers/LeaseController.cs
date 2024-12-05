using Levara.Application.Leases.Create;
using Levara.Application.Leases.Delete;
using Levara.Application.Leases.GetByGrid;
using Levara.Application.Leases.GetForCreate;
using Levara.Application.Leases.GetForUpdate;
using Levara.Application.Leases.Update;
using Levara.Domain.Authentication;
using Levara.Domain.Contexts;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Domain.Bus.Queries;
using Levara.WebApi.Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Levara.WebApi.Controllers
{
    [Route("api/lease")]
    [ApiController]
    [AuthorizeAnyRoles(Roles.Admin, Roles.Owner)]
    public class LeaseController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;
        private readonly IUserContext _userContext;
        public LeaseController(ICommandBus commandBus,
            IQueryBus queryBus,
            IUserContext userContext)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
            _userContext = userContext;
        }
        [HttpGet ("GetByGrid")]
        public async Task<IActionResult> GetByGrid([FromQuery] GetLeaseByGridQuery query)
        {
            if (_userContext.IsAdmin && !query.OwnerId.HasValue)
                return BadRequest();

            if (_userContext.IsOwner)
                query.OwnerId = _userContext.OwnerId!;

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
        public async Task<IActionResult> Create([FromQuery] GetLeaseForCreateQuery query )
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLeaseCommand command)
        {
            if (_userContext.IsAdmin && !command.OwnerId.HasValue)
                return BadRequest();

            if (_userContext.IsOwner)
                command.OwnerId = _userContext.OwnerId!;

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


        
        [HttpGet("Update")]
        public async Task<IActionResult> Update([FromQuery] GetLeaseForUpdateQuery query)
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
        public async Task<IActionResult> Update([FromBody] UpdateLeaseCommand command)
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
        public async Task<IActionResult> Delete([FromRoute] DeleteLeaseCommand command)
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
