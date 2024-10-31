using Boilerplate.Application.Identity.Services.Jwt;
using Boilerplate.Shared.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Boilerplate.Application.Extensions;

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
