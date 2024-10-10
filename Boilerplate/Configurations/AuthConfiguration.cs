
using Boilerplate.Domain.Configurations;

namespace Boilerplate.WebApi.Configurations;

public class AuthConfiguration : IAuthConfiguration
{
    public required string BaseAddress { get; init; }
    public required string ConfirmEmailEndpoint { get; init; }
    public required string JwtKey { get; init; }
    public required string JwtIssuer { get; init; }
    public required string JwtAudience { get; init; }

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
