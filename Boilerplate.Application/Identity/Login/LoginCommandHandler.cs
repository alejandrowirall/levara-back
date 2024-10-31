
using Boilerplate.Application.Identity.Services.Jwt;
using Boilerplate.Domain.Configurations;
using Boilerplate.Domain.Models;
using Boilerplate.Shared.Domain.Bus.Commands;
using Boilerplate.Shared.Results;
using Microsoft.AspNetCore.Identity;

namespace Boilerplate.Application.Identity.Login;

public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginCommandResponse>
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly JwtService _jwtService;
    private readonly IAuthConfiguration _authConfiguration;
    public LoginCommandHandler(SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager,
        JwtService jwtService,
        IAuthConfiguration authConfiguration)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _jwtService = jwtService;
        _authConfiguration = authConfiguration;
    }

    public async Task<OperationResult<LoginCommandResponse>> Handle(LoginCommand command)
    {
        var result = await _signInManager.PasswordSignInAsync(command.Email, command.Password, false, lockoutOnFailure: true);
        if (result.RequiresTwoFactor)
        {
            if (!string.IsNullOrEmpty(command.TwoFactorCode))
            {
                result = await _signInManager.TwoFactorAuthenticatorSignInAsync(command.TwoFactorCode, false, rememberClient: false);
            }
            else if (!string.IsNullOrEmpty(command.TwoFactorRecoveryCode))
            {
                result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(command.TwoFactorRecoveryCode);
            }
        }

        if (!result.Succeeded)
            return OperationResult<LoginCommandResponse>.ErrorResult(new ErrorDetails(401, result.ToString()));

        var user = await _userManager.FindByEmailAsync(command.Email);
        if (user == null)
            return OperationResult<LoginCommandResponse>.ErrorResult(new ErrorDetails(404, "User not found"));

        string acessToken = await _jwtService.GenerateAccessToken(user);

        LoginCommandResponse response = new ()
        {
            Access_token = acessToken,
            Refresh_token = user.RefreshToken,
            Token_type = "Bearer",
            Expires_in = Convert.ToInt32(TimeSpan.FromMinutes(_authConfiguration.ExpirationMinutes).TotalSeconds)
        };

        return OperationResult<LoginCommandResponse>.SuccessResult(response);

    }
}
