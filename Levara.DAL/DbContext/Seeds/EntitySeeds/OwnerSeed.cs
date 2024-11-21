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
        const string ConcurrencyStampOwner = "c231efea-6e8c-40e5-ae33-f15bc5cfb2a0";
        const string RefreshTokenOwner = "e030be4a-c6ed-46a5-9e86-4ad6db062ed6";

        //HashPassword of Levara.2024
        const string HashPassword = "AQAAAAIAAYagAAAAEPeAV1996kkE+Il+HPFULI7rRDpVhoP89dglukaO/NrGgGDZi0dOyA4AT3rtnrzfrQ==";

        DateTime datatimeApp = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        List<ApplicationUser> allUsersToAdd = new();
        List<IdentityUserRole<int>> userRoles = new();
        List<IdentityUserClaim<int>> userClaims = new();
        List<Address> allAddresssToAdd = new();
        List<Owner> allOwnersToAdd = new();
        List<OwnerBankAccount> allOwnersBankAccounts = new();

        List<PropertyNotification> propertyNotifications = new();
        List<RentPaymentNotification> rentPaymentNotifications = new();


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
                    PasswordHash = HashPassword,
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

                PropertyNotification propertyNotification = new()
                {
                    Id = propertyNotifications.Count + rentPaymentNotifications.Count + 1,
                    Property = $"Property {property.Number}",
                    Date = datatimeApp.AddDays(-i),
                    Detail = i % 2 == 0 ? "End date to renewal" : "General maintenance scheduled",
                    ReceiverId = owner.ApplicationUserId!.Value,
                    Link = "/owner",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                    Type = NotificationType.Property
                };
                propertyNotifications.Add(propertyNotification);

                RentPaymentNotification rentPaymentNotification = new()
                {
                    Id = propertyNotifications.Count + rentPaymentNotifications.Count + 1,
                    Property = $"Property {property.Number}",
                    DueDate = datatimeApp.AddMonths(-i),
                    Status = i % 2 == 0 ? "Overdue" : "Paid",
                    ReceiverId = owner.ApplicationUserId!.Value,
                    Link = "/owner",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                    Type = NotificationType.RentPayment
                };
                rentPaymentNotifications.Add(rentPaymentNotification);
            }
        }

        

        this.modelBuilder.Entity<ApplicationUser>().HasData(allUsersToAdd);
        this.modelBuilder.Entity<IdentityUserRole<int>>().HasData(userRoles);

        this.modelBuilder.Entity<Address>().HasData(allAddresssToAdd);
        this.modelBuilder.Entity<Owner>().HasData(allOwnersToAdd);
        this.modelBuilder.Entity<OwnerBankAccount>().HasData(allOwnersBankAccounts);

        this.modelBuilder.Entity<IdentityUserClaim<int>>().HasData(userClaims);
        
        this.modelBuilder.Entity<Property>().HasData(allproperties);

        this.modelBuilder.Entity<PropertyNotification>().HasData(propertyNotifications);
        this.modelBuilder.Entity<RentPaymentNotification>().HasData(rentPaymentNotifications);
    }
}
