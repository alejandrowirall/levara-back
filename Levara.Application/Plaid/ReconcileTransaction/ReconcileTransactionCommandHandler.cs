using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Extensions;
using Levara.Shared.Results;

namespace Levara.Application.Plaid.ReconcileTransaction;

public class ReconcileTransactionCommandHandler : ICommandHandler<ReconcileTransactionCommand, ReconcileTransactionCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPlaidRepository _plaidRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IPlaidReconciliationRepository _plaidReconciliationRepository;

    public ReconcileTransactionCommandHandler(IUnitOfWork unitOfWork,
        IPlaidRepository plaidRepository,
        ITransactionRepository transactionRepository,
        IPlaidReconciliationRepository plaidReconciliationRepository)
    {
        _unitOfWork = unitOfWork;
        _plaidRepository = plaidRepository;
        _transactionRepository = transactionRepository;
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

        List<PlaidReconciliation> reconciliations = await ReconcileTransaction(plaidtx);

        await _unitOfWork.ExecuteAsTransactionAsync(async () =>
        {
            if (reconciliations.Count == 0)
            {
                plaidtx.Status = PlaidTransactionStatus.PersonalPayment;
                _plaidRepository.Update(plaidtx);
                return;
            }

            plaidtx.Status = PlaidTransactionStatus.NeedReview;
            _plaidRepository.Update(plaidtx);
            await _plaidReconciliationRepository.AddAsync(reconciliations);
        });

        return OperationResult<ReconcileTransactionCommandResponse>.SuccessResult(new ReconcileTransactionCommandResponse(plaidtx.Id));
    }

    private async Task<List<PlaidReconciliation>> ReconcileTransaction(PlaidTransaction plaidtx)
    {
        List<PlaidReconciliation> reconciliations = [];

        int ownerId = plaidtx.OwnerBankAccount.OwnerId;
        decimal plaidtxAmount = plaidtx.Amount;

        int plaidYear = plaidtx.Date.Year;
        int plaidMonth = plaidtx.Date.Month;

        var transactionQuery = _transactionRepository.GetAllFull().Where(t =>
            t.Property.OwnerId == ownerId &&
            t.SubType == TransactionSubType.Charge &&
            t.Status == TransactionStatus.Unpaid &&
            t.Date.Year == plaidYear &&
            t.Date.Month == plaidMonth &&
            (t.Amount == plaidtxAmount || t.Amount == ((-1) * plaidtxAmount)));

        var transactions = await _transactionRepository.ToListAsync(transactionQuery);
        if (!transactions.Any())
            return reconciliations;

        

        foreach (var transaction in transactions)
        {
            PlaidReconciliation reconciliation = new()
            {
                TransactionId = transaction.Id,
                PlaidTransactionId = plaidtx.Id
            };
            reconciliations.Add(reconciliation);
        }

        return reconciliations;
    }
}