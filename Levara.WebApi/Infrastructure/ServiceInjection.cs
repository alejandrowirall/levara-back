
using Levara.Application.Extensions;
using Levara.DAL.DbContext;
using Levara.DAL.Extensions;
using Levara.Domain.Configurations;
using Levara.Domain.Contexts;
using Levara.Shared.Domain.Bus.Events;
using Levara.Domain.Models;
using Levara.ExternalService.Emails.Extensions;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Domain.Models;
using Levara.Shared.Infrastructure.Bus.Commands;
using Levara.Shared.Infrastructure.Bus.Query;
using Levara.WebApi.Configurations;
using Levara.WebApi.Infrastructure.Bus.Events;
using Levara.WebApi.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Levara.Infrastructure;
public static class ServiceInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services,
        IConfiguration configuration)
    {

        services.AddConfiguration();
        services.AddAuth(configuration);

        services.AddApplicationService();

        services.AddDALPostgreSQLDatabase(configuration);
        services.AddEmailService(configuration);

        services.AddScoped<ICommandBus, InMemoryCommandBus>();
        services.AddScoped<IQueryBus, InMemoryQueryBus>();

        services.AddScoped<IEventBus, AmazonEventBrige>();
        services.AddScoped<AmazonEventBrige>(provider => (AmazonEventBrige)provider.GetRequiredService<IEventBus>());

        services.Configure<RemoteServicesConfig>(configuration.GetSection("PlaidSettings"));

        services.AddTransient<ApiKeyConfiguration>();

        services.AddInfrastructureSecurity();

        return services;
    }

    private static void AddConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IAuthConfiguration, AuthConfiguration>();
    }

    private static void AddAuth(this IServiceCollection services,
        IConfiguration configuration)
    {
        var authConfiguration = new AuthConfiguration(configuration);

        services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
        {
            options.SignIn.RequireConfirmedEmail = false;
            options.User.RequireUniqueEmail = true;
        })
          .AddDefaultTokenProviders()
          .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = authConfiguration.JwtIssuer,
                ValidAudience = authConfiguration.JwtAudience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authConfiguration.JwtKey))
            };

            options.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = authFailedContext =>
                {
                    if (authFailedContext.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        authFailedContext.Response.Headers.Add("Token-Expired", "true");

                    return Task.CompletedTask;
                }
            };
        });

    }

    private static void AddInfrastructureSecurity(this IServiceCollection services)
    {
        services.AddScoped<IUserContext, WebUserContext>();
        services.AddScoped<ContextIdentifier>();
        services.AddScoped<IContextIdentifier, WebContextIdentifier>();
    }
}
