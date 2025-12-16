using Levara.Domain;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Results;

namespace Levara.Application.ExpenseCharges.Create;

public class CreateExpenseChargeCommandService : Service
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IExpenseRepository _expenseRepository;
    private readonly IExpenseChargeRepository _expenseChargeRepository;
    private readonly IPropertyRepository _propertyRepository;
    public CreateExpenseChargeCommandService(IUnitOfWork unitOfWork,
        ITransactionRepository transactionRepository,
        IExpenseRepository expenseRepository,
        IExpenseChargeRepository expenseChargeRepository,
        IPropertyRepository propertyRepository)
    {
        _unitOfWork = unitOfWork;
        _transactionRepository = transactionRepository;
        _expenseRepository = expenseRepository;
        _expenseChargeRepository = expenseChargeRepository;
        _propertyRepository = propertyRepository;
    }
    public async Task<OperationResult<CreateExpenseChargeCommandResponse>> Handle(CreateExpenseChargeCommand command)
    {

        if (!await _propertyRepository.AnyAsync(p => p.OwnerId == command.OwnerId!.Value &&
                                                     p.Id == command.PropertyId!.Value))
            return OperationResult<CreateExpenseChargeCommandResponse>.ErrorResult(new ErrorDetails(404, $"Not found Property with id {command.PropertyId!.Value} for Owner with id {command.OwnerId!.Value}"));

        var expenseQuery = _expenseRepository.GetAll()
                                             .Where(e => e.Id == command.ExpenseId!.Value);

        Expense? expense = await _expenseRepository.FirstOrDefaultAsync(expenseQuery);
        if (expense == null)
            return OperationResult<CreateExpenseChargeCommandResponse>.ErrorResult(new ErrorDetails(404, $"Not found Expense with id {command.ExpenseId!.Value}"));

        decimal currentPropertyRunningBalance = await _transactionRepository.GetLastPropertyRunningBalanceAsync(command.PropertyId!.Value);

        Transaction newTransaction =
            ExpenseCharge.CreateTransaction(command.PropertyId!.Value,
                                            command.Amount!.Value,
                                            expense.Name,
                                            currentPropertyRunningBalance,
                                            command.DueDate!.Value,
                                            command.Date);

        ExpenseCharge newExpenseCharge = new()
        {
            ExpenseId = command.ExpenseId!.Value,
            Transaction = newTransaction,
        };

        await _transactionRepository.AddAsync(newTransaction);
        await _expenseChargeRepository.AddAsync(newExpenseCharge);

        await _unitOfWork.SaveChangesAsync();

        CreateExpenseChargeCommandResponse response = new()
        {
            Id = newTransaction.Id
        };

        return OperationResult<CreateExpenseChargeCommandResponse>.SuccessResult(response);

    }
}
