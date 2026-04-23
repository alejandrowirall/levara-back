
using Levara.Domain.Authentication;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Levara.Application.Owners.Create;

public class CreateOwnerCommandHandler : ICommandHandler<CreateOwnerCommand, CreateOwnerCommandResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserStore<ApplicationUser> _userStore;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOwnerRepository _ownerRepository;
    public CreateOwnerCommandHandler(UserManager<ApplicationUser> userManager,
        IUserStore<ApplicationUser> userStore,
        IUnitOfWork unitOfWork,
        IOwnerRepository ownerRepository) 
    {
        _userManager = userManager;
        _userStore = userStore;
        _unitOfWork = unitOfWork;
        _ownerRepository = ownerRepository;
    }
    public async Task<OperationResult<CreateOwnerCommandResponse>> Handle(CreateOwnerCommand command)
    {
        // Idempotencia: si ExternalId fue provisto y ya existe, devolvemos el existente
        if (!string.IsNullOrEmpty(command.ExternalId))
        {
            var existing = await _ownerRepository.GetByExternalIdAsync(command.ExternalId);
            if (existing != null)
                return OperationResult<CreateOwnerCommandResponse>.SuccessResult(
                    new CreateOwnerCommandResponse { Id = existing.Id });
        }

        if (await _ownerRepository.AnyAsync(o => o.IdentificationType == command.IdentificationType && o.Identification == command.Identification))
            return OperationResult<CreateOwnerCommandResponse>.ErrorResult(new ErrorDetails(400, "A owner with the same identification type and number already exists."));

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
            ExternalId = command.ExternalId,
            Address = new()
            {
                Street = command.Street!,
                AdditionalLine = command.AdditionalLine,
                City = command.City!,
                State = command.State!,
                PostalCode = command.PostalCode!
            },
        };

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(command.Email!);
            if(user == null)
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

            owner.ApplicationUserId = user.Id;

            await _ownerRepository.AddAsync(owner);

            var addRolesResult = await _userManager.AddToRolesAsync(user, [Roles.Owner]);
            if (!addRolesResult.Succeeded)
                throw new Exception(addRolesResult.Errors.ToString());

            var AddClaimsResult = await _userManager.AddClaimAsync(user, new Claim(CustomClaimTypes.OwnerId, owner.Id.ToString()));
            if (!AddClaimsResult.Succeeded)
                throw new Exception(AddClaimsResult.Errors.ToString());

        });

        var response = new CreateOwnerCommandResponse
        {
            Id = owner.Id
        };

        return OperationResult<CreateOwnerCommandResponse>.SuccessResult(response);

    }
}
