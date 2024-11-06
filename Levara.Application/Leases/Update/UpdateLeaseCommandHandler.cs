using Levara.Domain.Contexts;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.Leases.Update;

public class UpdateLeaseCommandHandler : ICommandHandler<UpdateLeaseCommand, UpdateLeaseCommandResponse>
{
    private readonly IUserContext _userContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILeaseRepository _leaseRepository;
    public UpdateLeaseCommandHandler(IUserContext userContext,
        IUnitOfWork unitOfWork,
        ILeaseRepository leaseRepository) 
    {
        _userContext = userContext;
        _unitOfWork = unitOfWork;
        _leaseRepository = leaseRepository;
    }
    public async Task<OperationResult<UpdateLeaseCommandResponse>> Handle(UpdateLeaseCommand command)
    {
        var propertyQuery = _leaseRepository.GetAllLeases()
                                               .Where(p => p.Id == command.Id!.Value);

        Lease? lease = await _leaseRepository.FirstOrDefaultAsync(propertyQuery);
        if (lease == null)
            return OperationResult<UpdateLeaseCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        if (_userContext.IsOwner && lease.OwnerId != _userContext.OwnerId!.Value)
            return OperationResult<UpdateLeaseCommandResponse>.ErrorResult(new ErrorDetails(403, "The owner does not have permissions to update this property."));


        lease.OwnerId = command.OwnerId!;
        lease.PropertyId = command.PropertyId!;
        lease.TenantId = command.TenantId!;
        lease.DateFrom = command.DateFrom!;
        lease.DateTo = command.DateTo!;
        lease.Amount = command.Price!;

        await _unitOfWork.ExecuteAsTransactionAsync(() =>
        {
            _leaseRepository.Update(lease);
            return Task.CompletedTask;
        });

        var response = new UpdateLeaseCommandResponse
        {
            Id = lease.Id
        };

        return OperationResult<UpdateLeaseCommandResponse>.SuccessResult(response);

    }
}
