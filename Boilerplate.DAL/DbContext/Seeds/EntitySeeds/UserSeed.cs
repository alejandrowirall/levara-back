using Boilerplate.Domain.Authentication;
using Boilerplate.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.DAL.DbContext.Seeds.EntitySeeds
{
    public class UserSeed : SeedBase
    {
        protected override void Execute()
        {
            var userHasher = new PasswordHasher<ApplicationUser>();

            List<ApplicationUser> allUsersToAdd = new()
            {
                new ApplicationUser
                {
                    Id = 1,
                    Email = "admin@levara.com",
                    EmailConfirmed = true,
                    NormalizedEmail = "ADMIN@LEVARA.COM",
                    NormalizedUserName = "ADMIN@LEVARA.COM",
                    PasswordHash = userHasher.HashPassword(null, "Levara.2024"),
                    ConcurrencyStamp = "admin@levara.com",
                    UserName = "admin@levara.com",
                    RefreshToken = Guid.NewGuid().ToString(),
                },
                new ApplicationUser
                {
                    Id = 2,
                    Email = "owner@levara.com",
                    EmailConfirmed = true,
                    NormalizedEmail = "OWNER@LEVARA.COM",
                    NormalizedUserName = "OWNER@LEVARA.COM",
                    PasswordHash = userHasher.HashPassword(null, "Levara.2024"),
                    ConcurrencyStamp = "owner@levara.com",
                    UserName = "owner@levara.com",
                    RefreshToken = Guid.NewGuid().ToString(),
                },
                new ApplicationUser
                {
                    Id = 3,
                    Email = "tenant@levara.com",
                    EmailConfirmed = true,
                    NormalizedEmail = "TENANT@LEVARA.COM",
                    NormalizedUserName = "TENANT@LEVARA.COM",
                    PasswordHash = userHasher.HashPassword(null, "Levara.2024"),
                    ConcurrencyStamp = "tenant@levara.com",
                    UserName = "tenant@levara.com",
                    RefreshToken = Guid.NewGuid().ToString(),
                }
            };

            this.modelBuilder.Entity<ApplicationUser>().HasData(allUsersToAdd);

        }
    }
}
