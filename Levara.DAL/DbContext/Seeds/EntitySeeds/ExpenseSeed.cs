using Levara.Domain.Models;

namespace Levara.DAL.DbContext.Seeds.EntitySeeds
{
    public class ExpenseSeed : SeedBase
    {
        protected override void Execute()
        {
            DateTime datatimeApp = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var expenses = new List<Expense>
            {
                new Expense
                { 
                    Id = 1, 
                    Name = "Cleaning", 
                    Description = "Cleaning service",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new Expense
                { 
                    Id = 2, 
                    Name = "Gardening", 
                    Description = "Gardening Service",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new Expense
                { 
                    Id = 3, 
                    Name = "Security", 
                    Description = "Security Service",
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                }
            };

            this.modelBuilder.Entity<Expense>().HasData(expenses);
        }
    }
}
