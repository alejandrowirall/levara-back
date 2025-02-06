using Levara.Domain.DAL.Repositories;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace Levara.Application.Owners.GetBalance;

public class GetOwnerBalanceQueryHandler : IQueryHandler<GetOwnerBalanceQuery, GetOwnerBalanceQueryResponse>
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly IOwnerBankAccountRepository _ownerBankAccountRepository;
    private readonly IBankTransactionRepository _bankTransactionRepository;
    private readonly IPropertyRepository _propertyRepository;
    private readonly IPropertyNotificationRepository _propertyNotificationRepository;
    private readonly IRentPaymentNotificationRepository _rentPaymentNotificationRepository;
    public GetOwnerBalanceQueryHandler(IOwnerRepository ownerRepository,
        IOwnerBankAccountRepository ownerBankAccountRepository,
        IBankTransactionRepository bankTransactionRepository,
        IPropertyRepository propertyRepository,
        IPropertyNotificationRepository propertyNotificationRepository,
        IRentPaymentNotificationRepository rentPaymentNotificationRepository) 
    {
        _ownerRepository = ownerRepository;
        _ownerBankAccountRepository = ownerBankAccountRepository;
        _bankTransactionRepository = bankTransactionRepository;
        _propertyRepository = propertyRepository;
        _propertyNotificationRepository = propertyNotificationRepository;
        _rentPaymentNotificationRepository = rentPaymentNotificationRepository;
    }
    public async Task<OperationResult<GetOwnerBalanceQueryResponse>> Handle(GetOwnerBalanceQuery query)
    {
        var owner = await _ownerRepository.GetByIdAsync(query.Id!.Value);
        if (owner == null)
            return OperationResult<GetOwnerBalanceQueryResponse>.ErrorResult(new ErrorDetails(404, "Owner not found."));


      


        //var ownerBankAccountQuery = _ownerBankAccountRepository.GetAll()
        //                                                       .Where(oba => oba.OwnerId == query.Id!.Value)
        //                                                       .OrderByDescending(oba => oba.Id);

        //var ownerBankAccount = await _ownerBankAccountRepository.FirstOrDefaultAsync(ownerBankAccountQuery);

        var ownerBalance = await _bankTransactionRepository.GetAll()
                                                           .Where(bt => bt.OwnerBankAccount.OwnerId == owner.Id)
                                                           .GroupBy(bt => bt.OwnerBankAccountId)
                                                           .Select(g => g.OrderByDescending(bt => bt.Date).FirstOrDefault().RunningBalance ?? 0)
                                                           .SumAsync();

        var bankTransactionQuery = _bankTransactionRepository.GetAllWithOwnerBankAccount()
                                                             .Where(bt => bt.OwnerBankAccount.OwnerId == owner.Id)
                                                             .Take(3)
                                                             .OrderByDescending(bt => bt.Date);

        var lastBankTransactions = await _bankTransactionRepository.ToListAsync(bankTransactionQuery);

        var lastBankTransaction = lastBankTransactions.FirstOrDefault();

        OwnerCard ownerCard = new (owner, ownerBalance.ToString("F2"));

        var btsGrid = lastBankTransactions.Select(bt => new BankTransactionGrid(bt));

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


        var propertyRunningBalanceQuery = _bankTransactionRepository.GetAllWithProperty()
                                                               .Where(bt => bt.Property.OwnerId == ownerId)
                                                               .GroupBy(bt => bt.PropertyId)
                                                               .Select(g => g.OrderByDescending(bt => bt.Date)
                                                                             .ThenByDescending(bt => bt.Id)
                                                                             .Select(bt => new
                                                                             {
                                                                                 PropertyId = bt.Property.Id,
                                                                                 RunningBalance = bt.RunningBalance!.Value
                                                                             })
                                                                             .Single());

        var propertyRunningBalances = await _bankTransactionRepository.ToListAsync(propertyRunningBalanceQuery);


        foreach (var propertyRunningBalance in propertyRunningBalances)
        {
            var propertyBalance = propertyBalances.FirstOrDefault(pb => pb.Id == propertyRunningBalance.PropertyId);
            if (propertyBalance != null)
                propertyBalance.Balance = propertyRunningBalance.RunningBalance;
        }

        return propertyBalances;
    }
}
