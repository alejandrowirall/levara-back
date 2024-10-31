
using Boilerplate.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Boilerplate.DAL.DbContext.Seeds.EntitySeeds;

public class AdminSeed : SeedBase
{
    protected override void Execute()
    {
        var userHasher = new PasswordHasher<ApplicationUser>();

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
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                UserName = "admin@levara.com",
                RefreshToken = Guid.NewGuid().ToString(),
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
