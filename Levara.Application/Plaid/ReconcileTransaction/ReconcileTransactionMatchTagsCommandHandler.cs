
using Levara.DAL.Repositories;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.ExternalService.Plaid;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Extensions;
using Levara.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace Levara.Application.Plaid.ReconcileTransaction;

public class ReconcileTransactionMatchTagsCommandHandler// : ICommandHandler<ReconcileTransactionCommand, ReconcileTransactionCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPlaidRepository _plaidRepository;
    private readonly IPaymentRepository _paymentRepository;
    private readonly IExpenseRepository _expenseRepository;
    private readonly IExpenseChargeRepository _expenseChargeRepository;
    private readonly IExpensePaymentRepository _expensePaymentRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly ITransactionApplicationRepository _transactionApplicationRepository;
    private readonly IPropertyRepository _propertyRepository;
    private readonly ILeaseRepository _leaseRepository;
    private readonly ILeaseChargeRepository _leaseChargeRepository;
    private readonly IPlaidReconciliationRepository _plaidReconciliationRepository;
    public ReconcileTransactionMatchTagsCommandHandler(IUnitOfWork unitOfWork,
        IPlaidRepository plaidRepository,
        IPaymentRepository paymentRepository,
        IExpenseRepository expenseRepository,
        IExpenseChargeRepository expenseChargeRepository,
        IExpensePaymentRepository expensePaymentRepository,
        ITransactionRepository transactionRepository,
        ITransactionApplicationRepository transactionApplicationrepository,
        IPropertyRepository propertyRepository,
        ILeaseRepository leaseRepository,
        ILeaseChargeRepository leaseChargeRepository,
        IPlaidReconciliationRepository plaidReconciliationRepository)
    {
        _unitOfWork = unitOfWork;
        _plaidRepository = plaidRepository;
        _paymentRepository = paymentRepository;
        _expenseRepository = expenseRepository;
        _expenseChargeRepository = expenseChargeRepository;
        _expensePaymentRepository = expensePaymentRepository;
        _transactionRepository = transactionRepository;
        _transactionApplicationRepository = transactionApplicationrepository;
        _propertyRepository = propertyRepository;
        _leaseRepository = leaseRepository;
        _leaseChargeRepository = leaseChargeRepository;
        _plaidReconciliationRepository = plaidReconciliationRepository;
    }
    public async Task<OperationResult<ReconcileTransactionCommandResponse>> Handle(ReconcileTransactionCommand command)
    {

        var plaidTxQuery = _plaidRepository.GetAllWithOwnerBankAccount()
                                           .Where(o => o.Id == command.PlaidId!);

        PlaidTransaction? plaidtx = await _plaidRepository.FirstOrDefaultAsync(plaidTxQuery);
        if (plaidtx == null)
            return OperationResult<ReconcileTransactionCommandResponse>.ErrorResult(new ErrorDetails(404, "Not found"));

        if (plaidtx.Status != PlaidTransactionStatus.Created)
            return OperationResult<ReconcileTransactionCommandResponse>.ErrorResult(new ErrorDetails(400, $"Plaid transaction must be in state {EnumExtensions.GetEnumDescription(PlaidTransactionStatus.Created)}"));

        if (plaidtx.Amount >= 0)
            return await ReconcileLeaseTransaction(plaidtx);


        return await ReconcileMaintenanceTransaction(plaidtx);
    }

    

    private async Task<OperationResult<ReconcileTransactionCommandResponse>> ReconcileLeaseTransaction(PlaidTransaction plaidtx)
    {
        int ownerId = plaidtx.OwnerBankAccount.OwnerId;

        string normalizedDescription = plaidtx.Description.ToLower();

        var ownerPropertiesQuery = _propertyRepository.GetAll()
                                                    .Where(p => p.OwnerId == ownerId)
                                                    .Select(p => p.Id);

        var potentialLeaseMatchesQuery = _leaseRepository.GetAll()
                                                         .Where(l => ownerPropertiesQuery.Contains(l.PropertyId) &&
                                                                     l.MatchTags.Any(tag => normalizedDescription.Contains(tag.ToLower())));

        var potentialLeaseMatches = await _leaseRepository.ToListAsync(potentialLeaseMatchesQuery);
        if (potentialLeaseMatches.Count() == 0)
        {
            await _unitOfWork.ExecuteAsTransactionAsync( () =>
            {
                plaidtx.Status = PlaidTransactionStatus.PersonalPayment;
                _plaidRepository.Update(plaidtx);
                return Task.CompletedTask;
            });

            return OperationResult<ReconcileTransactionCommandResponse>.SuccessResult(new ReconcileTransactionCommandResponse(plaidtx.Id));
        }

        var leaseAllMatches = potentialLeaseMatches.Where(l => l.MatchTags.All(tag => normalizedDescription.Contains(tag.ToLower())));
        if(leaseAllMatches.Count() == 0)
        {
            await _unitOfWork.ExecuteAsTransactionAsync(() =>
            {
                plaidtx.Status = PlaidTransactionStatus.PersonalPayment;
                _plaidRepository.Update(plaidtx);
                return Task.CompletedTask;
            });

            return OperationResult<ReconcileTransactionCommandResponse>.SuccessResult(new ReconcileTransactionCommandResponse(plaidtx.Id));
        }

        var leaseChargeQuery = _leaseChargeRepository.GetAllFull().Where(lc => leaseAllMatches.Select(m => m.Id).Contains(lc.LeaseId) &&
                                                                               lc.Status == LeaseChargeStatus.Unpaid &&
                                                                               lc.Transaction.Amount == plaidtx.Amount);

        var leaseCharges = await _leaseChargeRepository.ToListAsync(leaseChargeQuery);
        if (leaseCharges.Count() == 0)
        {
            await _unitOfWork.ExecuteAsTransactionAsync(() =>
            {
                plaidtx.Status = PlaidTransactionStatus.PersonalPayment;
                _plaidRepository.Update(plaidtx);
                return Task.CompletedTask;
            });

            return OperationResult<ReconcileTransactionCommandResponse>.SuccessResult(new ReconcileTransactionCommandResponse(plaidtx.Id));
        }


        List<PlaidReconciliation> reconciliations = new ();

        foreach (var leaseCharge in leaseCharges)
        {
            PlaidReconciliation reconciliation = new()
            {
                TransactionId = leaseCharge.TransactionId,
                PlaidTransactionId = plaidtx.Id
            };
            reconciliations.Add(reconciliation);
        }

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            plaidtx.Status = PlaidTransactionStatus.NeedReview;
            _plaidRepository.Update(plaidtx);
            await _plaidReconciliationRepository.AddAsync(reconciliations);
        });

        return OperationResult<ReconcileTransactionCommandResponse>.SuccessResult(new ReconcileTransactionCommandResponse(plaidtx.Id));
    }
    private async Task<OperationResult<ReconcileTransactionCommandResponse>> ReconcileMaintenanceTransaction(PlaidTransaction plaidtx)
    {
        return null;
    }

    private async Task<OperationResult<ReconcileTransactionCommandResponse>> ReconcileExpenseTransaction(PlaidTransaction plaidtx)
    {
        return null;
    }
}
