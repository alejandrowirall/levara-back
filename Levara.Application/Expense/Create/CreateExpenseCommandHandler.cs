
using Levara.Application.MaintenancesCharges.Create;
using Levara.DAL.DbContext;
using Levara.DAL.Repositories;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
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
        .Where(t => t.PropertyId == command.PropertyId && t.Title==command.Title &&
         t.TypeId==command.TypeId && t.Description==command.Description ) 
        .FirstOrDefault();        

        Expense expense = new()
        {
            PropertyId = command.PropertyId,
            Title = command.Title,
            TypeId = command.TypeId,
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
