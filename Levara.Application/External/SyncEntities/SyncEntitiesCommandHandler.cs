using Levara.Domain.Authentication;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Levara.Application.External.SyncEntities;

public class SyncEntitiesCommandHandler : ICommandHandler<SyncEntitiesCommand, SyncEntitiesCommandResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserStore<ApplicationUser> _userStore;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOwnerRepository _ownerRepository;
    private readonly ITenantRepository _tenantRepository;
    private readonly IPropertyRepository _propertyRepository;
    private readonly IAddressRepository _addressRepository;

    public SyncEntitiesCommandHandler(
        UserManager<ApplicationUser> userManager,
        IUserStore<ApplicationUser> userStore,
        IUnitOfWork unitOfWork,
        IOwnerRepository ownerRepository,
        ITenantRepository tenantRepository,
        IPropertyRepository propertyRepository,
        IAddressRepository addressRepository)
    {
        _userManager = userManager;
        _userStore = userStore;
        _unitOfWork = unitOfWork;
        _ownerRepository = ownerRepository;
        _tenantRepository = tenantRepository;
        _propertyRepository = propertyRepository;
        _addressRepository = addressRepository;
    }

    public async Task<OperationResult<SyncEntitiesCommandResponse>> Handle(SyncEntitiesCommand command)
    {
        var response = new SyncEntitiesCommandResponse();

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            // ── 1. OWNER ──────────────────────────────────────────────────
            var existingOwner = await _ownerRepository.GetByExternalIdAsync(command.Owner.ExternalId);
            if (existingOwner != null)
            {
                response.OwnerId = existingOwner.Id;
                response.OwnerCreated = false;
            }
            else
            {
                ValidateOwnerFields(command.Owner);

                var ownerAddress = new Address
                {
                    Street = command.Owner.Street!,
                    AdditionalLine = command.Owner.AdditionalLine,
                    City = command.Owner.City!,
                    State = command.Owner.State!,
                    PostalCode = command.Owner.PostalCode!
                };

                var newOwner = new Owner
                {
                    Name = command.Owner.Name!,
                    Surname = command.Owner.Surname!,
                    CompanyName = command.Owner.CompanyName!,
                    Identification = command.Owner.Identification!,
                    IdentificationType = command.Owner.IdentificationType!.Value,
                    PersonType = command.Owner.PersonType!.Value,
                    MobilePhone = command.Owner.MobilePhone!,
                    Email = command.Owner.Email!,
                    ExternalId = command.Owner.ExternalId,
                    Address = ownerAddress
                };

                var ownerUser = await _userManager.FindByEmailAsync(command.Owner.Email!);
                if (ownerUser == null)
                {
                    var emailStore = (IUserEmailStore<ApplicationUser>)_userStore;
                    ownerUser = new ApplicationUser { RefreshToken = Guid.NewGuid().ToString() };
                    await _userStore.SetUserNameAsync(ownerUser, command.Owner.Email, CancellationToken.None);
                    await emailStore.SetEmailAsync(ownerUser, command.Owner.Email, CancellationToken.None);

                    var createResult = await _userManager.CreateAsync(ownerUser, "Levara.2024");
                    if (!createResult.Succeeded)
                        throw new Exception(createResult.ToString());
                }

                newOwner.ApplicationUserId = ownerUser.Id;
                await _ownerRepository.AddAsync(newOwner);

                var rolesResult = await _userManager.AddToRolesAsync(ownerUser, [Roles.Owner]);
                if (!rolesResult.Succeeded)
                    throw new Exception(rolesResult.Errors.ToString());

                var claimResult = await _userManager.AddClaimAsync(ownerUser,
                    new Claim(CustomClaimTypes.OwnerId, newOwner.Id.ToString()));
                if (!claimResult.Succeeded)
                    throw new Exception(claimResult.Errors.ToString());

                response.OwnerId = newOwner.Id;
                response.OwnerCreated = true;
            }

            // ── 2. TENANT ─────────────────────────────────────────────────
            var existingTenant = await _tenantRepository.GetByExternalIdAsync(command.Tenant.ExternalId);
            if (existingTenant != null)
            {
                response.TenantId = existingTenant.Id;
                response.TenantCreated = false;
            }
            else
            {
                ValidateTenantFields(command.Tenant);

                var tenantAddress = new Address
                {
                    Street = command.Tenant.Street!,
                    AdditionalLine = command.Tenant.AdditionalLine,
                    City = command.Tenant.City!,
                    State = command.Tenant.State!,
                    PostalCode = command.Tenant.PostalCode!
                };

                var newTenant = new Tenant
                {
                    Name = command.Tenant.Name!,
                    Surname = command.Tenant.Surname!,
                    CompanyName = command.Tenant.CompanyName!,
                    Identification = command.Tenant.Identification!,
                    IdentificationType = command.Tenant.IdentificationType!.Value,
                    PersonType = command.Tenant.PersonType!.Value,
                    MobilePhone = command.Tenant.MobilePhone!,
                    Email = command.Tenant.Email!,
                    ExternalId = command.Tenant.ExternalId,
                    Address = tenantAddress
                };

                var tenantUser = await _userManager.FindByEmailAsync(command.Tenant.Email!);
                if (tenantUser == null)
                {
                    var emailStore = (IUserEmailStore<ApplicationUser>)_userStore;
                    tenantUser = new ApplicationUser { RefreshToken = Guid.NewGuid().ToString() };
                    await _userStore.SetUserNameAsync(tenantUser, command.Tenant.Email, CancellationToken.None);
                    await emailStore.SetEmailAsync(tenantUser, command.Tenant.Email, CancellationToken.None);

                    var createResult = await _userManager.CreateAsync(tenantUser, "Levara.2024");
                    if (!createResult.Succeeded)
                        throw new Exception(createResult.ToString());
                }

                newTenant.ApplicationUserId = tenantUser.Id;
                await _addressRepository.AddAsync(tenantAddress);
                await _tenantRepository.AddAsync(newTenant);

                var rolesResult = await _userManager.AddToRolesAsync(tenantUser, [Roles.Tenant]);
                if (!rolesResult.Succeeded)
                    throw new Exception(rolesResult.Errors.ToString());

                var claimResult = await _userManager.AddClaimAsync(tenantUser,
                    new Claim(CustomClaimTypes.TenantId, newTenant.Id.ToString()));
                if (!claimResult.Succeeded)
                    throw new Exception(claimResult.Errors.ToString());

                response.TenantId = newTenant.Id;
                response.TenantCreated = true;
            }

            // ── 3. PROPERTY ───────────────────────────────────────────────
            var existingProperty = await _propertyRepository.GetByExternalIdAsync(command.Property.ExternalId);
            if (existingProperty != null)
            {
                response.PropertyId = existingProperty.Id;
                response.PropertyCreated = false;
            }
            else
            {
                ValidatePropertyFields(command.Property);

                var propertyAddress = new Address
                {
                    Street = command.Property.Street!,
                    AdditionalLine = command.Property.AdditionalLine,
                    City = command.Property.City!,
                    State = command.Property.State!,
                    PostalCode = command.Property.PostalCode!
                };

                int propertyNumber = await _propertyRepository.CountAsync(p => p.OwnerId == response.OwnerId) + 1;

                var newProperty = new Property
                {
                    OwnerId = response.OwnerId,
                    Number = propertyNumber,
                    Price = command.Property.Price,
                    RoomsQuantity = command.Property.RoomsQuantity,
                    BathroomQuantity = command.Property.BathroomQuantity,
                    AreaQuantity = command.Property.AreaQuantity,
                    HasPool = command.Property.HasPool,
                    HasBalcony = command.Property.HasBalcony,
                    HasGarage = command.Property.HasGarage,
                    AvailableFrom = command.Property.AvailableFrom,
                    OwnerBankAccountId = command.Property.OwnerBankAccountId,
                    ExternalId = command.Property.ExternalId,
                    Address = propertyAddress
                };

                await _addressRepository.AddAsync(propertyAddress);
                await _propertyRepository.AddAsync(newProperty);

                response.PropertyId = newProperty.Id;
                response.PropertyCreated = true;
            }
        });

        return OperationResult<SyncEntitiesCommandResponse>.SuccessResult(response);
    }

    // ── Validaciones de campos requeridos para creación ───────────────────

    private static void ValidateOwnerFields(SyncOwnerData d)
    {
        var missing = new List<string>();
        if (string.IsNullOrEmpty(d.Name))            missing.Add("Owner.Name");
        if (string.IsNullOrEmpty(d.Surname))         missing.Add("Owner.Surname");
        if (string.IsNullOrEmpty(d.CompanyName))     missing.Add("Owner.CompanyName");
        if (string.IsNullOrEmpty(d.Identification))  missing.Add("Owner.Identification");
        if (d.IdentificationType is null)            missing.Add("Owner.IdentificationType");
        if (d.PersonType is null)                    missing.Add("Owner.PersonType");
        if (string.IsNullOrEmpty(d.MobilePhone))     missing.Add("Owner.MobilePhone");
        if (string.IsNullOrEmpty(d.Email))           missing.Add("Owner.Email");
        if (string.IsNullOrEmpty(d.Street))          missing.Add("Owner.Street");
        if (string.IsNullOrEmpty(d.City))            missing.Add("Owner.City");
        if (string.IsNullOrEmpty(d.State))           missing.Add("Owner.State");
        if (string.IsNullOrEmpty(d.PostalCode))      missing.Add("Owner.PostalCode");

        if (missing.Count > 0)
            throw new ArgumentException($"Required fields missing for new Owner: {string.Join(", ", missing)}");
    }

    private static void ValidateTenantFields(SyncTenantData d)
    {
        var missing = new List<string>();
        if (string.IsNullOrEmpty(d.Name))            missing.Add("Tenant.Name");
        if (string.IsNullOrEmpty(d.Surname))         missing.Add("Tenant.Surname");
        if (string.IsNullOrEmpty(d.CompanyName))     missing.Add("Tenant.CompanyName");
        if (string.IsNullOrEmpty(d.Identification))  missing.Add("Tenant.Identification");
        if (d.IdentificationType is null)            missing.Add("Tenant.IdentificationType");
        if (d.PersonType is null)                    missing.Add("Tenant.PersonType");
        if (string.IsNullOrEmpty(d.MobilePhone))     missing.Add("Tenant.MobilePhone");
        if (string.IsNullOrEmpty(d.Email))           missing.Add("Tenant.Email");
        if (string.IsNullOrEmpty(d.Street))          missing.Add("Tenant.Street");
        if (string.IsNullOrEmpty(d.City))            missing.Add("Tenant.City");
        if (string.IsNullOrEmpty(d.State))           missing.Add("Tenant.State");
        if (string.IsNullOrEmpty(d.PostalCode))      missing.Add("Tenant.PostalCode");

        if (missing.Count > 0)
            throw new ArgumentException($"Required fields missing for new Tenant: {string.Join(", ", missing)}");
    }

    private static void ValidatePropertyFields(SyncPropertyData d)
    {
        var missing = new List<string>();
        if (string.IsNullOrEmpty(d.Street))     missing.Add("Property.Street");
        if (string.IsNullOrEmpty(d.City))       missing.Add("Property.City");
        if (string.IsNullOrEmpty(d.State))      missing.Add("Property.State");
        if (string.IsNullOrEmpty(d.PostalCode)) missing.Add("Property.PostalCode");

        if (missing.Count > 0)
            throw new ArgumentException($"Required fields missing for new Property: {string.Join(", ", missing)}");
    }
}
