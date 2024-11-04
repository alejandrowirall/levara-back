using Levara.Application.Identity.Services.Jwt;
using Levara.Shared.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Levara.Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddQueryServices(assembly);
        services.AddCommandServices(assembly);

        services.AddScoped<JwtService>();

        return services;
    }
}
