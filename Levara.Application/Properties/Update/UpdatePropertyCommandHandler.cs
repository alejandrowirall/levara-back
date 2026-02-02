using Levara.DAL.Repositories;
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
    private readonly IAddressRepository _addressRepository;
    private readonly IPropertyRepository _propertyRepository;
    public UpdatePropertyCommandHandler(IUserContext userContext,
        IUnitOfWork unitOfWork,
        IAddressRepository addressRepository,
        IPropertyRepository propertyRepository) 
    {
        _userContext = userContext;
        _unitOfWork = unitOfWork;
        _addressRepository = addressRepository;
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
        property.RoomsQuantity = command.RoomsQuantity;
        property.BathroomQuantity = command.BathroomQuantity;
        property.AreaQuantity = command.AreaQuantity;
        property.HasPool = command.HasPool;
        property.HasBalcony = command.HasBalcony;
        property.HasGarage = command.HasGarage;
        property.DetailDepositAndAdittionalInfo = command.DetailDepositAndAdittionalInfo;
        property.PetsPoliticAndRate = command.PetsPoliticAndRate;
        property.TenantRequirements = command.TenantRequirements;
        property.AvailableFrom = command.AvailableFrom;
        property.Img= command.Img!;
        property.OwnerBankAccountId = command.OwnerBankAccountId;

        await _unitOfWork.ExecuteAsTransactionAsync(() =>
        {
            _addressRepository.Update(property.Address);
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
