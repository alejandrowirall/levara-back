using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.Expenses.Create;

public class CreateExpenseCommandHandler : ICommandHandler<CreateExpenseCommand, CreateExpenseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IExpenseRepository _expenseRepository;


    public CreateExpenseCommandHandler(IUnitOfWork unitOfWork,
         IExpenseRepository expenseRepository) 
    {
        _unitOfWork = unitOfWork;
        _expenseRepository = expenseRepository;
        
    }
    public async Task<OperationResult<CreateExpenseCommandResponse>> Handle(CreateExpenseCommand command)
    {
        var expenseDuplicated = _expenseRepository.GetAll()
                                                  .Where(t => t.Name == command.Name && 
                                                              t.Description==command.Description) 
                                                  .FirstOrDefault();

        if (expenseDuplicated != null)
            return OperationResult<CreateExpenseCommandResponse>.ErrorResult(new ErrorDetails(400, $"Doubled expense"));

        Expense expense = new()
        {
            Name = command.Name,
            Description = command.Description
        };

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            
            await _expenseRepository.AddAsync(expense);

        });


        CreateExpenseCommandResponse response = new ()
        {
            Id = expense.Id
        };

        return OperationResult<CreateExpenseCommandResponse>.SuccessResult(response);

    }
}
