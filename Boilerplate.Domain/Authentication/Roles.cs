
using System.Reflection;

namespace Boilerplate.Domain.Authentication;

public static class Roles
{
    public const string Admin = "Admin";
    private const int AdminId = 1;

    public const string Owner = "Owner";
    private const int OwnerId = 2;

    public const string Tenant = "Tenant";
    private const int TenantId = 3;

    public static ICollection<string> GetAllRoles()
    {
        var roles = typeof(Roles)
            .GetFields(BindingFlags.Static | BindingFlags.Public)
            .Select(f => f.GetValue(null).ToString());

        return roles.ToList();
    }

    public static int GetId(string rol)
    {
        var publicFields = typeof(Roles).GetFields(BindingFlags.Static | BindingFlags.Public);
        var rolName = publicFields.FirstOrDefault(f => f.GetValue(null).ToString() == rol).Name;

        var idFieldName = $"{rolName}Id";
        var privateFields = typeof(Roles).GetFields(BindingFlags.Static | BindingFlags.NonPublic);
        return int.Parse(privateFields.FirstOrDefault(f => f.Name == idFieldName).GetValue(null).ToString());
    }
}
