using Boilerplate.DAL.Extensions;
using Boilerplate.Domain.Configurations;
using Boilerplate.ExternalService.Emails.Extensions;
using Boilerplate.Shared.Domain.Bus.Commands;
using Boilerplate.Shared.Domain.Bus.Queries;
using Boilerplate.Shared.Domain.Contexts;
using Boilerplate.Shared.Extensions;
using Boilerplate.Shared.Infrastructure.Bus.Commands;
using Boilerplate.Shared.Infrastructure.Bus.Query;
using Boilerplate.WebApi.Configurations;
using Boilerplate.WebApi.Infrastructure.Security;
using System.Reflection;

namespace Boilerplate.Infrastructure;
public static class ServiceInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services,
        IConfiguration configuration)
    {

        services.AddConfiguration();
        services.AddApplicationService();

        services.AddDALSqlServerDatabase(configuration);
        services.AddEmailService(configuration);

        services.AddScoped<ICommandBus, InMemoryCommandBus>();
        services.AddScoped<IQueryBus, InMemoryQueryBus>();
        services.AddScoped<IUserContext, WebUserContext>();

        return services;
    }

    private static void AddConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IAuthConfiguration, AuthConfiguration>();
    }

    private static void AddApplicationService(this IServiceCollection services)
    {
        var applicationAssembly = Assembly.Load("Boilerplate.Application");
        services.AddQueryServices(applicationAssembly);
        services.AddCommandServices(applicationAssembly);
    }
}
