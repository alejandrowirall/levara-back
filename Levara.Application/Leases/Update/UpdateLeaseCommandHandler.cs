using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.Leases.Update;

public class UpdateLeaseCommandHandler : ICommandHandler<UpdateLeaseCommand, UpdateLeaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILeaseRepository _leaseRepository;
    public UpdateLeaseCommandHandler(IUnitOfWork unitOfWork,
        ILeaseRepository leaseRepository) 
    {
        _unitOfWork = unitOfWork;
        _leaseRepository = leaseRepository;
    }
    public async Task<OperationResult<UpdateLeaseCommandResponse>> Handle(UpdateLeaseCommand command)
    {
        var leaseQuery = _leaseRepository.GetAllFull()
                                               .Where(l => l.Id == command.Id!.Value && l.OwnerId == command.OwnerId!.Value);

        Lease? lease = await _leaseRepository.FirstOrDefaultAsync(leaseQuery);
        if (lease == null)
            return OperationResult<UpdateLeaseCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));


        lease.TenantId = command.TenantId!.Value;
        lease.Frequency = command.Frequency!.Value;
        lease.DateFrom = command.DateFrom!.Value;
        lease.DateTo = command.DateTo!.Value;
        lease.Amount = command.Price!.Value;
        lease.Status = command.Status!.Value;

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
