
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.Transactions.Create;

[Obsolete("This handler is deprecated. Use specific transaction factory methods instead.")]
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
        // OBSOLETE: This handler uses deprecated EntityId and EntityRunningBalance properties
        // Use specific transaction factory methods instead (CreateLeaseCharge, CreateLeasePayment, etc.)
        decimal nextRunningBalance = await _transactionRepository.GetLastPropertyRunningBalanceAsync(command.PropertyId);
        
        if (command.SubType == TransactionSubType.Charge) {
            nextRunningBalance = nextRunningBalance - command.Amount;
        }
        else {
            nextRunningBalance = nextRunningBalance + command.Amount;
        }

        Transaction transaction = new()
        {
            Type = command.Type,
            SubType = command.SubType,
            PropertyId = command.PropertyId,
            LeaseId = null, // OBSOLETE: EntityId property removed, use LeaseId for lease transactions
            Amount=command.Amount,
            Date= command.Date.ToUniversalTime(),
            Description= command.Description, 
            RunningBalance=nextRunningBalance,
            LeaseRunningBalance = null // OBSOLETE: EntityRunningBalance renamed to LeaseRunningBalance
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
