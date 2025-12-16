using Levara.Domain.Models;

namespace Levara.DAL.DbContext.Seeds.EntitySeeds
{
    public class MaintananceTypeSeed : SeedBase
    {
        DateTime datatimeApp = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        protected override void Execute()
        {
            var maintenanceTypes = new List<MaintenanceType>
            {
                new MaintenanceType
                { 
                    Id = 1, 
                    Name = "Plumber", 
                    Description = "Plumber Service",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new MaintenanceType
                { 
                    Id = 2, 
                    Name = "Electrician", 
                    Description = "Electrician Service",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new MaintenanceType
                { 
                    Id = 3, 
                    Name = "OtherService", 
                    Description = "Other Service",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                }
            };

            this.modelBuilder.Entity<MaintenanceType>().HasData(maintenanceTypes);
        }
    }
}
