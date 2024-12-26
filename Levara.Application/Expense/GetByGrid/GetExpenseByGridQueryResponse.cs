
using Levara.Domain.Enum;
using Levara.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Expenses.GetByGrid;

public class GetExpenseByGridQueryResponse
{
    public GetExpenseByGridQueryResponse(Expense expense)
    {
        Id = expense.Id;
        Title = expense.Title;
        Description = expense.Description;
        TypeId = expense.TypeId;
        Type= expense.Type;
        PropertyId = expense.PropertyId;
        Property= expense.Property;
        Status = expense.Status;
    }
    public int Id { get; set; }
    public string Title { get; set; }

    public string Description { get; set; }

    public int TypeId { get; set; }
    public ExpenseType Type { get; set; }

    public ExpenseStatus Status { get; set; }

    public int PropertyId { get; set; }

    public Property Property { get; set; }
}