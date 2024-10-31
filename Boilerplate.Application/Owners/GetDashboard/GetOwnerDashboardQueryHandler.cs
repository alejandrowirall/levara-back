
using Boilerplate.Domain.DAL.Repositories;
using Boilerplate.Shared.Domain.Bus.Queries;
using Boilerplate.Shared.Results;

namespace Boilerplate.Application.Owners.GetDashboard;

public class GetOwnerDashboardQueryHandler : IQueryHandler<GetOwnerDashboardQuery, GetOwnerDashboardQueryResponse>
{
    private readonly IOwnerBankAccountRepository _ownerBankAccountRepository;
    private readonly IPropertyRepository _propertyRepository;
    public GetOwnerDashboardQueryHandler(IOwnerBankAccountRepository ownerBankAccountRepository,
        IPropertyRepository propertyRepository) 
    {
        _ownerBankAccountRepository = ownerBankAccountRepository;
        _propertyRepository = propertyRepository;
    }
    public async Task<OperationResult<GetOwnerDashboardQueryResponse>> Handle(GetOwnerDashboardQuery query)
    {
        var propertyQuery = _propertyRepository.GetAllWithAddress()
                                               .Where(p => p.OwnerId == query.Id!.Value)
                                               .OrderBy(p => p.Number)
                                               .Select(p => new PropertyCard(p));

        var properties = await _propertyRepository.ToListAsync(propertyQuery);

        var ownerBankAccountQuery =  _ownerBankAccountRepository.GetAll()
                                                                .Where(oba => oba.OwnerId == query.Id!.Value)
                                                                .OrderByDescending(oba => oba.Id)
                                                                .Select(oba => new OwnerBankAccountGrid(oba));

        var ownerBankAccounts = await _ownerBankAccountRepository.ToListAsync(ownerBankAccountQuery);


        GetOwnerDashboardQueryResponse response = new(properties, ownerBankAccounts);
        
        return OperationResult<GetOwnerDashboardQueryResponse>.SuccessResult(response);

    }
}
