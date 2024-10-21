
using Boilerplate.Domain.DAL;
using Boilerplate.Domain.Enum;
using Boilerplate.Shared.Extensions;
using Boilerplate.Shared.Domain.Bus.Queries;
using Boilerplate.Shared.Results;
using Boilerplate.Domain.DAL.Repositories;

namespace Boilerplate.Application.Owers.GetForUpdate;

public class GetOwnerForUpdateQueryHandler : IQueryHandler<GetOwnerForUpdateQuery, GetOwnerForUpdateQueryResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOwnerRepository _ownerRepository;
    public GetOwnerForUpdateQueryHandler(IUnitOfWork unitOfWork,
        IOwnerRepository ownerRepository) 
    {
        _unitOfWork = unitOfWork;
        _ownerRepository = ownerRepository;
    }
    public async Task<OperationResult<GetOwnerForUpdateQueryResponse>> Handle(GetOwnerForUpdateQuery query)
    {
        var ownerQuery = _ownerRepository.GetAllWithAddress()
                                         .Where(o => o.Id == query.Id!.Value)
                                         .Select(o => new OwnerUpdateQueryResponse(o));

        OwnerUpdateQueryResponse? owner = await _ownerRepository.FirstOrDefaultAsync(ownerQuery);
        if (owner == null)
            return OperationResult<GetOwnerForUpdateQueryResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        GetOwnerForUpdateQueryResponse response = new(owner, 
                                                      EnumExtensions.ToListModel<PersonType>((int)owner.PersonType), 
                                                      EnumExtensions.ToListModel<IdentificationType>((int)owner.IdentificationType));
        
        return OperationResult<GetOwnerForUpdateQueryResponse>.SuccessResult(response);

    }
}
