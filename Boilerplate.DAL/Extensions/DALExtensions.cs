using Boilerplate.DAL.Configuration;
using Boilerplate.Data;
using Boilerplate.Domain.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Boilerplate.DAL.Extensions;

public static class DALExtensions
{
    public static IServiceCollection AddDALInMemoryDatabase(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDALServices();

        services.AddDbContext<ApplicationDbContext>(
            options => options.UseInMemoryDatabase("AppDb"));

        return services;
    }

    public static IServiceCollection AddDALSqlServerDatabase(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDALServices();

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(new DatabaseConfiguration(configuration).ConnectionString));

        return services;
    }

    public static IServiceCollection AddDALPostgreSQLDatabase(this IServiceCollection services,
        IConfiguration configuration)
    {

        services.AddDALServices();

        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(new DatabaseConfiguration(configuration).ConnectionString));

        return services;
    }

    private static IServiceCollection AddDALServices(this IServiceCollection services)
    {
        services.AddScoped<IDatabaseConfiguration, DatabaseConfiguration>();
        
        return services;
    }
}