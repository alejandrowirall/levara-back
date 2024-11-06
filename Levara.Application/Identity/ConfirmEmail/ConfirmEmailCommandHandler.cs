using Levara.Domain.Configurations;
using Levara.Domain.ExternalServices;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace Levara.Application.Identity.ConfirmEmail;

public class ConfirmEmailCommandHandler : ICommandHandler<ConfirmEmailCommand, ConfirmEmailCommandResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserStore<ApplicationUser> _userStore;
    private readonly IEmailService _emailSender;
    private readonly IAuthConfiguration _authConfiguration;
    public ConfirmEmailCommandHandler(UserManager<ApplicationUser> userManager,
        IUserStore<ApplicationUser> userStore,
        IEmailService emailSender,
        IAuthConfiguration authConfiguration)
    {
        _userManager = userManager;
        _userStore = userStore;
        _emailSender = emailSender;
        _authConfiguration = authConfiguration;
    }

    public async Task<OperationResult<ConfirmEmailCommandResponse>> Handle(ConfirmEmailCommand command)
    {
        if (await _userManager.FindByIdAsync(command.UserId) is not { } user)
            return OperationResult<ConfirmEmailCommandResponse>.ErrorResult(new ErrorDetails(404, "User not found"));

        string code;

        try
        {
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(command.Code));
        }
        catch (FormatException)
        {
            return OperationResult<ConfirmEmailCommandResponse>.ErrorResult(new ErrorDetails(404, "Invalid code"));
        }

        var result = await _userManager.ConfirmEmailAsync(user, code);

        if (!result.Succeeded)
            return OperationResult<ConfirmEmailCommandResponse>.ErrorResult(new ErrorDetails(404, result.ToString()));

        var response = new ConfirmEmailCommandResponse()
        {
            Message = "Thank you for confirming your email"
        };

        return OperationResult<ConfirmEmailCommandResponse>.SuccessResult(response);
    }
}
