
using Levara.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Levara.DAL.DbContext.Seeds.EntitySeeds;

public class AdminSeed : SeedBase
{
    protected override void Execute()
    {
        var userHasher = new PasswordHasher<ApplicationUser>();

        const string SecurityStampAdmin = "eca8a667-056e-4622-9ff6-88cd57ca4b44";
        const string ConcurrencyStampAdmin = "2b3ef318-1fd4-498b-b344-f5d676770237";
        const string RefreshTokenAdmin = "e030be4a-c6ed-46a5-9e86-4ad6db062ed6";

        List<ApplicationUser> allUsersToAdd = new()
        {
            new ApplicationUser
            {
                Id = 100,
                Email = "admin@levara.com",
                EmailConfirmed = true,
                NormalizedEmail = "ADMIN@LEVARA.COM",
                NormalizedUserName = "ADMIN@LEVARA.COM",
                PasswordHash = userHasher.HashPassword(null, "Levara.2024"),
                SecurityStamp = SecurityStampAdmin,
                ConcurrencyStamp = ConcurrencyStampAdmin,
                UserName = "admin@levara.com",
                RefreshToken = RefreshTokenAdmin,
            }
        };

        List<IdentityUserRole<int>> userRoles = new()
        {
            new IdentityUserRole<int> { UserId = 100, RoleId = 1 }
        };

        this.modelBuilder.Entity<ApplicationUser>().HasData(allUsersToAdd);
        this.modelBuilder.Entity<IdentityUserRole<int>>().HasData(userRoles);

    }
}
