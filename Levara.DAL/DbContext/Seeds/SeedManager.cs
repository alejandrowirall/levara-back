using Levara.DAL.DbContext.Seeds.EntitySeeds;
using Microsoft.EntityFrameworkCore;

namespace Levara.DAL.DbContext.Seeds;

public class SeedManager
{
    private readonly ModelBuilder modelBuilder;

    public SeedManager(ModelBuilder modelBuilder)
    {
        this.modelBuilder = modelBuilder;
    }

    public void ExecuteSeed()
    {
        //For Debugging the seed
        //if (!System.Diagnostics.Debugger.IsAttached)
        //    System.Diagnostics.Debugger.Launch();

        foreach (var seedClass in GetSeeds())
        {
            seedClass.modelBuilder = modelBuilder;

            seedClass.Process();
        }
    }

    private SeedBase[] GetSeeds()
    {
        return new List<SeedBase> {
            new RoleSeed(),
            new OwnerSeed(),
            new AdminSeed(),
            new MaintananceTypeSeed(),
            new ExpenseSeed(),
        }.ToArray();
    }
}
