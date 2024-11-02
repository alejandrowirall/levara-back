using Boilerplate.Domain.Contexts;
using Boilerplate.Domain.DAL;
using Boilerplate.Domain.DAL.Repositories;
using Boilerplate.Domain.Models;
using Boilerplate.Shared.Domain.Bus.Commands;
using Boilerplate.Shared.Results;

namespace Boilerplate.Application.Properties.Delete;

public class DeletePropertyCommandHandler : ICommandHandler<DeletePropertyCommand, DeletePropertyCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;
    private readonly IPropertyRepository _propertyRepository;
    public DeletePropertyCommandHandler(IUnitOfWork unitOfWork,
        IUserContext userContext,
        IPropertyRepository propertyRepository) 
    {
        _unitOfWork = unitOfWork;
        _userContext = userContext;
        _propertyRepository = propertyRepository;
    }
    public async Task<OperationResult<DeletePropertyCommandResponse>> Handle(DeletePropertyCommand command)
    {
        Property? property = await _propertyRepository.GetByIdAsync(command.Id!.Value);
        if (property == null)
            return OperationResult<DeletePropertyCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        if(_userContext.IsOwner && property.OwnerId != _userContext.OwnerId!.Value)
            return OperationResult<DeletePropertyCommandResponse>.ErrorResult(new ErrorDetails(403, "The owner does not have permissions to delete this property."));

        await _unitOfWork.ExecuteAsTransactionAsync(() =>
        {
            _propertyRepository.Delete(property);

            return Task.CompletedTask;
        });

        var response = new DeletePropertyCommandResponse
        {
            Id = property.Id
        };

        return OperationResult<DeletePropertyCommandResponse>.SuccessResult(response);
    }
}
