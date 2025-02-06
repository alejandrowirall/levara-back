using Levara.Application.BankTransactions.SummaryByMonth;
using Levara.Domain.Contexts;
using Levara.Shared.Domain.Bus.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Levara.WebApi.Controllers
{
    [Route("api/bank-transaction")]
    [ApiController]
    public class BankTransactionController : ControllerBase
    {
        private readonly IQueryBus _queryBus;
        private readonly IUserContext _userContext;
        public BankTransactionController(IQueryBus queryBus,
            IUserContext userContext)
        {
            _queryBus = queryBus;
            _userContext = userContext;
        }

        [HttpGet("summary-by-month")]
        public async Task<IActionResult> GetBalance([FromQuery] GetBankTransSummaryByMonthQuery query)
        {
            if (_userContext.IsAdmin && !query.OwnerId.HasValue)
                return BadRequest();

            if (_userContext.IsOwner)
                query.OwnerId = _userContext.Id!;

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
