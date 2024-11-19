
using Levara.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Levara.DAL.DbContext.Seeds.EntitySeeds;

public class AdminSeed : SeedBase
{
    protected override void Execute()
    {
        var userHasher = new PasswordHasher<ApplicationUser>();

        const string SecurityStampAdmin = "eca8a667-056e-4622-9ff6-88cd57ca4b44";
        const string ConcurrencyStampAdmin = "c231efea-6e8c-40e5-ae33-f15bc5cfb2a0";
        const string RefreshTokenAdmin = "e030be4a-c6ed-46a5-9e86-4ad6db062ed6";

        //HashPassword of Levara.2024
        const string HashPassword = "AQAAAAIAAYagAAAAEPeAV1996kkE+Il+HPFULI7rRDpVhoP89dglukaO/NrGgGDZi0dOyA4AT3rtnrzfrQ==";

        List<ApplicationUser> allUsersToAdd = new()
        {
            new ApplicationUser
            {
                Id = 100,
                Email = "admin@levara.com",
                EmailConfirmed = true,
                NormalizedEmail = "ADMIN@LEVARA.COM",
                NormalizedUserName = "ADMIN@LEVARA.COM",
                PasswordHash = HashPassword,
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
