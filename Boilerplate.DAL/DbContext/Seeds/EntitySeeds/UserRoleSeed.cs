
using Microsoft.AspNetCore.Identity;

namespace Levara.DAL.DbContext.Seeds.EntitySeeds
{
    public class UserRoleSeed : SeedBase
    {
        protected override void Execute()
        {
            var userRoles = new List<IdentityUserRole<int>>
                    {
                        new IdentityUserRole<int> { UserId = 1, RoleId = 1 }, // Admin Role
                        new IdentityUserRole<int> { UserId = 2, RoleId = 2 }, // Owner Role
                        new IdentityUserRole<int> { UserId = 3, RoleId = 3 }  // Tenant Role
                    };

            this.modelBuilder.Entity<IdentityUserRole<int>>().HasData(userRoles);

        }
    }
}
