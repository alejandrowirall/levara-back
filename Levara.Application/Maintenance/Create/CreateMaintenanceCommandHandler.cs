
using Levara.Application.MaintenancesCharges.Create;
using Levara.DAL.DbContext;
using Levara.DAL.Repositories;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.Maintenances.Create;

public class CreateMaintenanceCommandHandler : ICommandHandler<CreateMaintenanceCommand, CreateMaintenanceCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMaintenanceRepository _maintenanceRepository;


    public CreateMaintenanceCommandHandler(IUnitOfWork unitOfWork,
         IMaintenanceRepository maintenanceRepository) 
    {
        _unitOfWork = unitOfWork;
        _maintenanceRepository = maintenanceRepository;
        
    }
    public async Task<OperationResult<CreateMaintenanceCommandResponse>> Handle(CreateMaintenanceCommand command)
    {
        var maintenanceDuplicated = _maintenanceRepository.GetAll()
        .Where(t => t.PropertyId == command.PropertyId && t.Title==command.Title &&
        t.Status==command.Status && t.TypeId==command.TypeId && t.Description==command.Description ) 
        .FirstOrDefault();        

        Maintenance maintenance = new()
        {
            PropertyId = command.PropertyId,
            Title = command.Title,
            Status = command.Status,
            TypeId = command.TypeId,
            DueDate = command.DueDateFromDate.Value.ToUniversalTime(),
            Description = command.Description
        };

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            
            await _maintenanceRepository.AddAsync(maintenance);

        });


        CreateMaintenanceCommandResponse response = new ()
        {
            Id = maintenance.Id
        };

        return OperationResult<CreateMaintenanceCommandResponse>.SuccessResult(response);

    }
}
