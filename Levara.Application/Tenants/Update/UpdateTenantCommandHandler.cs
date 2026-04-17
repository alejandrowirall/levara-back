using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.Tenants.Update;

public class UpdateTenantCommandHandler : ICommandHandler<UpdateTenantCommand, UpdateTenantCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAddressRepository _addressRepository;
    private readonly ITenantRepository _tenantRepository;
    public UpdateTenantCommandHandler(IUnitOfWork unitOfWork,
        IAddressRepository addressRepository,
        ITenantRepository tenantRepository) 
    {
        _unitOfWork = unitOfWork;
        _addressRepository = addressRepository;
        _tenantRepository = tenantRepository;
    }
    public async Task<OperationResult<UpdateTenantCommandResponse>> Handle(UpdateTenantCommand command)
    {
        if (await _tenantRepository.AnyAsync(o => o.Id != command.Id!.Value &&
                                                o.IdentificationType == command.IdentificationType && 
                                                o.Identification == command.Identification))
            return OperationResult<UpdateTenantCommandResponse>.ErrorResult(new ErrorDetails(400, "An Tenant with the same Identification already exists"));

        var tenantQuery = _tenantRepository.GetAllWithAddress()
                                           .Where(t => t.Id == command.Id!);

        Tenant? tenant = await _tenantRepository.FirstOrDefaultAsync(tenantQuery);
        if (tenant == null)
            return OperationResult<UpdateTenantCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        tenant.Name = command.Name!;
        tenant.Surname = command.Surname!;
        tenant.CompanyName = command.CompanyName!;
        tenant.Identification = command.Identification!;
        tenant.IdentificationType = command.IdentificationType.GetValueOrDefault();
        tenant.PersonType = command.PersonType.GetValueOrDefault();
        tenant.MobilePhone = command.MobilePhone!;
        tenant.Email = command.Email!;
        tenant.Address.Street = command.Street!;
        tenant.Address.AdditionalLine = command.AdditionalLine!;
        tenant.Address.City = command.City!;
        tenant.Address.State = command.State!;
        tenant.Address.PostalCode = command.PostalCode!;

        await _unitOfWork.ExecuteAsTransactionAsync(() =>
        {
            _addressRepository.Update(tenant.Address);
            _tenantRepository.Update(tenant);
            return Task.CompletedTask;
        });

        var response = new UpdateTenantCommandResponse
        {
            Id = tenant.Id
        };

        return OperationResult<UpdateTenantCommandResponse>.SuccessResult(response);

    }
}
