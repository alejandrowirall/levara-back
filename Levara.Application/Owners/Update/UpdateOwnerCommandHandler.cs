using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.Owners.Update;

public class UpdateOwnerCommandHandler : ICommandHandler<UpdateOwnerCommand, UpdateOwnerCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOwnerRepository _ownerRepository;
    public UpdateOwnerCommandHandler(IUnitOfWork unitOfWork,
        IOwnerRepository ownerRepository) 
    {
        _unitOfWork = unitOfWork;
        _ownerRepository = ownerRepository;
    }
    public async Task<OperationResult<UpdateOwnerCommandResponse>> Handle(UpdateOwnerCommand command)
    {
        if (await _ownerRepository.AnyAsync(o => o.Id != command.Id!.Value &&
                                                o.IdentificationType == command.IdentificationType && 
                                                o.Identification == command.Identification))
            return OperationResult<UpdateOwnerCommandResponse>.ErrorResult(new ErrorDetails(400, "An Owner with the same Identification already exists"));

        var ownerQuery = _ownerRepository.GetAllWithAddress()
                                         .Where(o => o.Id == command.Id!);

        Owner? owner = await _ownerRepository.FirstOrDefaultAsync(ownerQuery);
        if (owner == null)
            return OperationResult<UpdateOwnerCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        owner.Name = command.Name!;
        owner.Surname = command.Surname!;
        owner.CompanyName = command.CompanyName!;
        owner.Identification = command.Identification!;
        owner.IdentificationType = command.IdentificationType.GetValueOrDefault();
        owner.PersonType = command.PersonType.GetValueOrDefault();
        owner.MobilePhone = command.MobilePhone!;
        owner.Email = command.Email!;
        owner.Address.Street = command.Street!;
        owner.Address.AdditionalLine = command.AdditionalLine!;
        owner.Address.City = command.City!;
        owner.Address.State = command.State!;
        owner.Address.PostalCode = command.PostalCode!;

        await _unitOfWork.ExecuteAsTransactionAsync(() =>
        {
            _ownerRepository.Update(owner);
            return Task.CompletedTask;

        });

        var response = new UpdateOwnerCommandResponse
        {
            Id = owner.Id
        };

        return OperationResult<UpdateOwnerCommandResponse>.SuccessResult(response);

    }
}
