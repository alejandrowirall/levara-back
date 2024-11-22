namespace Levara.WebApi.Infrastructure.Middlewares;

public static class LevaraExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseLevaraException(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LevaraExceptionMiddleware>();
    }
}
