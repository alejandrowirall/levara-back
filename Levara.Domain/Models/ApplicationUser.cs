
using Microsoft.AspNetCore.Identity;

namespace Levara.Domain.Models;

public class ApplicationUser : IdentityUser<int>
{
    public string RefreshToken { get; set; }


}
