using Levara.Domain.Contexts;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.Expenses.Update;

public class UpdateExpenseCommandHandler : ICommandHandler<UpdateExpenseCommand, UpdateExpenseCommandResponse>
{
    private readonly IUserContext _userContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IExpenseRepository _expenseRepository;
    public UpdateExpenseCommandHandler(IUserContext userContext,
        IUnitOfWork unitOfWork,
        IExpenseRepository expenseRepository) 
    {
        _userContext = userContext;
        _unitOfWork = unitOfWork;
        _expenseRepository = expenseRepository;
    }
    public async Task<OperationResult<UpdateExpenseCommandResponse>> Handle(UpdateExpenseCommand command)
    {
        var expenseQuery = _expenseRepository.GetAll()
                                               .Where(p => p.Id == command.Id!.Value);

        Expense? expense = await _expenseRepository.FirstOrDefaultAsync(expenseQuery);
        if (expense == null)
            return OperationResult<UpdateExpenseCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        if (_userContext.IsOwner && expense.Property.OwnerId != _userContext.OwnerId!.Value)
            return OperationResult<UpdateExpenseCommandResponse>.ErrorResult(new ErrorDetails(403, "The owner does not have permissions to update this expense."));


        expense.PropertyId = command.PropertyId;
        expense.Title = command.Title;
        expense.TypeId = command.TypeId;
        expense.Description = command.Description;
       
        
        await _unitOfWork.ExecuteAsTransactionAsync(() =>
        {
            _expenseRepository.Update(expense);
            return Task.CompletedTask;
        });

        var response = new UpdateExpenseCommandResponse
        {
            Id = expense.Id
        };

        return OperationResult<UpdateExpenseCommandResponse>.SuccessResult(response);

    }
}
