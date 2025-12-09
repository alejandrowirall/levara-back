
using Levara.Domain.DAL.Repositories;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Owners.GetDashboard;

public class GetOwnerDashboardQueryHandler : IQueryHandler<GetOwnerDashboardQuery, GetOwnerDashboardQueryResponse>
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly IOwnerBankAccountRepository _ownerBankAccountRepository;
    private readonly IPropertyRepository _propertyRepository;
    private readonly IPropertyNotificationRepository _propertyNotificationRepository;
    private readonly IRentPaymentNotificationRepository _rentPaymentNotificationRepository;
    public GetOwnerDashboardQueryHandler(IOwnerRepository ownerRepository,
        IOwnerBankAccountRepository ownerBankAccountRepository,
        IPropertyRepository propertyRepository,
        IPropertyNotificationRepository propertyNotificationRepository,
        IRentPaymentNotificationRepository rentPaymentNotificationRepository) 
    {
        _ownerRepository = ownerRepository;
        _ownerBankAccountRepository = ownerBankAccountRepository;
        _propertyRepository = propertyRepository;
        _propertyNotificationRepository = propertyNotificationRepository;
        _rentPaymentNotificationRepository = rentPaymentNotificationRepository;
    }
    public async Task<OperationResult<GetOwnerDashboardQueryResponse>> Handle(GetOwnerDashboardQuery query)
    {
        var owner = await _ownerRepository.GetByIdAsync(query.OwnerId!.Value);
        if (owner == null)
            return OperationResult<GetOwnerDashboardQueryResponse>.ErrorResult(new ErrorDetails(404, "Owner not found."));

        var propertyQuery = _propertyRepository.GetAllWithAddress()
                                               .Where(p => p.OwnerId == owner.Id)
                                               .OrderBy(p => p.Number)
                                               .Select(p => new PropertyCard(p));

        var properties = await _propertyRepository.ToListAsync(propertyQuery);

        var ownerBankAccountQuery = _ownerBankAccountRepository.GetAll()
                                                               .Where(oba => oba.OwnerId == query.OwnerId!.Value)
                                                               .OrderByDescending(oba => oba.Id)
                                                               .Select(oba => new OwnerBankAccountGrid(oba));

        var ownerBankAccounts = await _ownerBankAccountRepository.ToListAsync(ownerBankAccountQuery);

        var importantNotificationQuery = _propertyNotificationRepository.GetAll()
                                                                        .Where(pn => pn.ReceiverId == owner.ApplicationUserId)
                                                                        .OrderByDescending(pn => pn.Id)
                                                                        .Take(10)
                                                                        .Select(pn => new ImportantNotificationGrid(pn));

        var importantNotifications = await _propertyNotificationRepository.ToListAsync(importantNotificationQuery);

        var rentPaymentNotificationQuery = _rentPaymentNotificationRepository.GetAll()
                                                                        .Where(rpn => rpn.ReceiverId == owner.ApplicationUserId)
                                                                        .OrderByDescending(rpn => rpn.Id)
                                                                        .Take(10)
                                                                        .Select(rpn => new RentPaymentNotificationGrid(rpn));

        var rentPaymentsNotifications = await _rentPaymentNotificationRepository.ToListAsync(rentPaymentNotificationQuery);


        GetOwnerDashboardQueryResponse response = new(properties, ownerBankAccounts, rentPaymentsNotifications, importantNotifications);
        
        return OperationResult<GetOwnerDashboardQueryResponse>.SuccessResult(response);

    }
}
