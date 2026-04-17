using Levara.Domain.Authentication;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Levara.Application.Tenants.Create;

public class CreateTenantCommandHandler : ICommandHandler<CreateTenantCommand, CreateTenantCommandResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserStore<ApplicationUser> _userStore;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAddressRepository _addressRepository;
    private readonly ITenantRepository _tenantRepository;
    public CreateTenantCommandHandler(UserManager<ApplicationUser> userManager,
        IUserStore<ApplicationUser> userStore,
        IUnitOfWork unitOfWork,
        IAddressRepository addressRepository,
        ITenantRepository tenantRepository) 
    {
        _userManager = userManager;
        _userStore = userStore;
        _unitOfWork = unitOfWork;
        _addressRepository = addressRepository;
        _tenantRepository = tenantRepository;
    }
    public async Task<OperationResult<CreateTenantCommandResponse>> Handle(CreateTenantCommand command)
    {
        if (await _tenantRepository.AnyAsync(o => o.IdentificationType == command.IdentificationType && o.Identification == command.Identification))
            return OperationResult<CreateTenantCommandResponse>.ErrorResult(new ErrorDetails(400, "A tenant with the same identification type and number already exists."));

        Address newAddress = new()
        {
            Street = command.Street!,
            AdditionalLine = command.AdditionalLine,
            City = command.City!,
            State = command.State!,
            PostalCode = command.PostalCode!
        };

        Tenant newTenant = new()
        {
            Name = command.Name!,
            Surname = command.Surname!,
            CompanyName = command.CompanyName!,
            Identification = command.Identification!,
            IdentificationType = command.IdentificationType.GetValueOrDefault(),
            PersonType = command.PersonType.GetValueOrDefault(),
            MobilePhone = command.MobilePhone!,
            Email = command.Email!,
            Address = newAddress
        };

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(command.Email!);
            if (user == null)
            {
                var emailStore = (IUserEmailStore<ApplicationUser>)_userStore;
                user = new ApplicationUser();
                user.RefreshToken = Guid.NewGuid().ToString();

                await _userStore.SetUserNameAsync(user, command.Email, CancellationToken.None);
                await emailStore.SetEmailAsync(user, command.Email, CancellationToken.None);

                var result = await _userManager.CreateAsync(user, "Levara.2024");
                if (!result.Succeeded)
                    throw new Exception(result.ToString());
            }

            newTenant.ApplicationUserId = user.Id;

            await _addressRepository.AddAsync(newAddress);
            await _tenantRepository.AddAsync(newTenant);

            var addRolesResult = await _userManager.AddToRolesAsync(user, [Roles.Tenant]);
            if (!addRolesResult.Succeeded)
                throw new Exception(addRolesResult.Errors.ToString());

            var AddClaimsResult = await _userManager.AddClaimAsync(user, new Claim(CustomClaimTypes.TenantId, newTenant.Id.ToString()));
            if (!AddClaimsResult.Succeeded)
                throw new Exception(AddClaimsResult.Errors.ToString());

        });

        var response = new CreateTenantCommandResponse
        {
            Id = newTenant.Id
        };

        return OperationResult<CreateTenantCommandResponse>.SuccessResult(response);

    }
}
