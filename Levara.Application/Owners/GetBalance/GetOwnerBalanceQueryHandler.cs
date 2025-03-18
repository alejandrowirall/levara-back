using Levara.Domain.DAL.Repositories;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace Levara.Application.Owners.GetBalance;

public class GetOwnerBalanceQueryHandler : IQueryHandler<GetOwnerBalanceQuery, GetOwnerBalanceQueryResponse>
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly IOwnerBankAccountRepository _ownerBankAccountRepository;
    private readonly IPaymentRepository _paymentRepository;
    private readonly IPropertyRepository _propertyRepository;
    private readonly IPropertyNotificationRepository _propertyNotificationRepository;
    private readonly IRentPaymentNotificationRepository _rentPaymentNotificationRepository;
    public GetOwnerBalanceQueryHandler(IOwnerRepository ownerRepository,
        IOwnerBankAccountRepository ownerBankAccountRepository,
        IPaymentRepository paymentRepository,
        IPropertyRepository propertyRepository,
        IPropertyNotificationRepository propertyNotificationRepository,
        IRentPaymentNotificationRepository rentPaymentNotificationRepository) 
    {
        _ownerRepository = ownerRepository;
        _ownerBankAccountRepository = ownerBankAccountRepository;
        _paymentRepository = paymentRepository;
        _propertyRepository = propertyRepository;
        _propertyNotificationRepository = propertyNotificationRepository;
        _rentPaymentNotificationRepository = rentPaymentNotificationRepository;
    }
    public async Task<OperationResult<GetOwnerBalanceQueryResponse>> Handle(GetOwnerBalanceQuery query)
    {
        var owner = await _ownerRepository.GetByIdAsync(query.Id!.Value);
        if (owner == null)
            return OperationResult<GetOwnerBalanceQueryResponse>.ErrorResult(new ErrorDetails(404, "Owner not found."));


        var ownerBalance = await _paymentRepository.GetAll()
                                                   .Where(bt => bt.Property.OwnerId == owner.Id)
                                                   .GroupBy(bt => bt.PropertyId)
                                                   .Select(g => g.OrderByDescending(bt => bt.CreatedDate).FirstOrDefault().RunningBalance)
                                                   .SumAsync();

        var lastPaymentsQuery = _paymentRepository.GetAllWithOwnerBankAccount()
                                                     .Where(bt => bt.Property.OwnerId == owner.Id)
                                                     .OrderByDescending(bt => bt.Date)
                                                     .Take(3);

        var lastPayments = await _paymentRepository.ToListAsync(lastPaymentsQuery);

        var lastPayment = lastPayments.FirstOrDefault();

        OwnerCard ownerCard = new (owner, ownerBalance);

        var btsGrid = lastPayments.Select(bt => new PaymentGrid(bt));

        var propertyBalances = await GetPropertyBalances(owner.Id);

        GetOwnerBalanceQueryResponse response = new(ownerCard, btsGrid, propertyBalances);
        
        return OperationResult<GetOwnerBalanceQueryResponse>.SuccessResult(response);

    }

    private async Task<IEnumerable<PropertyBalanceGrid>> GetPropertyBalances(int ownerId)
    {
        var propertyBalanceQuery = _propertyRepository.GetAllWithAddress()
                                                      .Where(p => p.OwnerId == ownerId)
                                                      .Select(p => new PropertyBalanceGrid(p));

        var propertyBalances = await propertyBalanceQuery.ToListAsync();


        var propertyRunningBalanceQuery = _paymentRepository.GetAllWithProperty()
                                                               .Where(bt => bt.Property.OwnerId == ownerId)
                                                               .GroupBy(bt => bt.PropertyId)
                                                               .Select(g => g.OrderByDescending(bt => bt.CreatedDate)
                                                                             .ThenByDescending(bt => bt.Id)
                                                                             .Select(bt => new
                                                                             {
                                                                                 PropertyId = bt.Property.Id,
                                                                                 RunningBalance = bt.RunningBalance
                                                                             })
                                                                             .Single());

        var propertyRunningBalances = await _paymentRepository.ToListAsync(propertyRunningBalanceQuery);


        foreach (var propertyRunningBalance in propertyRunningBalances)
        {
            var propertyBalance = propertyBalances.FirstOrDefault(pb => pb.Id == propertyRunningBalance.PropertyId);
            if (propertyBalance != null)
                propertyBalance.Balance = propertyRunningBalance.RunningBalance;
        }

        return propertyBalances;
    }
}
