

namespace Levara.WebApi.Configurations;

public class ApiKeyConfiguration
{
    public string ApiKey { get; init; }
    public string Name { get; init; }

    public ApiKeyConfiguration(IConfiguration configuration)
    {
        this.Bind(configuration);
    }

    public ApiKeyConfiguration Bind(IConfiguration configuration)
    {
        IConfigurationSection authConfig = configuration.GetSection(nameof(ApiKeyConfiguration));

        if (authConfig.Exists())
            authConfig.Bind(this);

        return this;
    }
}
