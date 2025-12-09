using Levara.Domain.Authentication;
using Levara.WebApi.Configurations;
using System.Security.Claims;

namespace Levara.WebApi.Infrastructure.Middlewares;
public class LevaraApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private const string ApiKeyHeaderName = "X-API-KEY";
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ApiKeyConfiguration _apiKeyConfiguration;

    public LevaraApiKeyMiddleware(RequestDelegate next, 
        IConfiguration configuration, 
        IHttpContextAccessor httpContextAccessor,
        ApiKeyConfiguration apiKeyConfiguration)
    {
        _next = next;
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
        _apiKeyConfiguration = apiKeyConfiguration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey))
        {
            

            if (_apiKeyConfiguration.ApiKey == extractedApiKey)
            {
                // Inyectar UserContext basado en la API Key
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, "0"),
                    new Claim(ClaimTypes.Name, _apiKeyConfiguration.Name),
                    new Claim(ClaimTypes.Role, Roles.Admin), // Ejemplo: roles asociados a la API Key
                };

                var identity = new ClaimsIdentity(claims, "ApiKey");
                context.User = new ClaimsPrincipal(identity);
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Invalid API Key.");
                return;
            }
        }

        await _next(context);
    }
}
