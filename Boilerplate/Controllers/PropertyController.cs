using Boilerplate.Application.Properties.Create;
using Boilerplate.Application.Properties.Delete;
using Boilerplate.Application.Properties.GetByGrid;
using Boilerplate.Application.Properties.GetForCreate;
using Boilerplate.Application.Properties.GetForUpdate;
using Boilerplate.Application.Properties.Update;
using Boilerplate.Domain.Authentication;
using Boilerplate.Domain.Contexts;
using Boilerplate.Shared.Domain.Bus.Commands;
using Boilerplate.Shared.Domain.Bus.Queries;
using Boilerplate.WebApi.Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.WebApi.Controllers
{
    [Route("api/property")]
    [ApiController]
    [AuthorizeAnyRoles(Roles.Admin, Roles.Owner)]
    public class PropertyController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;
        private readonly IUserContext _userContext;
        public PropertyController(ICommandBus commandBus,
            IQueryBus queryBus,
            IUserContext userContext) 
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
            _userContext = userContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetByGrid([FromQuery] GetPropertiesByGridQuery query)
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
        public async Task<IActionResult> Create()
        {
            var response = await _queryBus.Ask(new GetPropertyForCreateQuery());
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
        public async Task<IActionResult> Create([FromBody] CreatePropertyCommand command)
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
        public async Task<IActionResult> Update([FromQuery] GetPropertyForUpdateQuery query)
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
        public async Task<IActionResult> Update([FromBody] UpdatePropertyCommand command)
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
        public async Task<IActionResult> Delete([FromRoute] DeletePropertyCommand command)
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
