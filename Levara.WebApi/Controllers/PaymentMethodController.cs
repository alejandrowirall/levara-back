using Levara.Application.PaymentMethods.Get;
using Levara.Domain.Authentication;
using Levara.Shared.Domain.Bus.Queries;
using Levara.WebApi.Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Levara.WebApi.Controllers;

[Route("api/payment-method")]
[ApiController]
[AuthorizeAnyRoles(Roles.Admin, Roles.Owner, Roles.Tenant)]
public class PaymentMethodController : ControllerBase
{
    private readonly IQueryBus _queryBus;

    public PaymentMethodController(IQueryBus queryBus)
    {
        _queryBus = queryBus;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {

        var response = await _queryBus.Ask(new GetPaymentMethodQuery());
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
