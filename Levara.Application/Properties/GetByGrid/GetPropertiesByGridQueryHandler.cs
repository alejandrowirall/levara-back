
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Properties.GetByGrid;

public class GetPropertiesByGridQueryHandler : IQueryHandler<GetPropertiesByGridQuery, PagedList<GetPropertiesByGridQueryResponse>>
{
    private readonly IPropertyRepository _propertyRepository;
    public GetPropertiesByGridQueryHandler(IPropertyRepository propertyRepository) 
    {
        _propertyRepository = propertyRepository;
    }
    public async Task<OperationResult<PagedList<GetPropertiesByGridQueryResponse>>> Handle(GetPropertiesByGridQuery query)
    {

        var propertyQuery = _propertyRepository.GetAllWithAddress();

        if (query.OwnerId.HasValue)
            propertyQuery = propertyQuery.Where(p => p.OwnerId == query.OwnerId!.Value);

        if (query.PropertyId.HasValue)
            propertyQuery = propertyQuery.Where(p => p.Id == query.PropertyId!.Value);

        var responseQuery = propertyQuery.OrderByDescending(p => p.CreatedDate)
                                         .Select(p => new GetPropertiesByGridQueryResponse(p));

        var response = await _propertyRepository.ToListPagedAsync(responseQuery, query.PageNumber!.Value, query.PageSize!.Value);

        return OperationResult<PagedList<GetPropertiesByGridQueryResponse>>.SuccessResult(response);

    }
}


