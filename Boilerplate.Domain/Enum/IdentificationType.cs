
using System.ComponentModel;

namespace Levara.Domain.Enum;

public enum IdentificationType
{
    [Description("Social Security Number")]
    SSN = 1,

    [Description("Passport")]
    Passport = 2,

    [Description("Employer Identification Number")]
    EIN = 3
}
