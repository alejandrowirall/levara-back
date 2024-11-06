using Boilerplate.Domain.Contexts;
using Boilerplate.Domain.DAL;
using Boilerplate.Domain.DAL.Repositories;
using Boilerplate.Domain.Models;
using Boilerplate.Shared.Domain.Bus.Commands;
using Boilerplate.Shared.Results;

namespace Boilerplate.Application.Properties.Update;

public class UpdatePropertyCommandHandler : ICommandHandler<UpdatePropertyCommand, UpdatePropertyCommandResponse>
{
    private readonly IUserContext _userContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPropertyRepository _propertyRepository;
    public UpdatePropertyCommandHandler(IUserContext userContext,
        IUnitOfWork unitOfWork,
        IPropertyRepository propertyRepository) 
    {
        _userContext = userContext;
        _unitOfWork = unitOfWork;
        _propertyRepository = propertyRepository;
    }
    public async Task<OperationResult<UpdatePropertyCommandResponse>> Handle(UpdatePropertyCommand command)
    {
        var propertyQuery = _propertyRepository.GetAllWithAddress()
                                               .Where(p => p.Id == command.Id!.Value);

        Property? property = await _propertyRepository.FirstOrDefaultAsync(propertyQuery);
        if (property == null)
            return OperationResult<UpdatePropertyCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        if (_userContext.IsOwner && property.OwnerId != _userContext.OwnerId!.Value)
            return OperationResult<UpdatePropertyCommandResponse>.ErrorResult(new ErrorDetails(403, "The owner does not have permissions to update this property."));

        property.Address.Street = command.Street!;
        property.Address.Number = command.StreetNumber!.Value;
        property.Address.AdditionalLine = command.AdditionalLine;
        property.Address.City = command.City!;
        property.Address.State = command.State!;
        property.Address.PostalCode = command.PostalCode!;
        property.Price = command.Price!;

        await _unitOfWork.ExecuteAsTransactionAsync(() =>
        {
            _propertyRepository.Update(property);
            return Task.CompletedTask;
        });

        var response = new UpdatePropertyCommandResponse
        {
            Id = property.Id
        };

        return OperationResult<UpdatePropertyCommandResponse>.SuccessResult(response);

    }
}
