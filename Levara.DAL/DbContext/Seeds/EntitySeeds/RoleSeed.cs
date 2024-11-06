using Levara.Domain.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Levara.DAL.DbContext.Seeds.EntitySeeds
{
    public class RoleSeed : SeedBase
    {
        protected override void Execute()
        {
            var roles = new List<IdentityRole<int>>
            {
                new IdentityRole<int> { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole<int> { Id = 2, Name = "Owner", NormalizedName = "OWNER" },
                new IdentityRole<int> { Id = 3, Name = "Tenant", NormalizedName = "TENANT" }
            };

            this.modelBuilder.Entity<IdentityRole<int>>().HasData(roles);
        }
    }
}
