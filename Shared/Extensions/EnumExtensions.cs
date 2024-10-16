using Boilerplate.Shared.Domain.Models;
using System.ComponentModel;

namespace Boilerplate.Shared.Extensions;

public static class EnumExtensions
{
    public static List<ListModel> ToListModel<T>() where T : Enum
    {
        return Enum.GetValues(typeof(T))
            .Cast<T>()
            .Select(e => new ListModel
            {
                Id = Convert.ToInt32(e),
                Text = GetEnumDescription(e)
            })
            .ToList();
    }

    private static string GetEnumDescription<T>(T enumValue)
    {
        var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
        var attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

        return attributes != null && attributes.Length > 0 ? attributes[0].Description : enumValue.ToString();
    }
}
