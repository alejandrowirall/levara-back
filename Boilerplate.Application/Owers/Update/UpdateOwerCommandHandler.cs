using Boilerplate.Domain.DAL;
using Boilerplate.Domain.Models;
using Boilerplate.Shared.Domain.Bus.Commands;
using Boilerplate.Shared.Results;

namespace Boilerplate.Application.Owers.Update;

public class UpdateOwerCommandHandler : ICommandHandler<UpdateOwerCommand, UpdateOwerCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdateOwerCommandHandler(IUnitOfWork unitOfWork) 
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<OperationResult<UpdateOwerCommandResponse>> Handle(UpdateOwerCommand command)
    {
        IRepository<Owner> ownerRepository = _unitOfWork.Repository<Owner>();

        if (await ownerRepository.AnyAsync(o => o.Id == command.Id!.Value &&
                                                o.IdentificationType == command.IdentificationType && 
                                                o.Identification == command.Identification))
            return OperationResult<UpdateOwerCommandResponse>.ErrorResult(new ErrorDetails(400, "An Owner with the same Identification already exists"));

        Owner? owner = await ownerRepository.GetByIdAsync(command.Id!.Value);
        if(owner == null)
            return OperationResult<UpdateOwerCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        owner.Name = command.Name!;
        owner.Surname = command.Surname!;
        owner.CompanyName = command.CompanyName!;
        owner.Identification = command.Identification!;
        owner.IdentificationType = command.IdentificationType.GetValueOrDefault();
        owner.PersonType = command.PersonType.GetValueOrDefault();
        owner.MobilePhone = command.MobilePhone!;
        owner.Email = command.Email!;
        owner.Address.Street = command.Street!;
        owner.Address.Number = command.Number.GetValueOrDefault();
        owner.Address.AdditionalLine = command.AdditionalLine!;
        owner.Address.City = command.City!;
        owner.Address.State = command.State!;
        owner.Address.PostalCode = command.PostalCode!;

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await ownerRepository.AddAsync(owner);
        });

        var response = new UpdateOwerCommandResponse
        {
            Id = owner.Id
        };

        return OperationResult<UpdateOwerCommandResponse>.SuccessResult(response);

    }
}
