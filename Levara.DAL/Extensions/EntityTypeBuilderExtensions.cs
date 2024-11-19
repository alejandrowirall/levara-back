using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace Levara.DAL.Extensions;

public static class EntityTypeBuilderExtensions
{
    public static void IgnoreAllPublicProperties<T>(this EntityTypeBuilder<T> builder) where T : class
    {
        var entityType = typeof(T);

        // Get all public properties of the entity that do not come from the base class
        var propertiesToIgnore = entityType
            .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

        foreach (var property in propertiesToIgnore)
        {
            builder.Ignore(property.Name);
        }
    }
}
