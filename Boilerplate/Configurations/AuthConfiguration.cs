
using Boilerplate.Domain.Configurations;

namespace Boilerplate.WebApi.Configurations;

public class AuthConfiguration : IAuthConfiguration
{
    public string BaseAddress { get; init; }
    public string ConfirmEmailEndpoint { get; init; }
    public string JwtKey { get; init; }
    public string JwtIssuer { get; init; }
    public string JwtAudience { get; init; }
    public int ExpirationMinutes { get; init; }

    public AuthConfiguration(IConfiguration configuration)
    {
        this.Bind(configuration);
    }

    public AuthConfiguration Bind(IConfiguration configuration)
    {
        IConfigurationSection authConfig = configuration.GetSection(nameof(AuthConfiguration));

        if (authConfig.Exists())
            authConfig.Bind(this);

        return this;
    }
}
