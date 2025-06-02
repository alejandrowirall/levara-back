using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.ExpenseCharges.Create;

public class CreateExpenseChargeCommandHandler : ICommandHandler<CreateExpenseChargeCommand, CreateExpenseChargeCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IExpenseRepository _expenseRepository;
    private readonly IExpenseChargeRepository _expenseChargeRepository;
    public CreateExpenseChargeCommandHandler(IUnitOfWork unitOfWork,
        ITransactionRepository transactionRepository,
        IExpenseRepository expenseRepository,
        IExpenseChargeRepository expenseChargeRepository) 
    {
        _unitOfWork = unitOfWork;
        _transactionRepository = transactionRepository;
        _expenseRepository = expenseRepository;
        _expenseChargeRepository = expenseChargeRepository;
    }
    public async Task<OperationResult<CreateExpenseChargeCommandResponse>> Handle(CreateExpenseChargeCommand command)
    {
        var expenseQuery = _expenseRepository.GetAll()
                                             .Where(e => e.Id == command.ExpenseId!.Value);

        Expense? expense = await _expenseRepository.FirstOrDefaultAsync(expenseQuery);
        if(expense == null)
            return OperationResult<CreateExpenseChargeCommandResponse>.ErrorResult(new ErrorDetails(404, $"Not found Expense with id {command.ExpenseId!.Value}"));

        var lastTransactionQuery = _transactionRepository.GetAll()
                                                         .Where(t => t.PropertyId == command.PropertyId!.Value)
                                                         .OrderByDescending(t => t.CreatedDate);

        Transaction? lastTransaction = await _transactionRepository.FirstOrDefaultAsync(lastTransactionQuery);
        if (lastTransaction == null)
            return OperationResult<CreateExpenseChargeCommandResponse>.ErrorResult(new ErrorDetails(404, $"Not found Transaction with propertyId {command.PropertyId!.Value}"));

        decimal nextRunningBalance = 0;
        decimal nextEntityRunningBalance = 0;

        if (lastTransaction != null)
        {
            nextEntityRunningBalance = lastTransaction.EntityRunningBalance - command.Amount!.Value;
            nextRunningBalance = lastTransaction.RunningBalance - command.Amount!.Value;
        }

        Transaction newTransaction = 
            Transaction.CreateExpenseCharge(command.PropertyId!.Value, 
                                            command.Amount!.Value, 
                                            command.ExpenseId!.Value, 
                                            expense.Name, 
                                            nextRunningBalance, 
                                            nextEntityRunningBalance,
                                            command.Date);

        ExpenseCharge newExpenseCharge = new()
        {
            ExpenseId = command.ExpenseId.Value,
            DueDate = command.DueDate!.Value,
            Status = ExpenseChargeStatus.Unpaid,
            Transaction = newTransaction,
        };

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {  
            await _transactionRepository.AddAsync(newTransaction);            
            await _expenseChargeRepository.AddAsync(newExpenseCharge); 
        });

        CreateExpenseChargeCommandResponse response = new ()
        {
            Id = newExpenseCharge.Id
        };

        return OperationResult<CreateExpenseChargeCommandResponse>.SuccessResult(response);

    }
}
