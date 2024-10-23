using Boilerplate.Domain.DAL;
using Boilerplate.Domain.DAL.Repositories;
using Boilerplate.Domain.Models;
using Boilerplate.Shared.Domain.Bus.Commands;
using Boilerplate.Shared.Results;

namespace Boilerplate.Application.Owners.Delete;

public class DeleteOwnerCommandHandler : ICommandHandler<DeleteOwnerCommand, DeleteOwnerCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOwnerRepository _ownerRepository;
    public DeleteOwnerCommandHandler(IUnitOfWork unitOfWork,
        IOwnerRepository ownerRepository) 
    {
        _unitOfWork = unitOfWork;
        _ownerRepository = ownerRepository;
    }
    public async Task<OperationResult<DeleteOwnerCommandResponse>> Handle(DeleteOwnerCommand command)
    {
        Owner? owner = await _ownerRepository.GetByIdAsync(command.Id!.Value);
        if (owner == null)
            return OperationResult<DeleteOwnerCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        await _unitOfWork.ExecuteAsTransactionAsync(() =>
        {
            _ownerRepository.Delete(owner);

            return Task.CompletedTask;
        });

        var response = new DeleteOwnerCommandResponse
        {
            Id = owner.Id
        };

        return OperationResult<DeleteOwnerCommandResponse>.SuccessResult(response);
    }
}
