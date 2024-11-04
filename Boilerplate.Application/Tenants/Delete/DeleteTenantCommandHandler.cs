using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.Tenants.Delete;

public class DeleteTenantCommandHandler : ICommandHandler<DeleteTenantCommand, DeleteTenantCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantRepository _tenantRepository;
    public DeleteTenantCommandHandler(IUnitOfWork unitOfWork,
        ITenantRepository tenantRepository) 
    {
        _unitOfWork = unitOfWork;
        _tenantRepository = tenantRepository;
    }
    public async Task<OperationResult<DeleteTenantCommandResponse>> Handle(DeleteTenantCommand command)
    {
        Tenant? tenant = await _tenantRepository.GetByIdAsync(command.Id!.Value);
        if (tenant == null)
            return OperationResult<DeleteTenantCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        await _unitOfWork.ExecuteAsTransactionAsync(() =>
        {
            _tenantRepository.Delete(tenant);

            return Task.CompletedTask;
        });

        var response = new DeleteTenantCommandResponse
        {
            Id = tenant.Id
        };

        return OperationResult<DeleteTenantCommandResponse>.SuccessResult(response);
    }
}
