
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
        Lease lease = new()
        {
            OwnerId = command.OwnerId!.Value,
            PropertyId = command.PropertyId!.Value,
            TenantId = command.TenantId!.Value,
            DateFrom= command.DateFrom.ToUniversalTime(),
            DateTo= command.DateTo.ToUniversalTime(),

            Amount =command.Price!.Value,
            
        };

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
          await _leaseRepository.AddAsync(lease);

        });

        CreateLeaseCommandResponse response = new ()
        {
            Id = lease.Id
        };

        return OperationResult<CreateLeaseCommandResponse>.SuccessResult(response);

    }
}
