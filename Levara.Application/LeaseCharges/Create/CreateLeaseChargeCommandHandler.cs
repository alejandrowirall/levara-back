using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.LeaseCharges.Create;

public class CreateLeaseChargeCommandHandler : ICommandHandler<CreateLeaseChargeCommand, CreateLeaseChargeCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITransactionRepository _transactionRepository;
    private readonly ILeaseChargeRepository _leaseChargeRepository;
    private readonly IPropertyRepository _propertyRepository;
    public CreateLeaseChargeCommandHandler(IUnitOfWork unitOfWork,
        ITransactionRepository transactionRepository, 
        ILeaseChargeRepository leaseChargeRepository,
        IPropertyRepository propertyRepository)
    {
        _unitOfWork = unitOfWork;
        _transactionRepository = transactionRepository;
        _leaseChargeRepository = leaseChargeRepository;
        _propertyRepository = propertyRepository;
    }
    public async Task<OperationResult<CreateLeaseChargeCommandResponse>> Handle(CreateLeaseChargeCommand command)
    {
        if (!await _propertyRepository.AnyAsync(p => p.OwnerId == command.OwnerId!.Value &&
                                                     p.Id == command.PropertyId!.Value))
            return OperationResult<CreateLeaseChargeCommandResponse>.ErrorResult(new ErrorDetails(404, $"Not found Property with id {command.PropertyId!.Value} for Owner with id {command.OwnerId!.Value}"));

        // Obtener balances actuales
        decimal currentPropertyRunningBalance = await _transactionRepository.GetLastPropertyRunningBalanceAsync(command.PropertyId!.Value);
        decimal currentLeaseRunningBalance = await _transactionRepository.GetLastLeaseRunningBalanceAsync(command.LeaseId!.Value);

        Transaction newTransaction =
            LeaseCharge.CreateTransaction(command.PropertyId!.Value,
                command.Amount!.Value,
                command.LeaseId!.Value,
                command.Description!,
                currentPropertyRunningBalance,
                currentLeaseRunningBalance,
                command.DueDate!.Value,
                command.Date);

        LeaseCharge newLeaseCharge = new()
        {
            Description = command.Description!,
            LeaseId = command.LeaseId!.Value,
            Transaction = newTransaction
        };

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _transactionRepository.AddAsync(newTransaction);
            await _leaseChargeRepository.AddAsync(newLeaseCharge);
        });


        CreateLeaseChargeCommandResponse response = new()
        {
            Id = newTransaction.Id
        };

        return OperationResult<CreateLeaseChargeCommandResponse>.SuccessResult(response);

    }
}
