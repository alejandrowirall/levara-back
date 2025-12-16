using Levara.Domain;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Results;

namespace Levara.Application.MaintenancesCharges.Create;

public class CreateMaintenanceChargeCommandService : Service
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMaintenanceChargeRepository _maintenanceChargeRepository;
    private readonly IMaintenanceRepository _maintenanceRepository;
    private readonly IPropertyRepository _propertyRepository;
    public CreateMaintenanceChargeCommandService(IUnitOfWork unitOfWork,
        ITransactionRepository transactionRepository, 
        IMaintenanceChargeRepository maintenanceChargeRepository,
        IMaintenanceRepository maintenanceRepository,
        IPropertyRepository propertyRepository) 
    {
        _unitOfWork = unitOfWork;
        _transactionRepository = transactionRepository;
        _maintenanceChargeRepository = maintenanceChargeRepository;
        _maintenanceRepository = maintenanceRepository;
        _propertyRepository = propertyRepository;
    }
    public async Task<OperationResult<CreateMaintenanceChargeCommandResponse>> Handle(CreateMaintenanceChargeCommand command)
    {
        if (!await _propertyRepository.AnyAsync(p => p.OwnerId == command.OwnerId!.Value &&
                                                     p.Id == command.PropertyId!.Value))
            return OperationResult<CreateMaintenanceChargeCommandResponse>.ErrorResult(new ErrorDetails(404, $"Not found Property with id {command.PropertyId!.Value} for Owner with id {command.OwnerId!.Value}"));

        decimal currentPropertyRunningBalance = await _transactionRepository.GetLastPropertyRunningBalanceAsync(command.PropertyId!.Value);

        Transaction newTransaction = 
            MaintenanceCharge.CreateTransaction(command.PropertyId!.Value,
                                                command.Amount!.Value,
                                                command.Title!,
                                                currentPropertyRunningBalance,
                                                command.DueDate!.Value,
                                                command.Date);

        Maintenance newMaintenance = new()
        {
            PropertyId = command.PropertyId!.Value,
            Title = command.Title!,
            Status = MaintenanceStatus.Completed,
            TypeId = command.TypeId!.Value,
            DueDate = command.DueDate!.Value,
            Description = command.Description!
        };

        MaintenanceCharge maintenanceCharge = new()
        {
            Maintenance = newMaintenance,
            Transaction = newTransaction,
        };

        await _maintenanceRepository.AddAsync(newMaintenance);
        await _transactionRepository.AddAsync(newTransaction);
        await _maintenanceChargeRepository.AddAsync(maintenanceCharge);

        await _unitOfWork.SaveChangesAsync();

        CreateMaintenanceChargeCommandResponse response = new ()
        {
            Id = newTransaction.Id
        };

        return OperationResult<CreateMaintenanceChargeCommandResponse>.SuccessResult(response);

    }
}
