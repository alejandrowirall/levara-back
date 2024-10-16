
using Boilerplate.Domain.DAL;
using Boilerplate.Domain.Models;
using Boilerplate.Shared.Domain.Bus.Queries;
using Boilerplate.Shared.Results;

namespace Boilerplate.Application.Owers.GetByGrid;

public class GetOwnersByGridQueryHandler : IQueryHandler<GetOwnersByGridQuery, PagedList<GetOwnersByGridQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetOwnersByGridQueryHandler(IUnitOfWork unitOfWork) 
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<OperationResult<PagedList<GetOwnersByGridQueryResponse>>> Handle(GetOwnersByGridQuery query)
    {
        IRepository<Owner> ownerRepository = _unitOfWork.Repository<Owner>();

        var ownerQuery = ownerRepository.GetAll()
                                        .OrderByDescending(o => o.CreatedDate)
                                        .Select(o => new GetOwnersByGridQueryResponse(o));

        var response = await ownerRepository.ToListPagedAsync(ownerQuery, query.PageNumber!.Value, query.PageSize!.Value);


        return OperationResult<PagedList<GetOwnersByGridQueryResponse>>.SuccessResult(response);

    }
}


