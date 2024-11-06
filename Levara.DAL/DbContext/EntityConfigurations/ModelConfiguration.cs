using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Levara.DAL.DbContext.EntityConfigurations;

public static class ModelConfiguration
{
    private static readonly Assembly modelAssembly = Assembly.GetExecutingAssembly();

    public static void ApplyModelAssemblyEntityConfigurations(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(modelAssembly, (type) => type.Namespace == typeof(OwnerConfiguration).Namespace);
    }
}
