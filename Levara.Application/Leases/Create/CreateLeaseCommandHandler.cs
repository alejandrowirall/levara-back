
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.Leases.Create;

public class CreateLeaseCommandHandler : ICommandHandler<CreateLeaseCommand, CreateLeaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILeaseRepository _leaseRepository;
    public CreateLeaseCommandHandler(IUnitOfWork unitOfWork,
        ILeaseRepository leaseRepository)
    {
        _unitOfWork = unitOfWork;
        _leaseRepository = leaseRepository;
    }
    public async Task<OperationResult<CreateLeaseCommandResponse>> Handle(CreateLeaseCommand command)
    {
        // Idempotencia: si ExternalId fue provisto y ya existe, devolvemos el existente
        if (!string.IsNullOrEmpty(command.ExternalId))
        {
            var existing = await _leaseRepository.GetByExternalIdAsync(command.ExternalId);
            if (existing != null)
                return OperationResult<CreateLeaseCommandResponse>.SuccessResult(
                    new CreateLeaseCommandResponse { Id = existing.Id });
        }

        Lease lease = new()
        {
            OwnerId = command.OwnerId!.Value,
            PropertyId = command.PropertyId!.Value,
            Frequency = command.Frequency!.Value,
            TenantId = command.TenantId!.Value,
            DateFrom = command.DateFrom!.Value,
            DateTo = command.DateTo!.Value,
            Amount = command.Price!.Value,
            Status = command.Status!.Value,
            ExternalId = command.ExternalId
        };

        await _leaseRepository.AddAsync(lease);
        await _unitOfWork.SaveChangesAsync();

        CreateLeaseCommandResponse response = new()
        {
            Id = lease.Id
        };

        return OperationResult<CreateLeaseCommandResponse>.SuccessResult(response);

    }
}
