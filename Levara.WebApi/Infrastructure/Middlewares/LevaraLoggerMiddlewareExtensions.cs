namespace Levara.WebApi.Infrastructure.Middlewares;

public static class LevaraLoggerMiddlewareExtensions
{
    public static IApplicationBuilder UseLevaraLogger(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LevaraLoggerMiddleware>();
    }
}
