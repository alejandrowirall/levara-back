
using Levara.DAL.Repositories;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Domain.Models;
using Levara.Shared.Extensions;
using Levara.Shared.Results;

namespace Levara.Application.RecurringCharges.GetRLeaseChargeForCreate;


public class GetLeaseChargeForCreateQueryHandler : IQueryHandler<GetRLeaseChargeForCreateQuery, GetRLeaseChargeForCreateQueryResponse>
{
    private readonly ILeaseRepository _leaseRepository;
    private readonly ILeaseChargeTypeRepository _leaseChargeTypeRepository;
    public GetLeaseChargeForCreateQueryHandler(ILeaseRepository leaseRepository,
        ILeaseChargeTypeRepository leaseChargeTypeRepository)
    {
        _leaseRepository = leaseRepository;
        _leaseChargeTypeRepository = leaseChargeTypeRepository;
    }
    public async Task<OperationResult<GetRLeaseChargeForCreateQueryResponse>> Handle(GetRLeaseChargeForCreateQuery query)
    {
        var leaseQuery = _leaseRepository.GetAllFull()
                                         .Where(l => l.Id == query.LeaseId);

        var lease = await _leaseRepository.FirstOrDefaultAsync(leaseQuery);
        if (lease == null)
            return OperationResult<GetRLeaseChargeForCreateQueryResponse>.ErrorResult(
                new ErrorDetails(404, $"Lease with id {query.LeaseId} not found"));

        var leaseChargeTypeQuery = _leaseChargeTypeRepository.GetAll()
                                                              .Select(lct => new ListModel { Id = lct.Id, Text = lct.Name });

        var leaseChargeTypes = await _leaseChargeTypeRepository.ToListAsync(leaseChargeTypeQuery);


        GetRLeaseChargeForCreateQueryResponse response = new(lease,
                                                             EnumExtensions.ToListModel<FrequencyType>(),
                                                             leaseChargeTypes);

        return OperationResult<GetRLeaseChargeForCreateQueryResponse>.SuccessResult(response);
    }
}
