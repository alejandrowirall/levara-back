using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.Expenses.Delete;

public class DeleteExpensesCommandHandler : ICommandHandler<DeleteExpenseCommand, DeleteExpenseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IExpenseRepository _expenseRepository;
    public DeleteExpensesCommandHandler(IUnitOfWork unitOfWork,
        IExpenseRepository expenseRepository) 
    {
        _unitOfWork = unitOfWork;
        _expenseRepository = expenseRepository;
    }
    public async Task<OperationResult<DeleteExpenseCommandResponse>> Handle(DeleteExpenseCommand command)
    {
        Expense? expense = await _expenseRepository.GetByIdAsync(command.Id!.Value);
        if (expense == null)
            return OperationResult<DeleteExpenseCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        await _unitOfWork.ExecuteAsTransactionAsync(() =>
        {
            _expenseRepository.Delete(expense);

            return Task.CompletedTask;
        });

        var response = new DeleteExpenseCommandResponse
        {
            Id = expense.Id
        };

        return OperationResult<DeleteExpenseCommandResponse>.SuccessResult(response);
    }
}
