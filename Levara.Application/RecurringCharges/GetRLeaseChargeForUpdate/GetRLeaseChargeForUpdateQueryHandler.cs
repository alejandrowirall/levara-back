using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Domain.Models;
using Levara.Shared.Extensions;
using Levara.Shared.Results;

namespace Levara.Application.RecurringCharges.GetRLeaseChargeForUpdate;


public class GetLeaseChargeForUpdateQueryHandler : IQueryHandler<GetRLeaseChargeForUpdateQuery, GetRLeaseChargeForUpdateQueryResponse>
{
    private readonly ILeaseRepository _leaseRepository;
    private readonly ILeaseChargeTypeRepository _leaseChargeTypeRepository;

    private readonly IRecurringChargeRepository _recurringChargeRepository;

    public GetLeaseChargeForUpdateQueryHandler(ILeaseRepository leaseRepository,
        ILeaseChargeTypeRepository leaseChargeTypeRepository,
        IRecurringChargeRepository recurringChargeRepository)
    {
        _leaseRepository = leaseRepository;
        _leaseChargeTypeRepository = leaseChargeTypeRepository;
        _recurringChargeRepository = recurringChargeRepository;
    }
    public async Task<OperationResult<GetRLeaseChargeForUpdateQueryResponse>> Handle(GetRLeaseChargeForUpdateQuery query)
    {
        var recurringCharge = await _recurringChargeRepository.GetByIdAsync(query.Id!.Value);
        if (recurringCharge == null || !recurringCharge.LeaseId.HasValue)
            return OperationResult<GetRLeaseChargeForUpdateQueryResponse>.ErrorResult(
                new ErrorDetails(404, $"RecurringCharge with id {query.Id} not found "));


        var leaseQuery = _leaseRepository.GetAllFull()
                                         .Where(l => l.Id == recurringCharge.LeaseId);

        var lease = await _leaseRepository.FirstOrDefaultAsync(leaseQuery);
        if (lease == null)
            return OperationResult<GetRLeaseChargeForUpdateQueryResponse>.ErrorResult(
                new ErrorDetails(404, $"Lease with id {recurringCharge.LeaseId} not found"));

        var leaseChargeTypeQuery = _leaseChargeTypeRepository.GetAll()
                                                              .Select(lct => new ListModel { Id = lct.Id, Text = lct.Name });

        var leaseChargeTypes = await _leaseChargeTypeRepository.ToListAsync(leaseChargeTypeQuery);


        GetRLeaseChargeForUpdateQueryResponse response = new(recurringCharge,
                                                             lease,
                                                             EnumExtensions.ToListModel<FrequencyType>(),
                                                             leaseChargeTypes);

        return OperationResult<GetRLeaseChargeForUpdateQueryResponse>.SuccessResult(response);
    }
}
