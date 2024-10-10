
using Boilerplate.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Boilerplate.Shared.Domain.Bus.Commands;
using Boilerplate.Shared.Results;

namespace Boilerplate.Application.Identity.Login;

public class LoginCommandHandler : ICommandHandler<LoginCommand, bool>
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    public LoginCommandHandler(SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<OperationResult<bool>> Handle(LoginCommand command)
    {
        var useCookieScheme = (command.UseCookies == true) || (command.UseSessionCookies == true);
        var isPersistent = (command.UseCookies == true) && (command.UseSessionCookies != true);

        _signInManager.AuthenticationScheme = useCookieScheme ? IdentityConstants.ApplicationScheme : IdentityConstants.BearerScheme;

        var result = await _signInManager.PasswordSignInAsync(command.Email, command.Password, isPersistent, lockoutOnFailure: true);
        if (result.RequiresTwoFactor)
        {
            if (!string.IsNullOrEmpty(command.TwoFactorCode))
            {
                result = await _signInManager.TwoFactorAuthenticatorSignInAsync(command.TwoFactorCode, isPersistent, rememberClient: isPersistent);
            }
            else if (!string.IsNullOrEmpty(command.TwoFactorRecoveryCode))
            {
                result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(command.TwoFactorRecoveryCode);
            }
        }

        if (!result.Succeeded)
            return OperationResult<bool>.ErrorResult(new ErrorDetails(401, result.ToString()));

        var user = await _userManager.FindByEmailAsync(command.Email);
        if (user == null)
            return OperationResult<bool>.ErrorResult(new ErrorDetails(404, "User not found"));

        return OperationResult<bool>.SuccessResult(true);

    }
}
