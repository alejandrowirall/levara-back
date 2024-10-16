
using Boilerplate.Domain.DAL;
using Boilerplate.Domain.Enum;
using Boilerplate.Domain.Models;
using Boilerplate.Shared.Extensions;
using Boilerplate.Shared.Domain.Bus.Queries;
using Boilerplate.Shared.Results;

namespace Boilerplate.Application.Owers.GetForUpdate;

public class GetOwnerForUpdateQueryHandler : IQueryHandler<GetOwnerForUpdateQuery, GetOwnerForUpdateQueryResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetOwnerForUpdateQueryHandler(IUnitOfWork unitOfWork) 
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<OperationResult<GetOwnerForUpdateQueryResponse>> Handle(GetOwnerForUpdateQuery query)
    {
        IRepository<Owner> ownerRepository = _unitOfWork.Repository<Owner>();

        Owner? owner = await ownerRepository.GetByIdAsync(query.Id!.Value);
        if (owner == null)
            return OperationResult<GetOwnerForUpdateQueryResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        GetOwnerForUpdateQueryResponse response = new(owner, 
                                                      EnumExtensions.ToListModel<PersonType>((int)owner.PersonType), 
                                                      EnumExtensions.ToListModel<IdentificationType>((int)owner.IdentificationType));
        
        return OperationResult<GetOwnerForUpdateQueryResponse>.SuccessResult(response);

    }
}
