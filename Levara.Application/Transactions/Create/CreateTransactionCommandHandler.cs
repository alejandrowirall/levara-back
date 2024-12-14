
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.Transactions.Create;

public class CreateTransactionCommandHandler : ICommandHandler<CreateTransactionCommand, CreateTransactionCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITransactionRepository _transactionRepository;
    public CreateTransactionCommandHandler(IUnitOfWork unitOfWork,
        ITransactionRepository transactionRepository) 
    {
        _unitOfWork = unitOfWork;
        _transactionRepository = transactionRepository;
    }
    public async Task<OperationResult<CreateTransactionCommandResponse>> Handle(CreateTransactionCommand command)
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
            if (command.SubType == TransactionSubType.Charge) {
                nextEntityRunningBalance = lastTransaction.EntityRunningBalance - command.Amount;
                nextRunningBalance = lastTransaction.RunningBalance - command.Amount;
            }
            else {
                nextEntityRunningBalance = lastTransaction.EntityRunningBalance + command.Amount;
                nextRunningBalance = lastTransaction.RunningBalance + command.Amount;
            }
        }

        Transaction transaction = new()
        {
            Type = command.Type,
            SubType = command.SubType,
            PropertyId = command.PropertyId,
            EntityId =command.EntityId,
            Amount=command.Amount,
            Date= command.Date.ToUniversalTime(),
            Description= command.Description, 
            RunningBalance=nextRunningBalance,
            EntityRunningBalance=nextEntityRunningBalance
        };

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _transactionRepository.AddAsync(transaction);

        });

        CreateTransactionCommandResponse response = new ()
        {
            Id = transaction.Id
        };

        return OperationResult<CreateTransactionCommandResponse>.SuccessResult(response);

    }
}
