
using System.ComponentModel;

namespace Levara.Domain.Enum;

public enum DomainEventStatus
{
    [Description("Created")]
    Created = 1,

    [Description("Processing")]
    Processing = 2,

    [Description("Processed")]
    Processed = 3,

    [Description("Failed")]
    Failed = 4,
}
