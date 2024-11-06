
using Boilerplate.Domain.DAL;
using Boilerplate.Domain.DAL.Repositories;
using Boilerplate.Domain.Models;
using Boilerplate.Shared.Domain.Bus.Commands;
using Boilerplate.Shared.Results;

namespace Boilerplate.Application.Properties.Create;

public class CreatePropertyCommandHandler : ICommandHandler<CreatePropertyCommand, CreatePropertyCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPropertyRepository _propertyRepository;
    public CreatePropertyCommandHandler(IUnitOfWork unitOfWork,
        IPropertyRepository propertyRepository) 
    {
        _unitOfWork = unitOfWork;
        _propertyRepository = propertyRepository;
    }
    public async Task<OperationResult<CreatePropertyCommandResponse>> Handle(CreatePropertyCommand command)
    {
        Property property = new()
        {
            OwnerId = command.OwnerId!.Value,
            Price=command.Price!.Value,
            Address = new()
            {
                Street = command.Street!,
                Number = command.StreetNumber.GetValueOrDefault(),
                AdditionalLine = command.AdditionalLine,
                City = command.City!,
                State = command.State!,
                PostalCode = command.PostalCode!,
            },
        };

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            int numberCurrentProperties = await _propertyRepository.CountAsync(p => p.OwnerId == command.OwnerId);

            property.Number = numberCurrentProperties;

            await _propertyRepository.AddAsync(property);

        });

        CreatePropertyCommandResponse response = new ()
        {
            Id = property.Id
        };

        return OperationResult<CreatePropertyCommandResponse>.SuccessResult(response);

    }
}
