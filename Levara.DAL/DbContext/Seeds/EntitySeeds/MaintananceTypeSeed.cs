using Levara.Domain.Authentication;
using Levara.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Levara.DAL.DbContext.Seeds.EntitySeeds
{
    public class MaintananceTypeSeed : SeedBase
    {
        protected override void Execute()
        {
            var maintenanceTypes = new List<MaintenanceType>
            {
                new MaintenanceType{ Id = 1, Name = "Plumber", Description = "Plumber Service" },
                new MaintenanceType{ Id = 2, Name = "Electrician", Description = "Electrician Service" },
                new MaintenanceType{ Id = 3, Name = "OtherService", Description = "Other Service" }
            };

            this.modelBuilder.Entity<MaintenanceType>().HasData(maintenanceTypes);
        }
    }
}
