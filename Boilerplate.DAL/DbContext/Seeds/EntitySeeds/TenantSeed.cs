using Boilerplate.Domain.Authentication;
using Boilerplate.Domain.Models;
using Boilerplate.Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace Boilerplate.DAL.DbContext.Seeds.EntitySeeds;

public class TenantSeed : SeedBase
{
    protected override void Execute()
    {
        var userHasher = new PasswordHasher<ApplicationUser>();

        List<ApplicationUser> allUsersToAdd = new();
        List<IdentityUserRole<int>> userRoles = new();
        List<IdentityUserClaim<int>> userClaims = new();
        List<Address> allAddresssToAdd = new();
        List<Tenant> allTenantsToAdd = new();
        

        for (int i = 1; i < 11; i++)
        {
            ApplicationUser user =
                new ()
                {
                    Id = i + 50,
                    Email = $"tenant{i}@levara.com",
                    EmailConfirmed = true,
                    NormalizedEmail = $"TENANT{i}@LEVARA.COM",
                    NormalizedUserName = $"TENANT{i}@LEVARA.COM",
                    PasswordHash = userHasher.HashPassword(null, "Levara.2024"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    UserName = $"tenant{i}@levara.com",
                    RefreshToken = Guid.NewGuid().ToString(),
                };

            allUsersToAdd.Add(user);

            userRoles.Add(new IdentityUserRole<int> { UserId = user.Id, RoleId = 3 });

            Address address = new()
            {
                Id = i + 500,
                Street = "Madison Ave",
                Number = 1660,
                AdditionalLine = null,
                City = "New York",
                State = "New York",
                PostalCode = "10029",
                CreatedDate = DateTime.UtcNow,
                LastEditedDate = DateTime.UtcNow,
            };

            allAddresssToAdd.Add(address);

            Tenant tenant = new()
            {
                Id = allTenantsToAdd.Count() + 1,
                Name = $"tenant{i}",
                Surname = $"tenant{i}",
                CompanyName = $"tenant{i}",
                Identification = $"{i + 60000000}",
                IdentificationType = IdentificationType.SSN,
                PersonType = PersonType.Individual,
                MobilePhone = "+14844760170",
                Email = $"tenant{i}@levara.com",
                CreatedDate = DateTime.UtcNow,
                LastEditedDate = DateTime.UtcNow,
                AddressId = address.Id,
                ApplicationUserId = user.Id,
            };

            allTenantsToAdd.Add(tenant);

            userClaims.Add(
                new IdentityUserClaim<int>
                {
                    Id = i + 50,
                    ClaimType = CustomClaimTypes.TenantId,
                    ClaimValue = tenant.Id.ToString(),
                    UserId = user.Id
                });
        }

        this.modelBuilder.Entity<ApplicationUser>().HasData(allUsersToAdd);
        this.modelBuilder.Entity<IdentityUserRole<int>>().HasData(userRoles);

        this.modelBuilder.Entity<Address>().HasData(allAddresssToAdd);
        this.modelBuilder.Entity<Tenant>().HasData(allTenantsToAdd);

        this.modelBuilder.Entity<IdentityUserClaim<int>>().HasData(userClaims);
    }
}
