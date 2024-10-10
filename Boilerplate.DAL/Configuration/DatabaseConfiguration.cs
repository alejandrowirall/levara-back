using Boilerplate.Domain.Configurations;
using Microsoft.Extensions.Configuration;

namespace Boilerplate.DAL.Configuration;

internal class DatabaseConfiguration : IDatabaseConfiguration
{
    public string ConnectionString { get; init; }

    public DatabaseConfiguration(IConfiguration configuration)
    {
        this.Bind(configuration);
    }

    public DatabaseConfiguration Bind(IConfiguration configuration)
    {
        IConfigurationSection dbhConfig = configuration.GetSection(nameof(DatabaseConfiguration));

        if (dbhConfig.Exists())
            dbhConfig.Bind(this);

        return this;
    }
}
