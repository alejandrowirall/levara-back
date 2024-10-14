using Boilerplate.Application.Identity;
using Boilerplate.DAL.Extensions;
using Boilerplate.Data;
using Boilerplate.Domain.Configurations;
using Boilerplate.Domain.Models;
using Boilerplate.ExternalService.Emails.Extensions;
using Boilerplate.Shared.Domain.Bus.Commands;
using Boilerplate.Shared.Domain.Bus.Queries;
using Boilerplate.Shared.Domain.Contexts;
using Boilerplate.Shared.Extensions;
using Boilerplate.Shared.Infrastructure.Bus.Commands;
using Boilerplate.Shared.Infrastructure.Bus.Query;
using Boilerplate.WebApi.Configurations;
using Boilerplate.WebApi.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace Boilerplate.Infrastructure;
public static class ServiceInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services,
        IConfiguration configuration)
    {

        services.AddConfiguration();
        services.AddAuth(configuration);

        services.AddApplicationService();

        services.AddDALSqlServerDatabase(configuration);
        services.AddEmailService(configuration);

        services.AddScoped<ICommandBus, InMemoryCommandBus>();
        services.AddScoped<IQueryBus, InMemoryQueryBus>();
        services.AddScoped<IUserContext, WebUserContext>();
        services.AddScoped<JwtService>();


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

    private static void AddAuth(this IServiceCollection services,
        IConfiguration configuration)
    {
        var authConfiguration = new AuthConfiguration(configuration);

        services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
        {
            options.SignIn.RequireConfirmedEmail = true;
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
}
