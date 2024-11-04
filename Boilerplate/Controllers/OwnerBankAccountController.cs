using Levara.Application.OwnersBankAccounts.Create;
using Levara.Application.OwnersBankAccounts.Delete;
using Levara.Application.OwnersBankAccounts.GetByGrid;
using Levara.Application.OwnersBankAccounts.GetForCreate;
using Levara.Application.OwnersBankAccounts.GetForUpdate;
using Levara.Application.OwnersBankAccounts.Update;
using Levara.Domain.Authentication;
using Levara.Domain.Contexts;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Domain.Bus.Queries;
using Levara.WebApi.Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Levara.WebApi.Controllers
{
    [Route("api/owner-bank-account")]
    [ApiController]
    [AuthorizeAnyRoles(Roles.Admin, Roles.Owner)]
    public class OwnerBankAccountController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;
        private readonly IUserContext _userContext;
        public OwnerBankAccountController(ICommandBus commandBus,
            IQueryBus queryBus,
            IUserContext userContext) 
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
            _userContext = userContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetByGrid([FromQuery] GetOwnerBankAccountsByGridQuery query)
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
            var response = await _queryBus.Ask(new GetOwnerBankAccountForCreateQuery());
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
        public async Task<IActionResult> Create([FromBody] CreateOwnerBankAccountCommand command)
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
        public async Task<IActionResult> Update([FromQuery] GetOwnerBankAccountForUpdateQuery query)
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
        public async Task<IActionResult> Update([FromBody] UpdateOwnerBankAccountCommand command)
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
        public async Task<IActionResult> Delete([FromRoute] DeleteOwnerBankAccountCommand command)
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
