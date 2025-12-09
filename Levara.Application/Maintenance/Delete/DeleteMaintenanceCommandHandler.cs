using Levara.Domain.Contexts;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.Maintenances.Delete;

public class DeleteMaintananceCommandHandler : ICommandHandler<DeleteMaintenanceCommand, DeleteMaintenanceCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;
    private readonly IMaintenanceRepository _maintenanceRepository;
    public DeleteMaintananceCommandHandler(IUnitOfWork unitOfWork,
        IUserContext userContext,
        IMaintenanceRepository maintenanceRepository) 
    {
        _unitOfWork = unitOfWork;
        _userContext = userContext;
        _maintenanceRepository = maintenanceRepository;
    }
    public async Task<OperationResult<DeleteMaintenanceCommandResponse>> Handle(DeleteMaintenanceCommand command)
    {
        Maintenance? maintenance = await _maintenanceRepository.GetByIdAsync(command.Id!.Value);
        if (maintenance == null)
            return OperationResult<DeleteMaintenanceCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        if(_userContext.IsOwner && maintenance.Property.OwnerId != _userContext.OwnerId!.Value)
            return OperationResult<DeleteMaintenanceCommandResponse>.ErrorResult(new ErrorDetails(403, "The owner does not have permissions to delete this property."));

        await _unitOfWork.ExecuteAsTransactionAsync(() =>
        {
            _maintenanceRepository.Delete(maintenance);

            return Task.CompletedTask;
        });

        var response = new DeleteMaintenanceCommandResponse
        {
            Id = maintenance.Id
        };

        return OperationResult<DeleteMaintenanceCommandResponse>.SuccessResult(response);
    }
}
