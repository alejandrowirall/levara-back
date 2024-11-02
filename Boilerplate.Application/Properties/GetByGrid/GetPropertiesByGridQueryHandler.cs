
using Boilerplate.Domain.DAL.Repositories;
using Boilerplate.Domain.Models;
using Boilerplate.Shared.Domain.Bus.Queries;
using Boilerplate.Shared.Results;

namespace Boilerplate.Application.Properties.GetByGrid;

public class GetPropertiesByGridQueryHandler : IQueryHandler<GetPropertiesByGridQuery, PagedList<GetPropertiesByGridQueryResponse>>
{
    private readonly IPropertyRepository _propertyRepository;
    public GetPropertiesByGridQueryHandler(IPropertyRepository propertyRepository) 
    {
        _propertyRepository = propertyRepository;
    }
    public async Task<OperationResult<PagedList<GetPropertiesByGridQueryResponse>>> Handle(GetPropertiesByGridQuery query)
    {

        var propertyQuery = _propertyRepository.GetAllWithAddress()
                                               .Where(p => p.OwnerId == query.OwnerId!.Value)
                                               .OrderByDescending(p => p.CreatedDate)
                                               .Select(p => new GetPropertiesByGridQueryResponse(p));

        var response = await _propertyRepository.ToListPagedAsync(propertyQuery, query.PageNumber!.Value, query.PageSize!.Value);


        return OperationResult<PagedList<GetPropertiesByGridQueryResponse>>.SuccessResult(response);

    }
}


