using Levara.Domain.Models;

namespace Levara.Application.Expenses.GetByGrid;

public class GetExpenseByGridQueryResponse
{
    public GetExpenseByGridQueryResponse(Expense expense)
    {
        Id = expense.Id;
        Name = expense.Name;
        Description = expense.Description;
    }
    public int Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }
}