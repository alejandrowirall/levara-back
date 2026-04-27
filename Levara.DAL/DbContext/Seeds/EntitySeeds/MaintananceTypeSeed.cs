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
                },
                new MaintenanceType
                {
                    Id = 4,
                    Name = "Mortgage",
                    Description = "Mortgage Payment",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new MaintenanceType
                {
                    Id = 5,
                    Name = "Maintenance Fees",
                    Description = "Maintenance Fees",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new MaintenanceType
                {
                    Id = 6,
                    Name = "Special Maintenance Fees",
                    Description = "Special Maintenance Fees",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new MaintenanceType
                {
                    Id = 7,
                    Name = "FPL (Electricity)",
                    Description = "FPL Electricity Bill",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new MaintenanceType
                {
                    Id = 8,
                    Name = "Repairs",
                    Description = "General Repairs",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new MaintenanceType
                {
                    Id = 9,
                    Name = "Painting",
                    Description = "Painting Service",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new MaintenanceType
                {
                    Id = 10,
                    Name = "Bank Fees",
                    Description = "Bank Fees",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new MaintenanceType
                {
                    Id = 11,
                    Name = "Insurance",
                    Description = "Insurance",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new MaintenanceType
                {
                    Id = 12,
                    Name = "Locksmith",
                    Description = "Locksmith Service",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new MaintenanceType
                {
                    Id = 13,
                    Name = "Cleaning",
                    Description = "Cleaning Service",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new MaintenanceType
                {
                    Id = 14,
                    Name = "Rent Commissions",
                    Description = "Rent Commissions",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new MaintenanceType
                {
                    Id = 15,
                    Name = "Accounting",
                    Description = "Accounting Service",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new MaintenanceType
                {
                    Id = 16,
                    Name = "Interior Decorator",
                    Description = "Interior Decorator Service",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new MaintenanceType
                {
                    Id = 17,
                    Name = "Curtains & Blinds",
                    Description = "Curtains & Blinds Service",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new MaintenanceType
                {
                    Id = 18,
                    Name = "AC Maintenance",
                    Description = "Air Conditioning Maintenance",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new MaintenanceType
                {
                    Id = 19,
                    Name = "Attorney",
                    Description = "Attorney / Legal Service",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new MaintenanceType
                {
                    Id = 20,
                    Name = "Appliances",
                    Description = "Appliances Service",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new MaintenanceType
                {
                    Id = 21,
                    Name = "Carpenter",
                    Description = "Carpentry Service",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new MaintenanceType
                {
                    Id = 22,
                    Name = "Water",
                    Description = "Water Bill",
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
