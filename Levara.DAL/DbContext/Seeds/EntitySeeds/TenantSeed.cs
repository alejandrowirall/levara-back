using Levara.Domain.Authentication;
using Levara.Domain.Models;
using Levara.Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace Levara.DAL.DbContext.Seeds.EntitySeeds;

public class TenantSeed : SeedBase
{
    protected override void Execute()
    {
        var userHasher = new PasswordHasher<ApplicationUser>();

        const string SecurityStampTenant = "eca8a667-056e-4622-9ff6-88cd57ca4b44";
        const string ConcurrencyStampTenant = "c231efea-6e8c-40e5-ae33-f15bc5cfb2a0";
        const string RefreshTokenTenant = "e030be4a-c6ed-46a5-9e86-4ad6db062ed6";

        //HashPassword of Levara.2024
        const string HashPassword = "AQAAAAIAAYagAAAAEPeAV1996kkE+Il+HPFULI7rRDpVhoP89dglukaO/NrGgGDZi0dOyA4AT3rtnrzfrQ==";

        DateTime datatimeApp = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

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
                    PasswordHash = HashPassword,
                    SecurityStamp = SecurityStampTenant,
                    ConcurrencyStamp = ConcurrencyStampTenant,
                    UserName = $"tenant{i}@levara.com",
                    RefreshToken = RefreshTokenTenant,
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
                CreatorId = 1,
                CreatedDate = datatimeApp,
                LastEditorId = 1,
                LastEditedDate = datatimeApp,
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
                AddressId = address.Id,
                ApplicationUserId = user.Id,
                CreatorId = 1,
                CreatedDate = datatimeApp,
                LastEditorId = 1,
                LastEditedDate = datatimeApp,
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
