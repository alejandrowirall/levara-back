using Levara.Domain.Contexts;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.Properties.Update;

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
        property.RoomsQuantity = command.RoomsQuantity.Value;
        property.BathroomQuantity = command.BathroomQuantity.Value;
        property.AreaQuantity = command.AreaQuantity.Value;
        property.HasPool = command.HasPool.Value;
        property.HasBalcony = command.HasBalcony.Value;
        property.HasGarage = command.HasGarage.Value;
        property.DetailDepositAndAdittionalInfo = command.DetailDepositAndAdittionalInfo;
        property.PetsPoliticAndRate = command.PetsPoliticAndRate;
        property.TenantRequirements = command.TenantRequirements;
        property.AvaliableFrom = command.AvaliableFrom.Value;
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
