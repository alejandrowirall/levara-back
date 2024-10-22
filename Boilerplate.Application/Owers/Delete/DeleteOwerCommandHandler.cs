using Boilerplate.Domain.DAL;
using Boilerplate.Domain.DAL.Repositories;
using Boilerplate.Domain.Models;
using Boilerplate.Shared.Domain.Bus.Commands;
using Boilerplate.Shared.Results;

namespace Boilerplate.Application.Owers.Delete;

public class DeleteOwerCommandHandler : ICommandHandler<DeleteOwerCommand, DeleteOwerCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOwnerRepository _ownerRepository;
    public DeleteOwerCommandHandler(IUnitOfWork unitOfWork,
        IOwnerRepository ownerRepository) 
    {
        _unitOfWork = unitOfWork;
        _ownerRepository = ownerRepository;
    }
    public async Task<OperationResult<DeleteOwerCommandResponse>> Handle(DeleteOwerCommand command)
    {
        Owner? owner = await _ownerRepository.GetByIdAsync(command.Id!.Value);
        if (owner == null)
            return OperationResult<DeleteOwerCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        await _unitOfWork.ExecuteAsTransactionAsync(() =>
        {
            _ownerRepository.Delete(owner);

            return Task.CompletedTask;
        });

        var response = new DeleteOwerCommandResponse
        {
            Id = owner.Id
        };

        return OperationResult<DeleteOwerCommandResponse>.SuccessResult(response);
    }
}
