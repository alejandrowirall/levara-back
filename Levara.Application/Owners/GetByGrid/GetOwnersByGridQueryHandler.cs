using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Owners.GetByGrid;

public class GetOwnersByGridQueryHandler : IQueryHandler<GetOwnersByGridQuery, PagedList<GetOwnersByGridQueryResponse>>
{
    private readonly IOwnerRepository _ownerRepository;
    public GetOwnersByGridQueryHandler(IOwnerRepository ownerRepository) 
    {
        _ownerRepository = ownerRepository;
    }
    public async Task<OperationResult<PagedList<GetOwnersByGridQueryResponse>>> Handle(GetOwnersByGridQuery query)
    {
        var ownerQuery = _ownerRepository.GetAll();

        if (query.OwnerId.HasValue)
            ownerQuery = ownerQuery.Where(o => o.Id == query.OwnerId.Value);

        var ownerQueryResponse = ownerQuery.OrderByDescending(o => o.CreatedDate)
                                           .Select(o => new GetOwnersByGridQueryResponse(o));

        var response = await _ownerRepository.ToListPagedAsync(ownerQueryResponse, query.PageNumber!.Value, query.PageSize!.Value);

        return OperationResult<PagedList<GetOwnersByGridQueryResponse>>.SuccessResult(response);
    }
}


