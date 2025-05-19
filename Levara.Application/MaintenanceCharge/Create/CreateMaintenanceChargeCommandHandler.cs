using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.MaintenancesCharges.Create;

public class CreateMaintenanceChargeCommandHandler : ICommandHandler<CreateMaintenanceChargeCommand, CreateMaintenanceChargeCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMaintenanceChargeRepository _maintenanceChargeRepository;
    private readonly IMaintenanceRepository _maintenanceRepository;
    public CreateMaintenanceChargeCommandHandler(IUnitOfWork unitOfWork,
        ITransactionRepository transactionRepository, 
        IMaintenanceChargeRepository maintenanceChargeRepository,
        IMaintenanceRepository maintenanceRepository) 
    {
        _unitOfWork = unitOfWork;
        _transactionRepository = transactionRepository;
        _maintenanceChargeRepository = maintenanceChargeRepository;
        _maintenanceRepository = maintenanceRepository;
    }
    public async Task<OperationResult<CreateMaintenanceChargeCommandResponse>> Handle(CreateMaintenanceChargeCommand command)
    {
        var lastTransactionQuery = _transactionRepository.GetAll()
                                                         .Where(t => t.PropertyId == command.PropertyId!.Value)
                                                         .OrderByDescending(t => t.CreatedDate);

        Transaction? lastTransaction = await _transactionRepository.FirstOrDefaultAsync(lastTransactionQuery);
        if (lastTransaction == null)
            return OperationResult<CreateMaintenanceChargeCommandResponse>.ErrorResult(new ErrorDetails(404, $"Not found Transaction with propertyId {command.PropertyId!.Value}"));

        decimal nextRunningBalance = 0;
        decimal nextEntityRunningBalance = 0;

        if (lastTransaction != null)
        {
            nextEntityRunningBalance = lastTransaction.EntityRunningBalance - command.Amount!.Value;
            nextRunningBalance = lastTransaction.RunningBalance - command.Amount!.Value;
        }

        Transaction newTransaction = 
            Transaction.CreateMaintenanceCharge(command.PropertyId!.Value,
                                                command.Amount!.Value,
                                                0,
                                                command.Title,
                                                nextRunningBalance,
                                                nextEntityRunningBalance);

        Maintenance newMaintenance = new()
        {
            PropertyId = command.PropertyId!.Value,
            Title = command.Title,
            Status = MaintenanceStatus.Completed,
            TypeId = command.TypeId!.Value,
            DueDate = command.DueDate!.Value.ToUniversalTime(),
            Description = command.Description
        };

        MaintenanceCharge maintenanceCharge = new()
        {
            DueDate = command.DueDate!.Value.ToUniversalTime(),
            Status = MaintenanceChargeStatus.Unpaid,
            Maintenance = newMaintenance,
            Transaction = newTransaction,
        };

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {  
            await _maintenanceRepository.AddAsync(newMaintenance);
            await _unitOfWork.SaveChangesAsync();

            newTransaction.EntityId = newMaintenance.Id;
            await _transactionRepository.AddAsync(newTransaction);
            await _maintenanceChargeRepository.AddAsync(maintenanceCharge);
        });
       

        CreateMaintenanceChargeCommandResponse response = new ()
        {
            Id = newTransaction.Id
        };

        return OperationResult<CreateMaintenanceChargeCommandResponse>.SuccessResult(response);

    }
}
