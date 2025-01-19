
using Levara.Shared.Domain.Bus.Queries;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Expenses.GetForUpdate;

public class GetExpenseForUpdateQuery : Query<GetExpenseForUpdateQueryResponse>
{
    [Required]
    [Range(1, int.MaxValue)]
    public int? Id { get; set; }
}
