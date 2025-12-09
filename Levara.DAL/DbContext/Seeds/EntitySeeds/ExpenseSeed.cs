using Levara.Domain.Models;

namespace Levara.DAL.DbContext.Seeds.EntitySeeds
{
    public class ExpenseSeed : SeedBase
    {
        protected override void Execute()
        {
            var expenses = new List<Expense>
            {
                new Expense{ Id = 1, Name = "Cleaning", Description = "Cleaning service" },
                new Expense{ Id = 2, Name = "Gardening", Description = "Gardening Service" },
                new Expense{ Id = 3, Name = "Security", Description = "Security Service" }
            };

            this.modelBuilder.Entity<Expense>().HasData(expenses);
        }
    }
}
