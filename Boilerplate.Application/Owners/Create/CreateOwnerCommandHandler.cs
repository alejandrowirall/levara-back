using Boilerplate.Domain.DAL;
using Boilerplate.Domain.DAL.Repositories;
using Boilerplate.Domain.Models;
using Boilerplate.Shared.Domain.Bus.Commands;
using Boilerplate.Shared.Results;

namespace Boilerplate.Application.Owners.Create;

public class CreateOwnerCommandHandler : ICommandHandler<CreateOwnerCommand, CreateOwnerCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOwnerRepository _ownerRepository;
    public CreateOwnerCommandHandler(IUnitOfWork unitOfWork,
        IOwnerRepository ownerRepository) 
    {
        _unitOfWork = unitOfWork;
        _ownerRepository = ownerRepository;
    }
    public async Task<OperationResult<CreateOwnerCommandResponse>> Handle(CreateOwnerCommand command)
    {
        Owner owner = new()
        {
            Name = command.Name!,
            Surname = command.Surname!,
            CompanyName = command.CompanyName!,
            Identification = command.Identification!,
            IdentificationType = command.IdentificationType.GetValueOrDefault(),
            PersonType = command.PersonType.GetValueOrDefault(),
            MobilePhone = command.MobilePhone!,
            Email = command.Email!,
            Address = new()
            {
                Street = command.Street!,
                Number = command.Number.GetValueOrDefault(),
                AdditionalLine = command.AdditionalLine,
                City = command.City!,
                State = command.State!,
                PostalCode = command.PostalCode!
            }
        };

        if (await _ownerRepository.AnyAsync(o => o.IdentificationType == owner.IdentificationType && o.Identification == owner.Identification))
            return OperationResult<CreateOwnerCommandResponse>.ErrorResult(new ErrorDetails(400, "Errores"));

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _ownerRepository.AddAsync(owner);
        });

        var response = new CreateOwnerCommandResponse
        {
            Id = owner.Id
        };

        return OperationResult<CreateOwnerCommandResponse>.SuccessResult(response);

    }
}
