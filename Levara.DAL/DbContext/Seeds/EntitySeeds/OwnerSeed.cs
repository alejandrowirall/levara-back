using Levara.Domain.Authentication;
using Levara.Domain.Models;
using Levara.Domain.Enum;
using Microsoft.AspNetCore.Identity;


namespace Levara.DAL.DbContext.Seeds.EntitySeeds;

public class OwnerSeed : SeedBase
{
    protected override void Execute()
    {
        var userHasher = new PasswordHasher<ApplicationUser>();

        const string SecurityStampOwner = "eca8a667-056e-4622-9ff6-88cd57ca4b44";
        const string ConcurrencyStampOwner = "2b3ef318-1fd4-498b-b344-f5d676770237";
        const string RefreshTokenOwner = "e030be4a-c6ed-46a5-9e86-4ad6db062ed6";

        DateTime datatimeApp = new DateTime(2024,1,1).Date;

        List<ApplicationUser> allUsersToAdd = new();
        List<IdentityUserRole<int>> userRoles = new();
        List<IdentityUserClaim<int>> userClaims = new();
        List<Address> allAddresssToAdd = new();
        List<Owner> allOwnersToAdd = new();
        List<OwnerBankAccount> allOwnersBankAccounts = new();
        

        for (int i = 1; i < 11; i++)
        {
            ApplicationUser user = 
                new ()
                {
                    Id = i,
                    Email = $"owner{i}@levara.com",
                    EmailConfirmed = true,
                    NormalizedEmail = $"OWNER{i}@LEVARA.COM",
                    NormalizedUserName = $"OWNER{i}@LEVARA.COM",
                    PasswordHash = userHasher.HashPassword(null, "Levara.2024"),
                    SecurityStamp = SecurityStampOwner,
                    ConcurrencyStamp = ConcurrencyStampOwner,
                    UserName = $"owner{i}@levara.com",
                    RefreshToken = RefreshTokenOwner,
                };

            allUsersToAdd.Add(user);

            userRoles.Add(new IdentityUserRole<int> { UserId = i, RoleId = 2 });

            Address address = new()
            {
                Id = i,
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

            Owner owner = new()
            {
                Id = allOwnersToAdd.Count() + 1,
                Name = $"owner{i}",
                Surname = $"owner{i}",
                CompanyName = $"owner{i}",
                Identification = $"{i + 50000000}",
                IdentificationType = IdentificationType.SSN,
                PersonType = PersonType.Individual,
                MobilePhone = "+14844760170",
                Email = $"owner{i}@levara.com",
                AddressId = address.Id,
                ApplicationUserId = user.Id,
                CreatorId = 1,
                CreatedDate = datatimeApp,
                LastEditorId = 1,
                LastEditedDate = datatimeApp,
            };

            allOwnersToAdd.Add(owner);

            OwnerBankAccount ownerBankAccount = new()
            {
                Id = i,
                BankName = "Chase",
                AccountNumberMasked = $"****{1233 + i}",
                PlaidAccountId = $"account-abc{122 + i}",
                OwnerId = owner.Id,
                CreatorId = 1,
                CreatedDate = datatimeApp,
                LastEditorId = 1,
                LastEditedDate = datatimeApp,
            };

            allOwnersBankAccounts.Add(ownerBankAccount);

            userClaims.Add(
                new IdentityUserClaim<int>
                {
                    Id = i,
                    ClaimType = CustomClaimTypes.OwnerId,
                    ClaimValue = owner.Id.ToString(),
                    UserId = user.Id,
                });


        }

        List<Property> allproperties = new();

        foreach (var owner in allOwnersToAdd)
        {
            for (int i = 1; i < 11; i++)
            {
                Address propertyAddress = new()
                {
                    Id = allAddresssToAdd.Count() + 1,
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

                allAddresssToAdd.Add(propertyAddress);

                Property property = new()
                {
                    Id = allproperties.Count() + 1,
                    Number = i,
                    OwnerId = owner.Id,
                    AddressId = propertyAddress.Id,
                    Price = 100000 * i,
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                };

                allproperties.Add(property);
            }
        }

        

        this.modelBuilder.Entity<ApplicationUser>().HasData(allUsersToAdd);
        this.modelBuilder.Entity<IdentityUserRole<int>>().HasData(userRoles);

        this.modelBuilder.Entity<Address>().HasData(allAddresssToAdd);
        this.modelBuilder.Entity<Owner>().HasData(allOwnersToAdd);
        this.modelBuilder.Entity<OwnerBankAccount>().HasData(allOwnersBankAccounts);

        this.modelBuilder.Entity<IdentityUserClaim<int>>().HasData(userClaims);
        
        this.modelBuilder.Entity<Property>().HasData(allproperties);      
    }
}
