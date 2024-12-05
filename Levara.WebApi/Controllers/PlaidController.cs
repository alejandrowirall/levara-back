using Levara.Application.Owners.Create;
using Levara.Application.Owners.Delete;
using Levara.Application.Owners.GetByGrid;
using Levara.Application.Owners.GetDashboard;
using Levara.Application.Owners.GetForCreate;
using Levara.Application.Owners.GetForUpdate;
using Levara.Application.Owners.Update;
using Levara.Application.Plaid.GetLinkToken;
using Levara.Application.Plaid.GetPublicToken;
using Levara.Application.Plaid.GetTransactionsOwnerFromPlaid;
using Levara.Domain.Authentication;
using Levara.Domain.Contexts;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Domain.Bus.Queries;
using Levara.WebApi.Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Levara.WebApi.Controllers
{
    [Route("api/plaid")]
    [ApiController]
    [AuthorizeAnyRoles(Roles.Admin, Roles.Owner)]
    public class PlaidController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;
        private readonly IUserContext _userContext;
        public PlaidController(ICommandBus commandBus,
            IQueryBus queryBus,
            IUserContext userContext) 
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
            _userContext = userContext;
        }


        [HttpGet("GetLinkToken")]
        public async Task<IActionResult> GetLinkToken([FromQuery] GetLinkTokenQuery query)
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

        [HttpGet("GetPublicToken")]
        public async Task<IActionResult> GetPublicToken([FromQuery] GetPublicTokenQuery query)
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


        [HttpGet("GetTransactionsOwnerFromPlaid")]
        public async Task<IActionResult> GetTransactionsOwnerFromPlaid([FromQuery] GetTransactionsOwnerFromPlaidQuery query)
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

        


    }
}
