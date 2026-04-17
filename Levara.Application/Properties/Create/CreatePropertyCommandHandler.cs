using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.Properties.Create;

public class CreatePropertyCommandHandler : ICommandHandler<CreatePropertyCommand, CreatePropertyCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAddressRepository _addressRepository;
    private readonly IPropertyRepository _propertyRepository;
    public CreatePropertyCommandHandler(IUnitOfWork unitOfWork,
        IAddressRepository addressRepository,
        IPropertyRepository propertyRepository)
    {
        _unitOfWork = unitOfWork;
        _addressRepository = addressRepository;
        _propertyRepository = propertyRepository;
    }
    public async Task<OperationResult<CreatePropertyCommandResponse>> Handle(CreatePropertyCommand command)
    {
        Address newAddress = new()
        {
            Street = command.Street!,
            AdditionalLine = command.AdditionalLine,
            City = command.City!,
            State = command.State!,
            PostalCode = command.PostalCode!,
        };

        Property newProperty = new()
        {
            OwnerId = command.OwnerId!.Value,
            Price = command.Price!.Value,
            RoomsQuantity = command.RoomsQuantity,
            BathroomQuantity = command.BathroomQuantity,
            AreaQuantity = command.AreaQuantity,
            HasPool = command.HasPool,
            HasBalcony = command.HasBalcony,
            HasGarage = command.HasGarage,
            DetailDepositAndAdittionalInfo = command.DetailDepositAndAdittionalInfo,
            PetsPoliticAndRate = command.PetsPoliticAndRate,
            TenantRequirements = command.TenantRequirements,
            AvailableFrom = command.AvailableFrom,
            Img = command.Img,
            Address = newAddress,
            OwnerBankAccountId = command.OwnerBankAccountId
        };

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            int numberCurrentProperties = await _propertyRepository.CountAsync(p => p.OwnerId == command.OwnerId);

            newProperty.Number = numberCurrentProperties + 1;

            await _addressRepository.AddAsync(newAddress);
            await _propertyRepository.AddAsync(newProperty);

        });

        CreatePropertyCommandResponse response = new()
        {
            Id = newProperty.Id
        };

        return OperationResult<CreatePropertyCommandResponse>.SuccessResult(response);

    }
}
