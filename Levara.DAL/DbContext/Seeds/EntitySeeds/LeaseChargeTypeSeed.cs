using Levara.Domain.Models;

namespace Levara.DAL.DbContext.Seeds.EntitySeeds
{
    public class LeaseChargeTypeSeed : SeedBase
    {
        protected override void Execute()
        {
            DateTime datatimeApp = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var leaseChargeTypes = new List<LeaseChargeType>
            {
                new LeaseChargeType
                { 
                    Id = 1, 
                    Name = "Security Deposit", 
                    Description = "Refundable amount held to cover damages or unpaid rent",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new LeaseChargeType
                { 
                    Id = 2, 
                    Name = "Rent", 
                    Description = "Charge for occupying the property",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new LeaseChargeType
                { 
                    Id = 3, 
                    Name = "Pet Deposit", 
                    Description = "Refundable deposit to cover potential damages caused by pets",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new LeaseChargeType
                { 
                    Id = 4, 
                    Name = "Pet Rent", 
                    Description = "Additional charge for keeping a pet in the property",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                }
            };

            this.modelBuilder.Entity<LeaseChargeType>().HasData(leaseChargeTypes);
        }
    }
}
