using Boilerplate.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Boilerplate.Shared.Domain.Bus.Commands;
using Boilerplate.Shared.Results;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Boilerplate.Application.Identity.Refresh;

public class RefreshCommandHandler : ICommandHandler<RefreshCommand, SignInHttpResult>
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IOptionsMonitor<BearerTokenOptions> _bearerTokenOptions;
    private readonly TimeProvider _timeProvider;
    public RefreshCommandHandler(SignInManager<ApplicationUser> signInManager,
        IOptionsMonitor<BearerTokenOptions> bearerTokenOptions,
        TimeProvider timeProvider)
    {
        _signInManager = signInManager;
        _bearerTokenOptions = bearerTokenOptions;
        _timeProvider = timeProvider;
    }

    public async Task<OperationResult<SignInHttpResult>> Handle(RefreshCommand command)
    {
        var refreshTokenProtector = _bearerTokenOptions.Get(IdentityConstants.BearerScheme).RefreshTokenProtector;
        var refreshTicket = refreshTokenProtector.Unprotect(command.RefreshToken);

        // Reject the /refresh attempt with a 401 if the token expired or the security stamp validation fails
        if (refreshTicket?.Properties?.ExpiresUtc is not { } expiresUtc ||
            _timeProvider.GetUtcNow() >= expiresUtc ||
            await _signInManager.ValidateSecurityStampAsync(refreshTicket.Principal) is not ApplicationUser user)
        {
            return OperationResult<SignInHttpResult>.ErrorResult(new ErrorDetails(401, "Reject the /refresh attempt with a 401 if the token expired or the security stamp validation fails"));
        }

        var newPrincipal = await _signInManager.CreateUserPrincipalAsync(user);
        return OperationResult<SignInHttpResult>.SuccessResult(TypedResults.SignIn(newPrincipal, authenticationScheme: IdentityConstants.BearerScheme));
    }
}
