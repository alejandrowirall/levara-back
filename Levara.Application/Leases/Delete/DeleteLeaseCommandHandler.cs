using Levara.Domain.Contexts;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.Leases.Delete;

public class DeleteLeaseCommandHandler : ICommandHandler<DeleteLeaseCommand, DeleteLeaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;
    private readonly ILeaseRepository _leaseRepository;
    public DeleteLeaseCommandHandler(IUnitOfWork unitOfWork,
        IUserContext userContext,
        ILeaseRepository leaseRepository) 
    {
        _unitOfWork = unitOfWork;
        _userContext = userContext;
        _leaseRepository = leaseRepository;
    }
    public async Task<OperationResult<DeleteLeaseCommandResponse>> Handle(DeleteLeaseCommand command)
    {
        Lease? property = await _leaseRepository.GetByIdAsync(command.Id!.Value);
        if (property == null)
            return OperationResult<DeleteLeaseCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        if(_userContext.IsOwner && property.OwnerId != _userContext.OwnerId!.Value)
            return OperationResult<DeleteLeaseCommandResponse>.ErrorResult(new ErrorDetails(403, "The owner does not have permissions to delete this property."));

        await _unitOfWork.ExecuteAsTransactionAsync(() =>
        {
            _leaseRepository.Delete(property);

            return Task.CompletedTask;
        });

        var response = new DeleteLeaseCommandResponse
        {
            Id = property.Id
        };

        return OperationResult<DeleteLeaseCommandResponse>.SuccessResult(response);
    }
}
