using Levara.DAL.Configuration;
using Levara.DAL.DbContext;
using Levara.Domain.Configurations;
using Levara.Domain.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Reflection;

namespace Levara.DAL.Extensions;

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

        var dataSourceBuilder = new NpgsqlDataSourceBuilder(new DatabaseConfiguration(configuration).ConnectionString);
        dataSourceBuilder.UseJsonNet();
        var dataSource = dataSourceBuilder.Build();

        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(dataSource));

        return services;
    }

    private static IServiceCollection AddDALServices(this IServiceCollection services)
    {
        services.AddScoped<IDatabaseConfiguration, DatabaseConfiguration>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<UnitOfWork>(provider => (UnitOfWork)provider.GetRequiredService<IUnitOfWork>());

        services.AddRepositories();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        var assembly = Assembly.GetExecutingAssembly();

        var repositoryTypes = assembly.GetTypes()
        .Where(t => t.IsClass && !t.IsAbstract &&
                    t.BaseType != null &&
                    t.BaseType.IsGenericType &&
                    t.BaseType.GetGenericTypeDefinition() == typeof(Repository<>));

        foreach (var repositoryType in repositoryTypes)
        {
            var interfaces = repositoryType.GetInterfaces()
                .Where(i => !i.IsGenericType)
                .ToList();

            foreach (var interfaceType in interfaces)
            {
                services.AddScoped(interfaceType, repositoryType);
            }
        }

        return services;
    }
}