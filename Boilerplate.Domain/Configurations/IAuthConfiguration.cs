
namespace Boilerplate.Domain.Configurations;

public interface IAuthConfiguration
{
    public string BaseAddress { get; }

    public string ConfirmEmailEndpoint { get; }

    public string JwtKey { get; }

    public string JwtIssuer { get; }

    public string JwtAudience { get; }

}
