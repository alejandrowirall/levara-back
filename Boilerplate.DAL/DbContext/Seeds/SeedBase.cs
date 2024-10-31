using Microsoft.EntityFrameworkCore;

namespace Boilerplate.DAL.DbContext.Seeds;

public abstract class SeedBase
{
    public ModelBuilder modelBuilder { get; set; }

    public void Process()
    {
        Execute();
    }

    protected abstract void Execute();
}
