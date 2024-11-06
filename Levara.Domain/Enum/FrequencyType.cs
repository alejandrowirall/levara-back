
using System.ComponentModel;

namespace Levara.Domain.Enum;

public enum FrequencyType
{
    [Description("Daily")]
    Daily = 1,

    [Description("Weekly")]
    Weekly = 2,

    [Description("Monthly")]
    Monthly = 3,

    [Description("Annual")]
    Annual = 4
}
