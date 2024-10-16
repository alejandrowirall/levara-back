using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Boilerplate.DAL.DbContext.EntityConfigurations;

public static class ModelConfiguration
{
    private static readonly Assembly modelAssembly = Assembly.Load("Boilerplate.DAL");

    public static void ApplyModelAssemblyEntityConfigurations(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(modelAssembly, (type) => type.Namespace == typeof(OwnerConfiguration).Namespace);
    }
}
