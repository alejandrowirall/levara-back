namespace Levara.WebApi.Infrastructure.Middlewares;

public static class LevaraApiKeyMiddlewareExtensions
{
    public static IApplicationBuilder UseLevaraApiKey(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LevaraApiKeyMiddleware>();
    }
}
