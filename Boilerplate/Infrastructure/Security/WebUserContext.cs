
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
    public int Id
    {
        get 
        {
            string? id = _httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id is null)
                return 0;

            int.TryParse(id,  out int userId);

            return userId;
        } 
    }
}
