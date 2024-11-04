using Microsoft.AspNetCore.Authorization;

namespace Levara.WebApi.Infrastructure.Attributes;

public class AuthorizeAnyRolesAttribute : AuthorizeAttribute
{
    public AuthorizeAnyRolesAttribute(params string[] roles)
    {
        base.Roles = String.Join(",", roles);
    }
}
