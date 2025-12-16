
using Levara.Domain.DAL.Repositories;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.LeaseChargeTypes.Get;

public class GetLeaseChargeTypeQueryHandler : IQueryHandler<GetLeaseChargeTypeQuery, IEnumerable<GetLeaseChargeTypeQueryResponse>>
{
    private readonly ILeaseChargeTypeRepository _leaseChargeTypeRepository;
    public GetLeaseChargeTypeQueryHandler(ILeaseChargeTypeRepository leaseChargeTypeRepository) 
    {
        _leaseChargeTypeRepository = leaseChargeTypeRepository;
    }
    public async Task<OperationResult<IEnumerable<GetLeaseChargeTypeQueryResponse>>> Handle(GetLeaseChargeTypeQuery query)
    {

        var leaseChargeTypeQuery = _leaseChargeTypeRepository.GetAll()
                                                             .OrderByDescending(mt => mt.Name)
                                                             .Select(mt => new GetLeaseChargeTypeQueryResponse(mt));

    

        var response = await _leaseChargeTypeRepository.ToListAsync(leaseChargeTypeQuery);


        return OperationResult<IEnumerable<GetLeaseChargeTypeQueryResponse>>.SuccessResult(response);

    }
}


