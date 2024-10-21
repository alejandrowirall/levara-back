
using Boilerplate.Domain.DAL;
using Boilerplate.Domain.DAL.Repositories;
using Boilerplate.Domain.Models;
using Boilerplate.Shared.Domain.Bus.Queries;
using Boilerplate.Shared.Results;

namespace Boilerplate.Application.Owers.GetByGrid;

public class GetOwnersByGridQueryHandler : IQueryHandler<GetOwnersByGridQuery, PagedList<GetOwnersByGridQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOwnerRepository _ownerRepository;
    public GetOwnersByGridQueryHandler(IUnitOfWork unitOfWork,
        IOwnerRepository ownerRepository) 
    {
        _unitOfWork = unitOfWork;
        _ownerRepository = ownerRepository;
    }
    public async Task<OperationResult<PagedList<GetOwnersByGridQueryResponse>>> Handle(GetOwnersByGridQuery query)
    {

        var ownerQuery = _ownerRepository.GetAll()
                                         .OrderByDescending(o => o.CreatedDate)
                                         .Select(o => new GetOwnersByGridQueryResponse(o));

        var response = await _ownerRepository.ToListPagedAsync(ownerQuery, query.PageNumber!.Value, query.PageSize!.Value);


        return OperationResult<PagedList<GetOwnersByGridQueryResponse>>.SuccessResult(response);

    }
}


