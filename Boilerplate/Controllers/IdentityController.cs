using Boilerplate.Application.Identity.ConfirmEmail;
using Boilerplate.Application.Identity.Login;
using Boilerplate.Application.Identity.Refresh;
using Boilerplate.Application.Identity.Register;
using Boilerplate.Shared.Domain.Bus.Commands;
using Boilerplate.Shared.Domain.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.Controllers
{
    [Authorize]
    [Route("api/identity")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IUserContext _userContext;
        public IdentityController(ICommandBus commandBus,
            IUserContext userContext)
        {
            _commandBus = commandBus;
            _userContext = userContext;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
        {
            var response = await _commandBus.Dispatch(registerCommand);
            if (!response.Success)
            {
                return new ObjectResult(response)
                {
                    StatusCode = response.Error.StatusCode
                };
            }

            return Ok(response);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            var response = await _commandBus.Dispatch(loginCommand);
            if (!response.Success)
            {
                return new ObjectResult(response)
                {
                    StatusCode = response.Error.StatusCode
                };
            }
                

            return Ok(response.Result);
        }

        [HttpPost("refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> Refresh([FromBody] RefreshCommand refreshCommand)
        {
            var response = await _commandBus.Dispatch(refreshCommand);
            if (!response.Success)
            {
                return new ObjectResult(response)
                {
                    StatusCode = response.Error.StatusCode
                };
            }

            return Ok(response.Result);
        }

        [HttpGet("confirmEmail")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailCommand confirmEmailCommand)
        {
            var response = await _commandBus.Dispatch(confirmEmailCommand);

            return Ok(response);
        }

    }

 }
