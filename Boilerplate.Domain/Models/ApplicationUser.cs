
using Microsoft.AspNetCore.Identity;

namespace Boilerplate.Domain.Models;

public class ApplicationUser : IdentityUser<int>
{
    public string RefreshToken { get; set; }
}
