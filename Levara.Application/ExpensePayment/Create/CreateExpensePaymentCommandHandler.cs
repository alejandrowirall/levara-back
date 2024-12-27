
using Levara.Application.MaintenancesCharges.Create;
using Levara.DAL.DbContext;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.ExpensePayments.Create;

public class CreateExpensePaymentCommandHandler : ICommandHandler<CreateExpensePaymentCommand, CreateExpensePaymentCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IExpensePaymentRepository _expensePaymentRepository;
    private readonly ApplicationDbContext _context;
    public CreateExpensePaymentCommandHandler(IUnitOfWork unitOfWork,
        ITransactionRepository transactionRepository, IExpensePaymentRepository expensePaymentRepository, 
        ApplicationDbContext context) 
    {
        _unitOfWork = unitOfWork;
        _transactionRepository = transactionRepository;
        _expensePaymentRepository = expensePaymentRepository;
        _context = context;
    }
    public async Task<OperationResult<CreateExpensePaymentCommandResponse>> Handle(CreateExpensePaymentCommand command)
    {
        //Debo obtener la ultima transaccion de la propiedad para poder luego actualizar el running balance
        //Y el entity Running Balance
        var lastTransaction = _transactionRepository.GetAll()
        .Where(t => t.PropertyId == command.PropertyId) // Filtra por la propiedad
        .OrderByDescending(t => t.CreatedDate) // Ordena por fecha de creación descendente
        .FirstOrDefault();

        decimal nextRunningBalance = 0;
        decimal nextEntityRunningBalance = 0;

        if (lastTransaction != null)
        {
            nextEntityRunningBalance = lastTransaction.EntityRunningBalance + command.Amount;
            nextRunningBalance = lastTransaction.RunningBalance + command.Amount;
        }

        Transaction transaction = new()
        {
            Type = TransactionType.Lease,
            SubType = TransactionSubType.Charge,
            PropertyId = command.PropertyId,
            EntityId = command.ExpenseId,
            Amount=command.Amount,
            Date= command.Date.ToUniversalTime(),
            Description= command.Description, 
            RunningBalance=nextRunningBalance,
            EntityRunningBalance=nextEntityRunningBalance
        };

        ExpensePayment maintenancePayment = new()
        {
            ExpenseId = command.ExpenseId
        };

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {  
            await _transactionRepository.AddAsync(transaction);
            await _context.SaveChangesAsync();

            maintenancePayment.TransactionId = transaction.Id;
            
            await _expensePaymentRepository.AddAsync(maintenancePayment);
            await _context.SaveChangesAsync(); 

            return true;
        });
       

        CreateExpensePaymentCommandResponse response = new ()
        {
            Id = transaction.Id
        };

        return OperationResult<CreateExpensePaymentCommandResponse>.SuccessResult(response);

    }
}
