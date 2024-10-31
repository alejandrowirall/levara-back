

namespace Boilerplate.Domain.Contexts;

public interface IUserContext
{
    int? Id { get; }

    string? Username { get; }

    bool IsAuthenticated { get; }

    int? OwnerId { get; }

    int? TenantId { get; }

    bool IsAdmin { get; }

    bool IsOwner { get; }

    bool IsTenant { get; }
}
