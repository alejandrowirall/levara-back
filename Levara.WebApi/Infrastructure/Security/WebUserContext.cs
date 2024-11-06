
using Levara.Domain.Authentication;
using Levara.Domain.Contexts;
using System.Security.Claims;

namespace Levara.WebApi.Infrastructure.Security;

public class WebUserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public WebUserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public int? Id
    {
        get 
        {
            string? id = _httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id is null)
                return null;

            int.TryParse(id,  out int userId);

            return userId;
        } 
    }

    public bool IsAdmin
    {
        get
        {
            bool? isAdmin = _httpContextAccessor?.HttpContext?.User.FindAll(ClaimTypes.Role).Any(r => r.Value == Roles.Admin);
            if (isAdmin is null)
                return false;

            return isAdmin.Value;
        }
    }

    public bool IsOwner
    {
        get
        {
            bool? isOwner = _httpContextAccessor?.HttpContext?.User.FindAll(ClaimTypes.Role).Any(r => r.Value == Roles.Owner);
            if (isOwner is null)
                return false;

            return isOwner.Value;
        }
    }

    public int? OwnerId
    {
        get
        {
            string? ownerIdClaim = _httpContextAccessor?.HttpContext?.User?.FindFirstValue(CustomClaimTypes.OwnerId);
            if (ownerIdClaim is null)
                return null;

            int.TryParse(ownerIdClaim, out int ownerId);

            return ownerId;
        }
    }

    public bool IsTenant
    {
        get
        {
            bool? isTenant = _httpContextAccessor?.HttpContext?.User.FindAll(ClaimTypes.Role).Any(r => r.Value == Roles.Tenant);
            if (isTenant is null)
                return false;

            return isTenant.Value;
        }
    }

    public int? TenantId
    {
        get
        {
            string? tenantIdClaim = _httpContextAccessor?.HttpContext?.User?.FindFirstValue(CustomClaimTypes.TenantId);
            if (tenantIdClaim is null)
                return null;

            int.TryParse(tenantIdClaim, out int tenantId);

            return tenantId;
        }
    }

    public bool IsAuthenticated
    {
       get 
        {
            bool? isAuthenticated = _httpContextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated;
            if (isAuthenticated is null)
                return false;

            return isAuthenticated.Value;
        }
        
    }

    public string? Username
    {
        get
        {
            return _httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
        }
    }
}
