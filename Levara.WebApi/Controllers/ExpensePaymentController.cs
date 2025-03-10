
using Levara.Application.ExpensePayments.Create;
using Levara.Application.ExpensePayments.GetByGrid;
using Levara.Application.ExpensePayments.GetForCreate;
using Levara.Domain.Authentication;
using Levara.Domain.Contexts;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Domain.Bus.Queries;
using Levara.WebApi.Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Levara.WebApi.Controllers
{
    [Route("api/expense-payment")]
    [ApiController]
    [AuthorizeAnyRoles(Roles.Admin, Roles.Owner)]
    public class ExpensePaymentController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;
        private readonly IUserContext _userContext;
        public ExpensePaymentController(ICommandBus commandBus,
            IQueryBus queryBus,
            IUserContext userContext) 
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
            _userContext = userContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetByGrid([FromQuery] GetExpensePaymentByGridQuery query)
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
            var response = await _queryBus.Ask(new GetExpensePaymentForCreateQuery());
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
        public async Task<IActionResult> Create([FromBody] CreateExpensePaymentCommand command)
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
