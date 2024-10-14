
using Microsoft.AspNetCore.Identity;

namespace Boilerplate.Domain.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public string RefreshToken { get; set; }
}
