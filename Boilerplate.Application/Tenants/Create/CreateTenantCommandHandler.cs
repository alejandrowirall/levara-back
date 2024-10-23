using Boilerplate.Domain.DAL;
using Boilerplate.Domain.DAL.Repositories;
using Boilerplate.Domain.Models;
using Boilerplate.Shared.Domain.Bus.Commands;
using Boilerplate.Shared.Results;

namespace Boilerplate.Application.Tenants.Create;

public class CreateTenantCommandHandler : ICommandHandler<CreateTenantCommand, CreateTenantCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantRepository _tenantRepository;
    public CreateTenantCommandHandler(IUnitOfWork unitOfWork,
        ITenantRepository tenantRepository) 
    {
        _unitOfWork = unitOfWork;
        _tenantRepository = tenantRepository;
    }
    public async Task<OperationResult<CreateTenantCommandResponse>> Handle(CreateTenantCommand command)
    {
        Tenant tenant = new()
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

        if (await _tenantRepository.AnyAsync(o => o.IdentificationType == tenant.IdentificationType && o.Identification == tenant.Identification))
            return OperationResult<CreateTenantCommandResponse>.ErrorResult(new ErrorDetails(400, "Errores"));

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            await _tenantRepository.AddAsync(tenant);
        });

        var response = new CreateTenantCommandResponse
        {
            Id = tenant.Id
        };

        return OperationResult<CreateTenantCommandResponse>.SuccessResult(response);

    }
}
