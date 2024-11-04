
using Levara.Domain.Authentication;
using Levara.Domain.Configurations;
using Levara.Domain.ExternalServices;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Extensions;
using Levara.Shared.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;

namespace Levara.Application.Identity.Register;

public class RegisterCommandHandler : ICommandHandler<RegisterCommand, RegisterCommandResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserStore<ApplicationUser> _userStore;
    private readonly IEmailService _emailSender;
    private readonly IAuthConfiguration _authConfiguration;
    public RegisterCommandHandler(UserManager<ApplicationUser> userManager,
        IUserStore<ApplicationUser> userStore,
        IEmailService emailSender,
        IAuthConfiguration authConfiguration)
    {
        _userManager = userManager;
        _userStore = userStore;
        _emailSender = emailSender;
        _authConfiguration = authConfiguration;
    }

    public async Task<OperationResult<RegisterCommandResponse>> Handle(RegisterCommand command)
    {
        var emailStore = (IUserEmailStore<ApplicationUser>)_userStore;

        var user = new ApplicationUser();
        user.RefreshToken = Guid.NewGuid().ToString();

        await _userStore.SetUserNameAsync(user, command.Email, CancellationToken.None);
        await emailStore.SetEmailAsync(user, command.Email, CancellationToken.None);
        

        var result = await _userManager.CreateAsync(user, command.Password);
        if (!result.Succeeded)
            return OperationResult<RegisterCommandResponse>.ErrorResult(new ErrorDetails(400, result.ToString()));

        var addRolesResult = await _userManager.AddToRolesAsync(user, new string[] { Roles.Admin });
        if (!addRolesResult.Succeeded)
            return OperationResult<RegisterCommandResponse>.ErrorResult(new ErrorDetails(400, addRolesResult.Errors.ToString()));

        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

        var baseUri = new Uri(_authConfiguration.BaseAddress);
        var uriBuilder = new UriBuilder(baseUri)
        {
            Path = _authConfiguration.ConfirmEmailEndpoint
        };

        Dictionary<string, string> queryParams = new() { { "UserId", user.Id.ToString() }, { "Code", code } };

        var confirmEmailUrl = QueryHelpers.AddQueryString(uriBuilder.Uri.ToString(), queryParams);

        string content = Assembly.Load("Levara.Application").GetResourceAsString("Levara.Application.Identity.Register.ConfirmationEmail.html");

        content = content.Replace("{{UserName}}", user.Email)
                         .Replace("{{ConfirmationLink}}", HtmlEncoder.Default.Encode(confirmEmailUrl));

        await _emailSender.SendEmailAsync(user.Email, "Confirm Your Email Address to Complete Your Registration", content);

        var response = new RegisterCommandResponse()
        {
            Message = "Confirm Your Email Address to Complete Your Registration"
        };

        return OperationResult<RegisterCommandResponse>.SuccessResult(response);
    }
}
