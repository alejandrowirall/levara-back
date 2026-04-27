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
                new MaintenanceType { Id = 1,  Name = "Plumber",                 Description = "Plumber Service",               Deleted = false, CreatorId = 1, CreatedDate = datatimeApp, LastEditorId = 1, LastEditedDate = datatimeApp },
                new MaintenanceType { Id = 2,  Name = "Electrician",             Description = "Electrician Service",           Deleted = false, CreatorId = 1, CreatedDate = datatimeApp, LastEditorId = 1, LastEditedDate = datatimeApp },
                new MaintenanceType { Id = 3,  Name = "OtherService",            Description = "Other Service",                 Deleted = false, CreatorId = 1, CreatedDate = datatimeApp, LastEditorId = 1, LastEditedDate = datatimeApp },
                new MaintenanceType { Id = 4,  Name = "Mortgage",                Description = "Mortgage Payment",              Deleted = false, CreatorId = 1, CreatedDate = datatimeApp, LastEditorId = 1, LastEditedDate = datatimeApp },
                new MaintenanceType { Id = 5,  Name = "Maintenance Fees",        Description = "Maintenance Fees",              Deleted = false, CreatorId = 1, CreatedDate = datatimeApp, LastEditorId = 1, LastEditedDate = datatimeApp },
                new MaintenanceType { Id = 6,  Name = "Special Maintenance Fees",Description = "Special Maintenance Fees",      Deleted = false, CreatorId = 1, CreatedDate = datatimeApp, LastEditorId = 1, LastEditedDate = datatimeApp },
                new MaintenanceType { Id = 7,  Name = "FPL (Electricity)",       Description = "FPL Electricity Bill",          Deleted = false, CreatorId = 1, CreatedDate = datatimeApp, LastEditorId = 1, LastEditedDate = datatimeApp },
                new MaintenanceType { Id = 8,  Name = "Repairs",                 Description = "General Repairs",               Deleted = false, CreatorId = 1, CreatedDate = datatimeApp, LastEditorId = 1, LastEditedDate = datatimeApp },
                new MaintenanceType { Id = 9,  Name = "Painting",                Description = "Painting Service",              Deleted = false, CreatorId = 1, CreatedDate = datatimeApp, LastEditorId = 1, LastEditedDate = datatimeApp },
                new MaintenanceType { Id = 10, Name = "Bank Fees",               Description = "Bank Fees",                     Deleted = false, CreatorId = 1, CreatedDate = datatimeApp, LastEditorId = 1, LastEditedDate = datatimeApp },
                new MaintenanceType { Id = 11, Name = "Insurance",               Description = "Insurance",                     Deleted = false, CreatorId = 1, CreatedDate = datatimeApp, LastEditorId = 1, LastEditedDate = datatimeApp },
                new MaintenanceType { Id = 12, Name = "Locksmith",               Description = "Locksmith Service",             Deleted = false, CreatorId = 1, CreatedDate = datatimeApp, LastEditorId = 1, LastEditedDate = datatimeApp },
                new MaintenanceType { Id = 13, Name = "Cleaning",                Description = "Cleaning Service",              Deleted = false, CreatorId = 1, CreatedDate = datatimeApp, LastEditorId = 1, LastEditedDate = datatimeApp },
                new MaintenanceType { Id = 14, Name = "Rent Commissions",        Description = "Rent Commissions",              Deleted = false, CreatorId = 1, CreatedDate = datatimeApp, LastEditorId = 1, LastEditedDate = datatimeApp },
                new MaintenanceType { Id = 15, Name = "Accounting",              Description = "Accounting Service",            Deleted = false, CreatorId = 1, CreatedDate = datatimeApp, LastEditorId = 1, LastEditedDate = datatimeApp },
                new MaintenanceType { Id = 16, Name = "Interior Decorator",      Description = "Interior Decorator Service",    Deleted = false, CreatorId = 1, CreatedDate = datatimeApp, LastEditorId = 1, LastEditedDate = datatimeApp },
                new MaintenanceType { Id = 17, Name = "Curtains & Blinds",       Description = "Curtains & Blinds Service",     Deleted = false, CreatorId = 1, CreatedDate = datatimeApp, LastEditorId = 1, LastEditedDate = datatimeApp },
                new MaintenanceType { Id = 18, Name = "AC Maintenance",          Description = "Air Conditioning Maintenance",  Deleted = false, CreatorId = 1, CreatedDate = datatimeApp, LastEditorId = 1, LastEditedDate = datatimeApp },
                new MaintenanceType { Id = 19, Name = "Attorney",                Description = "Attorney / Legal Service",      Deleted = false, CreatorId = 1, CreatedDate = datatimeApp, LastEditorId = 1, LastEditedDate = datatimeApp },
                new MaintenanceType { Id = 20, Name = "Appliances",              Description = "Appliances Service",            Deleted = false, CreatorId = 1, CreatedDate = datatimeApp, LastEditorId = 1, LastEditedDate = datatimeApp },
                new MaintenanceType { Id = 21, Name = "Carpenter",               Description = "Carpentry Service",             Deleted = false, CreatorId = 1, CreatedDate = datatimeApp, LastEditorId = 1, LastEditedDate = datatimeApp },
                new MaintenanceType { Id = 22, Name = "Water",                   Description = "Water Bill",                    Deleted = false, CreatorId = 1, CreatedDate = datatimeApp, LastEditorId = 1, LastEditedDate = datatimeApp },
            };

            this.modelBuilder.Entity<MaintenanceType>().HasData(maintenanceTypes);
        }
    }
}
