using Boilerplate.Application.Identity.Services.Jwt;
using Boilerplate.Domain.Configurations;
using Boilerplate.Domain.Models;
using Boilerplate.Shared.Domain.Bus.Commands;
using Boilerplate.Shared.Results;
using Microsoft.AspNetCore.Identity;

namespace Boilerplate.Application.Identity.Refresh;

public class RefreshCommandHandler : ICommandHandler<RefreshCommand, RefreshCommandResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly JwtService _jwtService;
    private readonly IAuthConfiguration _authConfiguration;
    public RefreshCommandHandler(UserManager<ApplicationUser> userManager,
        JwtService jwtService,
        IAuthConfiguration authConfiguration)
    {
        _userManager = userManager;
        _jwtService = jwtService;
        _authConfiguration = authConfiguration;
    }

    public async Task<OperationResult<RefreshCommandResponse>> Handle(RefreshCommand command)
    {
        _jwtService.GetPrincipalFromToken(command.Access_token);

        var principal = _jwtService.GetPrincipalFromToken(command.Access_token, validateExpiration: false);
        var username = principal.Identity.Name;

        var user = await _userManager.FindByEmailAsync(username);

        if (user.RefreshToken != command.Refresh_token)
            return OperationResult<RefreshCommandResponse>.ErrorResult(new ErrorDetails(403, "Invalid refreshToken"));

        string acessToken = await _jwtService.GenerateAccessToken(user);

        RefreshCommandResponse response = new()
        {
            Access_token = acessToken,
            Refresh_token = user.RefreshToken,
            Token_type = "Bearer",
            Expires_in = Convert.ToInt32(TimeSpan.FromMinutes(_authConfiguration.ExpirationMinutes).TotalSeconds)
        };

        return OperationResult<RefreshCommandResponse>.SuccessResult(response);
    }
}
