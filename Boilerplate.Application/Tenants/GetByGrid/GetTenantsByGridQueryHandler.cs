
using Boilerplate.Domain.DAL;
using Boilerplate.Domain.DAL.Repositories;
using Boilerplate.Domain.Models;
using Boilerplate.Shared.Domain.Bus.Queries;
using Boilerplate.Shared.Results;

namespace Boilerplate.Application.Tenants.GetByGrid;

public class GetTenantsByGridQueryHandler : IQueryHandler<GetTenantsByGridQuery, PagedList<GetTenantsByGridQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantRepository _tenantRepository;
    public GetTenantsByGridQueryHandler(IUnitOfWork unitOfWork,
        ITenantRepository tenantRepository) 
    {
        _unitOfWork = unitOfWork;
        _tenantRepository = tenantRepository;
    }
    public async Task<OperationResult<PagedList<GetTenantsByGridQueryResponse>>> Handle(GetTenantsByGridQuery query)
    {

        var tenantQuery = _tenantRepository.GetAll()
                                           .OrderByDescending(t => t.CreatedDate)
                                           .Select(t => new GetTenantsByGridQueryResponse(t));

        var response = await _tenantRepository.ToListPagedAsync(tenantQuery, query.PageNumber!.Value, query.PageSize!.Value);


        return OperationResult<PagedList<GetTenantsByGridQueryResponse>>.SuccessResult(response);

    }
}


