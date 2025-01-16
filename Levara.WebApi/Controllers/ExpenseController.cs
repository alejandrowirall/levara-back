using Levara.Application.Expenses.Create;
using Levara.Application.Expenses.Delete;
using Levara.Application.Expenses.GetByGrid;
using Levara.Application.Expenses.GetForCreate;
using Levara.Application.Expenses.GetForUpdate;
using Levara.Application.Expenses.Update;
using Levara.Domain.Authentication;
using Levara.Domain.Contexts;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Domain.Bus.Queries;
using Levara.WebApi.Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Levara.WebApi.Controllers
{
    [Route("api/expense")]
    [ApiController]
    [AuthorizeAnyRoles(Roles.Admin, Roles.Owner)]
    public class ExpenseController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;
        private readonly IUserContext _userContext;
        public ExpenseController(ICommandBus commandBus,
            IQueryBus queryBus,
            IUserContext userContext) 
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
            _userContext = userContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetByGrid([FromQuery] GetExpenseByGridQuery query)
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
            var response = await _queryBus.Ask(new GetExpenseForCreateQuery());
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
        public async Task<IActionResult> Create([FromBody] CreateExpenseCommand command)
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
        public async Task<IActionResult> Update([FromQuery] GetExpenseForUpdateQuery query)
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
        public async Task<IActionResult> Update([FromBody] UpdateExpenseCommand command)
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
        public async Task<IActionResult> Delete([FromRoute] DeleteExpenseCommand command)
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
