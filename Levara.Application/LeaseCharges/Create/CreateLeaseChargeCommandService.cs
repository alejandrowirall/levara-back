using Levara.Domain;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.LeaseCharges.Create;

public class CreateLeaseChargeCommandService : Service
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITransactionRepository _transactionRepository;
    private readonly ILeaseChargeRepository _leaseChargeRepository;
    private readonly ILeaseChargeTypeRepository _leaseChargeTypeRepository;
    private readonly IPropertyRepository _propertyRepository;
    public CreateLeaseChargeCommandService(IUnitOfWork unitOfWork,
        ITransactionRepository transactionRepository, 
        ILeaseChargeRepository leaseChargeRepository,
        ILeaseChargeTypeRepository leaseChargeTypeRepository,
        IPropertyRepository propertyRepository)
    {
        _unitOfWork = unitOfWork;
        _transactionRepository = transactionRepository;
        _leaseChargeRepository = leaseChargeRepository;
        _leaseChargeTypeRepository = leaseChargeTypeRepository;
        _propertyRepository = propertyRepository;
    }
    public async Task<OperationResult<CreateLeaseChargeCommandResponse>> Handle(CreateLeaseChargeCommand command)
    {
        if (!await _propertyRepository.AnyAsync(p => p.OwnerId == command.OwnerId!.Value &&
                                                     p.Id == command.PropertyId!.Value))
            return OperationResult<CreateLeaseChargeCommandResponse>.ErrorResult(new ErrorDetails(404, $"Not found Property with id {command.PropertyId!.Value} for Owner with id {command.OwnerId!.Value}"));

        if (!await _leaseChargeTypeRepository.AnyAsync(lct => lct.Id == command.TypeId))
            return OperationResult<CreateLeaseChargeCommandResponse>.ErrorResult(new ErrorDetails(404, $"Not found LeaseChargeType with id {command.TypeId!.Value}"));

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
            TypeId = command.TypeId!.Value,
            Transaction = newTransaction
        };

        await _transactionRepository.AddAsync(newTransaction);
        await _leaseChargeRepository.AddAsync(newLeaseCharge);

        await _unitOfWork.SaveChangesAsync();

        CreateLeaseChargeCommandResponse response = new()
        {
            Id = newTransaction.Id
        };

        return OperationResult<CreateLeaseChargeCommandResponse>.SuccessResult(response);

    }
}
