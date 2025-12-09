using Levara.Domain.Contexts;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.Maintenances.Update;

public class UpdateMaintenanceCommandHandler : ICommandHandler<UpdateMaintenanceCommand, UpdateMaintenanceCommandResponse>
{
    private readonly IUserContext _userContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMaintenanceRepository _maintenanceRepository;
    public UpdateMaintenanceCommandHandler(IUserContext userContext,
        IUnitOfWork unitOfWork,
        IMaintenanceRepository maintenanceRepository) 
    {
        _userContext = userContext;
        _unitOfWork = unitOfWork;
        _maintenanceRepository = maintenanceRepository;
    }
    public async Task<OperationResult<UpdateMaintenanceCommandResponse>> Handle(UpdateMaintenanceCommand command)
    {
        var maintenanceQuery = _maintenanceRepository.GetAll()
                                               .Where(p => p.Id == command.Id!.Value);

        Maintenance? maintenance = await _maintenanceRepository.FirstOrDefaultAsync(maintenanceQuery);
        if (maintenance == null)
            return OperationResult<UpdateMaintenanceCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        if (_userContext.IsOwner && maintenance.Property.OwnerId != _userContext.OwnerId!.Value)
            return OperationResult<UpdateMaintenanceCommandResponse>.ErrorResult(new ErrorDetails(403, "The owner does not have permissions to update this maintenance."));


        maintenance.PropertyId = command.PropertyId;
        maintenance.Title = command.Title;
        maintenance.Status = command.Status;
        maintenance.TypeId = command.TypeId;
        maintenance.DueDate = command.DueDateDate.Value;
        maintenance.Description = command.Description;
        

        
        await _unitOfWork.ExecuteAsTransactionAsync(() =>
        {
            _maintenanceRepository.Update(maintenance);
            return Task.CompletedTask;
        });

        var response = new UpdateMaintenanceCommandResponse
        {
            Id = maintenance.Id
        };

        return OperationResult<UpdateMaintenanceCommandResponse>.SuccessResult(response);

    }
}
