using Boilerplate.Domain.Contexts;
using Boilerplate.Domain.DAL.Repositories;
using Boilerplate.Shared.Domain.Bus.Queries;
using Boilerplate.Shared.Results;

namespace Boilerplate.Application.Properties.GetForUpdate;

public class GetPropertyForUpdateQueryHandler : IQueryHandler<GetPropertyForUpdateQuery, GetPropertyForUpdateQueryResponse>
{
    private readonly IUserContext _userContext;
    private readonly IPropertyRepository _propertyRepository;
    public GetPropertyForUpdateQueryHandler(IUserContext userContext,
        IPropertyRepository propertyRepository) 
    {
        _userContext = userContext;
        _propertyRepository = propertyRepository;
    }
    public async Task<OperationResult<GetPropertyForUpdateQueryResponse>> Handle(GetPropertyForUpdateQuery query)
    {
        var propertyQuery = _propertyRepository.GetAllWithAddress()
                                               .Where(p => p.Id == query.Id!.Value)
                                               .Select(p => new PropertyUpdateQueryResponse(p));

        PropertyUpdateQueryResponse? property = await _propertyRepository.FirstOrDefaultAsync(propertyQuery);
        if (property == null)
            return OperationResult<GetPropertyForUpdateQueryResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        if (_userContext.IsOwner && property.OwnerId != _userContext.OwnerId!.Value)
            return OperationResult<GetPropertyForUpdateQueryResponse>.ErrorResult(new ErrorDetails(403, "The owner does not have permissions to update this property."));

        GetPropertyForUpdateQueryResponse response = new(property);
        
        return OperationResult<GetPropertyForUpdateQueryResponse>.SuccessResult(response);

    }
}
