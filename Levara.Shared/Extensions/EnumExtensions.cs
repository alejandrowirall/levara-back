using Levara.Shared.Domain.Models;
using System.ComponentModel;

namespace Levara.Shared.Extensions;

public static class EnumExtensions
{
    public static List<ListModel> ToListModel<T>(int? id = null) where T : Enum
    {
        return Enum.GetValues(typeof(T))
            .Cast<T>()
            .Select(e => new ListModel
            {
                Id = Convert.ToInt32(e),
                Text = GetEnumDescription(e),
                Selected = id.HasValue && Convert.ToInt32(e) == id
            })
            .OrderBy(e => e.Id)
            .ToList();
    }

    public static string GetEnumDescription<T>(T enumValue)
    {
        var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
        var attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

        return attributes != null && attributes.Length > 0 ? attributes[0].Description : enumValue.ToString();
    }
}
