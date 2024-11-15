using Levara.Application.Identity.ConfirmEmail;
using Levara.Application.Identity.Login;
using Levara.Application.Identity.Refresh;
using Levara.Application.Identity.Register;
using Levara.Domain.Contexts;
using Levara.Shared.Domain.Bus.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Levara.Controllers
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
