
using Boilerplate.Shared.Domain.Contexts;
using System.Security.Claims;

namespace Boilerplate.WebApi.Infrastructure.Security;

public class WebUserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public WebUserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public Guid Id
    {
        get 
        {
            string? id = _httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id is null)
                return Guid.Empty;

            Guid userId = Guid.Empty;
            Guid.TryParse(id, out userId);

            return userId;
        } 
    }
}
