using Levara.Application.LeaseChargeTypes.Get;
using Levara.Domain.Authentication;
using Levara.Shared.Domain.Bus.Queries;
using Levara.WebApi.Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Levara.WebApi.Controllers
{
    [Route("api/leaseCharge-type")]
    [ApiController]
    [AuthorizeAnyRoles(Roles.Admin, Roles.Owner)]
    public class LeaseChargeTypeController : ControllerBase
    {
        private readonly IQueryBus _queryBus;

        public LeaseChargeTypeController(IQueryBus queryBus) 
        {
            _queryBus = queryBus;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetLeaseChargeTypeQuery query)
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
