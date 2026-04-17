using Levara.Application.ExpenseCharges.Create;
using Levara.Application.LeaseCharges.Create;
using Levara.Application.MaintenancesCharges.Create;
using Levara.Application.Plaid.CreateExpensePayment;
using Levara.Application.Plaid.CreateLeasePayment;
using Levara.Application.Plaid.CreateMaintenancePayment;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Levara.Application.Plaid.ReconcileTransaction;

public class ReconcileTransactionCommandHandler : ICommandHandler<ReconcileTransactionCommand, ReconcileTransactionCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOwnerBankAccountRepository _ownerBankAccountRepository;
    private readonly IPropertyRepository _propertyRepository;
    private readonly IRecurringChargeInstanceRepository _recurringChargeInstanceRepository;
    private readonly IRecurringChargeRepository _recurringChargeRepository;
    private readonly IPlaidRepository _plaidRepository;
    private readonly IPlaidReconciliationRepository _plaidReconciliationRepository;
    private readonly ITransactionRepository _transactionRepository;

    private readonly CreateLeasePaymentCommandService _createLeasePaymentCommandService;
    private readonly CreateExpensePaymentCommandService _createExpensePaymentCommandService;
    private readonly CreateMaintenancePaymentCommandService _createMaintenancePaymentCommandService;

    private readonly CreateLeaseChargeCommandService _createLeaseChargeCommandService;
    private readonly CreateExpenseChargeCommandService _createExpenseChargeCommandService;
    private readonly CreateMaintenanceChargeCommandService _createMaintenanceChargeCommandService;

    private readonly ILogger<ReconcileTransactionCommandHandler> _logger;

    // Configuración del algoritmo V1
    private const decimal SCORE_THRESHOLD = 50m;           // Mínimo para ser candidato
    private const decimal AUTO_APPLY_THRESHOLD = 90m;      // Auto-reconciliar
    private const decimal AMOUNT_TOLERANCE_PERCENT = 10m;  // Tolerancia de monto
    private const decimal EXACT_TAG_SCORE = 50m;           // Máximo score de tags
    private const decimal EXACT_AMOUNT_SCORE = 50m;        // Máximo score de amount
    private const int TOP_CANDIDATES_COUNT = 5;            // Top 5 familias
    private const int MAX_RECONCILIATION_PASSES = 3;       // Máximo número de pasadas para AutoReconcile

    public ReconcileTransactionCommandHandler(
        IUnitOfWork unitOfWork,
        IOwnerBankAccountRepository ownerBankAccountRepository,
        IRecurringChargeInstanceRepository recurringChargeInstanceRepository,
        IRecurringChargeRepository recurringChargeRepository,
        IPlaidRepository plaidRepository,
        IPlaidReconciliationRepository plaidReconciliationRepository,
        ITransactionRepository transactionRepository,
        IPropertyRepository propertyRepository,

        CreateLeasePaymentCommandService createLeasePaymentCommandService,
        CreateExpensePaymentCommandService createExpensePaymentCommandService,
        CreateMaintenancePaymentCommandService createMaintenancePaymentCommandService,

        CreateLeaseChargeCommandService createLeaseChargeCommandService,
        CreateExpenseChargeCommandService createExpenseChargeCommandService,
        CreateMaintenanceChargeCommandService createMaintenanceChargeCommandService,

        ILogger<ReconcileTransactionCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _ownerBankAccountRepository = ownerBankAccountRepository;
        _recurringChargeInstanceRepository = recurringChargeInstanceRepository;
        _recurringChargeRepository = recurringChargeRepository;
        _plaidRepository = plaidRepository;
        _plaidReconciliationRepository = plaidReconciliationRepository;
        _transactionRepository = transactionRepository;
        _propertyRepository = propertyRepository;

        _createLeasePaymentCommandService = createLeasePaymentCommandService;
        _createExpensePaymentCommandService = createExpensePaymentCommandService;
        _createMaintenancePaymentCommandService = createMaintenancePaymentCommandService;

        _createLeaseChargeCommandService = createLeaseChargeCommandService;
        _createExpenseChargeCommandService = createExpenseChargeCommandService;
        _createMaintenanceChargeCommandService = createMaintenanceChargeCommandService;

        _logger = logger;
    }

    public async Task<OperationResult<ReconcileTransactionCommandResponse>> Handle(ReconcileTransactionCommand command)
    {
        var utcNow = DateTime.UtcNow; // Fecha de corte para filtrar cargos futuros

        var ownerBankAccount = await _ownerBankAccountRepository.FirstOrDefaultAsync(oba => oba.Id == command.OwnerBankAccountId!.Value);
        if (ownerBankAccount == null)
        {
            return OperationResult<ReconcileTransactionCommandResponse>.ErrorResult(new ErrorDetails(404, "OwnerBankAccount not found"));
        }
        //Aca obtengo solo las propiedades relacionadas al bank account
        var propertiesQuery= _propertyRepository.GetAll().Where(p=>p.OwnerBankAccountId == ownerBankAccount.Id);
        var propertyIds = await _propertyRepository.ToListAsync(propertiesQuery);
        var propertyIdSet = propertyIds.Select(p => p.Id).ToHashSet();

        // Cargar RecurringCharges por separado según IsRecurrent
        var recurringChargesRecurrentQuery = _recurringChargeRepository.GetAllFull()
            .Where(rc => propertyIdSet.Contains(rc.PropertyId) &&
                          rc.Active &&
                          rc.IsRecurrent == true && !rc.Spliteable);

        var recurringChargesRecurrent = await _recurringChargeRepository.ToListAsync(recurringChargesRecurrentQuery);
        // ============================================================
        // GENERAR CARGOS PENDIENTES ANTES DE RECONCILIAR
        // Asegura que todos los cargos hasta la fecha actual estén disponibles
        // ============================================================
        await GeneratePendingCharges(recurringChargesRecurrent, utcNow);


        // Obtener transacciones pendientes para este banco
        var pendingTransactionsQuery = _plaidRepository.GetAll()
            .Where(pt => pt.OwnerBankAccountId == command.OwnerBankAccountId!.Value &&
                         (pt.Status == PlaidTransactionStatus.Created ||
                            pt.Status == PlaidTransactionStatus.NoMatch ||
                            pt.Status == PlaidTransactionStatus.Error
                         )).OrderBy(pt => pt.Date);

        var pendingTransactions = await _plaidRepository.ToListAsync(pendingTransactionsQuery);

        if (!pendingTransactions.Any())
        {
            return OperationResult<ReconcileTransactionCommandResponse>.SuccessResult(new());
        }

        var recurringChargesNonRecurrentQuery = _recurringChargeRepository.GetAllFull()
            .Where(rc => rc.Property.OwnerId == ownerBankAccount.OwnerId &&
                         propertyIdSet.Contains(rc.PropertyId) &&
                         rc.Active &&
                         rc.IsRecurrent == false && !rc.Spliteable);

        var recurringChargesNonRecurrent = await _recurringChargeRepository.ToListAsync(recurringChargesNonRecurrentQuery);



        
        var recurringChargesNonRecurrentSplitablesQuery = _recurringChargeRepository.GetAllFull()
           .Where(rc => rc.Property.OwnerId == ownerBankAccount.OwnerId &&
                         propertyIdSet.Contains(rc.PropertyId) &&
                         rc.Active &&
                         rc.IsRecurrent == false && rc.Spliteable);

        var recurringChargesNonRecurrentSplitables = await _recurringChargeRepository.ToListAsync(recurringChargesNonRecurrentSplitablesQuery);
        // ============================================================
        // FILTRO EN MEMORIA: Transacciones en NeedReview en esta ejecución
        // Evita que múltiples PlaidTransactions matcheen con los mismos cargos
        // que ya fueron asignados a NeedReview (siguen Unpaid pero están "reservados")
        // ============================================================

        // ============================================================
        // NIVEL 1: RecurringCharges con IsRecurrent=true (Pasadas 1-3)
        // ============================================================
        await ProcessLevel1_RecurrentCharges(pendingTransactions, recurringChargesRecurrent, utcNow);

        // ============================================================
        // NIVEL 2: RecurringCharges con IsRecurrent=false (Pasadas 4-6)
        // ============================================================
        await ProcessLevel2_NonRecurrentCharges(pendingTransactions, recurringChargesNonRecurrent);
        //ACA METER CARGOS SPLITEABLES 
        // ============================================================
        // NIVEL 3: NonRecurringChargesSpliteables con IsRecurrent=false Spliteable=true (Pasadas 4-6)
        // ============================================================
        await ProcessLevel3_NonRecurrentChargesSpliteable(pendingTransactions, recurringChargesNonRecurrentSplitables, propertyIdSet);


        // ============================================================
        // PASADA FINAL: NeedReview con candidatos de todos los niveles
        // Incluye transacciones sueltas que no pueden auto-reconciliarse (sin tags)
        // ============================================================
        await ProcessFinalPassNeedReview(pendingTransactions, recurringChargesRecurrent, recurringChargesNonRecurrent, ownerBankAccount.OwnerId, utcNow);

        return OperationResult<ReconcileTransactionCommandResponse>.SuccessResult(new());
    }

    /// <summary>
    /// Genera todos los cargos pendientes para RecurringCharges con IsRecurrent=true
    /// hasta la fecha actual. Esto asegura que haya candidatos disponibles para reconciliar.
    /// </summary>
    private async Task GeneratePendingCharges(IEnumerable<RecurringCharge> recurringCharges, DateTime utcNow)
    {
        foreach (var rc in recurringCharges)
        {
            // Solo procesar si está activo y tiene NextChargeDate
            if (!rc.Active || !rc.NextChargeDate.HasValue)
                continue;

            // Generar todos los cargos pendientes hasta la fecha actual
            while (rc.NextChargeDate.Value <= utcNow &&
                   rc.NextChargeDate.Value <= rc.EndDate!.Value)
            {
                try
                {
                    await _unitOfWork.ExecuteAsTransactionAsync(async () =>
                    {
                        // Verificar si ya existe un cargo para esta fecha
                        var existingInstanceQuery = _recurringChargeInstanceRepository.GetAllFull()
                            .Where(i => i.RecurringChargeId == rc.Id)
                            .Where(i => i.Transaction!.Date.Date == rc.NextChargeDate.Value.Date);

                        var existingInstance = await _recurringChargeInstanceRepository.FirstOrDefaultAsync(existingInstanceQuery);

                        // Si ya existe, solo actualizar NextChargeDate y continuar
                        if (existingInstance != null)
                        {
                            rc.NextChargeDate = rc.CalculateNextDate(rc.NextChargeDate.Value);
                            _recurringChargeRepository.Update(rc);
                            await _unitOfWork.SaveChangesAsync();
                            return;
                        }

                        // Crear el cargo según el tipo
                        if (rc.Type == TransactionType.Lease)
                        {
                            var leaseChargeResponse = await _createLeaseChargeCommandService.Handle(new CreateLeaseChargeCommand
                            {
                                OwnerId = rc.Property.OwnerId,
                                PropertyId = rc.PropertyId,
                                LeaseId = rc.LeaseId!.Value,
                                Amount = rc.Amount!.Value,
                                Description = $"{rc.LeaseChargeType!.Name} - Auto Generated",
                                Date = rc.NextChargeDate.Value,
                                DueDate = rc.NextChargeDate.Value,
                                TypeId = rc.LeaseChargeTypeId!
                            });

                            if (leaseChargeResponse.Success)
                            {
                                RecurringChargeInstance instance = new RecurringChargeInstance()
                                {
                                    RecurringChargeId = rc.Id,
                                    TransactionId = leaseChargeResponse.Result!.Id
                                };
                                await _recurringChargeInstanceRepository.AddAsync(instance);
                                _logger.LogInformation("Generated pending Lease charge for RecurringCharge {RecurringChargeId}, Date: {Date}",
                                    rc.Id, rc.NextChargeDate.Value);
                            }
                        }
                        else if (rc.Type == TransactionType.Expense)
                        {
                            var expenseChargeResponse = await _createExpenseChargeCommandService.Handle(new CreateExpenseChargeCommand
                            {
                                OwnerId = rc.Property.OwnerId,
                                PropertyId = rc.PropertyId,
                                Amount = rc.Amount!.Value,
                                Date = rc.NextChargeDate.Value,
                                DueDate = rc.NextChargeDate.Value,
                                ExpenseId = rc.ExpenseId!.Value
                            });

                            if (expenseChargeResponse.Success)
                            {
                                RecurringChargeInstance instance = new RecurringChargeInstance()
                                {
                                    RecurringChargeId = rc.Id,
                                    TransactionId = expenseChargeResponse.Result!.Id
                                };
                                await _recurringChargeInstanceRepository.AddAsync(instance);
                                _logger.LogInformation("Generated pending Expense charge for RecurringCharge {RecurringChargeId}, Date: {Date}",
                                    rc.Id, rc.NextChargeDate.Value);
                            }
                        }
                        else if (rc.Type == TransactionType.Maintenance)
                        {
                            var maintenanceChargeResponse = await _createMaintenanceChargeCommandService.Handle(new CreateMaintenanceChargeCommand
                            {
                                OwnerId = rc.Property.OwnerId,
                                PropertyId = rc.PropertyId,
                                Amount = rc.Amount!.Value,
                                Title = rc.MaintenanceType?.Description,
                                Description = $"{rc.Type} - Auto Generated",
                                Date = rc.NextChargeDate.Value,
                                DueDate = rc.NextChargeDate.Value,
                                TypeId = rc.MaintenanceTypeId!.Value
                            });

                            if (maintenanceChargeResponse.Success)
                            {
                                RecurringChargeInstance instance = new RecurringChargeInstance()
                                {
                                    RecurringChargeId = rc.Id,
                                    TransactionId = maintenanceChargeResponse.Result!.Id
                                };
                                await _recurringChargeInstanceRepository.AddAsync(instance);
                                _logger.LogInformation("Generated pending Maintenance charge for RecurringCharge {RecurringChargeId}, Date: {Date}",
                                    rc.Id, rc.NextChargeDate.Value);
                            }
                        }

                        // Calcular siguiente fecha
                        rc.NextChargeDate = rc.CalculateNextDate(rc.NextChargeDate.Value);
                        _recurringChargeRepository.Update(rc);

                        await _unitOfWork.SaveChangesAsync();
                    });
                }
                catch (Exception ex)
                {
                    // Log error pero continuar con el siguiente cargo
                    _logger.LogError(ex, "Error generating pending charge for RecurringCharge {RecurringChargeId}, Date: {Date}",
                        rc.Id, rc.NextChargeDate);
                    // No queremos que un error detenga toda la reconciliación
                    break;
                }
            }
        }
    }

    /// <summary>
    /// NIVEL 1: Procesa RecurringCharges con IsRecurrent=true
    /// Busca la instancia más antigua unpaid de cada RC y la reconcilia si hay match >= 90%
    /// </summary>
    private async Task ProcessLevel1_RecurrentCharges(
        IEnumerable<PlaidTransaction> pendingTransactions,
        IEnumerable<RecurringCharge> recurringChargesRecurrent,
        DateTime utcNow)
    {
        // Rastrea instancias ya asignadas en esta ejecución para evitar que dos PlaidTransactions
        // del mismo monto compitan por el mismo cargo (cada una debe ir a una propiedad distinta)
        var usedCandidateTransactionIds = new HashSet<int>();

        for (int passNumber = 1; passNumber <= MAX_RECONCILIATION_PASSES; passNumber++)
        {
            bool hasChanges = false;

            foreach (var plaidTx in pendingTransactions)
            {
                // Saltar las ya reconciliadas
                if (plaidTx.Status == PlaidTransactionStatus.AutoReconciled)
                    continue;

                // En la primera pasada, re-evaluar NoMatch por si ahora hay nuevos cargos
                if (plaidTx.Status == PlaidTransactionStatus.NoMatch && passNumber > 1)
                    continue;

                try
                {
                    await _unitOfWork.ExecuteAsTransactionAsync(async () =>
                    {
                        // Obtener candidatos de RecurringCharges con IsRecurrent=true
                        var candidates = new List<ChargeCandidate>();
                        foreach (var rc in recurringChargesRecurrent)
                        {
                            var oldestInstance = await GetOldestUnpaidInstanceForRecurringCharge(rc, utcNow);
                            if (oldestInstance != null)
                            {
                                candidates.Add(oldestInstance);
                            }
                        }

                        // Excluir candidatos ya asignados a otras PlaidTransactions en esta ejecución
                        var availableCandidates = candidates
                            .Where(c => !c.TransactionId.HasValue || !usedCandidateTransactionIds.Contains(c.TransactionId.Value))
                            .ToList();

                        // Calcular scores
                        var scoredCandidates = availableCandidates
                            .Select(candidate => new ScoredCandidate
                            {
                                Candidate = candidate,
                                Score = CalculateMatchScore(plaidTx, candidate, out var details),
                                Details = details
                            })
                            .Where(sc => sc.Score >= SCORE_THRESHOLD)
                            .OrderByDescending(sc => sc.Score)
                            .ThenBy(sc => sc.Candidate.ChargeDate)
                            .ToList();

                        // Con la reserva en memoria, si quedan candidatos con score >= 90% tomar el primero.
                        // Cuando múltiples propiedades tienen el mismo monto, cada PlaidTransaction
                        // toma el siguiente candidato disponible (las anteriores ya fueron reservadas).
                        var highConfidenceCandidates = scoredCandidates
                            .Where(sc => sc.Score >= AUTO_APPLY_THRESHOLD)
                            .ToList();

                        if (highConfidenceCandidates.Count >= 1)
                        {
                            var selectedCandidate = highConfidenceCandidates[0];

                            // Crear PlaidReconciliation
                            var reconciliation = CreatePlaidReconciliation(plaidTx, selectedCandidate);
                            reconciliation.Status = PlaidReconciliationStatus.AutoApplied;
                            await _plaidReconciliationRepository.AddAsync(reconciliation);

                            // Aplicar pago/cargo
                            await ApplyPayment(reconciliation);

                            // Marcar PlaidTransaction como AutoReconciled
                            plaidTx.Status = PlaidTransactionStatus.AutoReconciled;
                            _plaidRepository.Update(plaidTx);

                            // Reservar este candidato para que no sea usado por otras PlaidTransactions
                            if (selectedCandidate.Candidate.TransactionId.HasValue)
                                usedCandidateTransactionIds.Add(selectedCandidate.Candidate.TransactionId.Value);

                            hasChanges = true;
                        }
                    });
                }
                catch (Exception ex)
                {
                    plaidTx.Status = PlaidTransactionStatus.Error;
                    await _unitOfWork.SaveChangesAsync();
                }
            }

            // Si no hubo cambios, salir del loop de pasadas
            if (!hasChanges) break;
        }

    }

    /// <summary>
    /// NIVEL 2: Procesa RecurringCharges con IsRecurrent=false
    /// Crea candidatos virtuales usando el Date de cada PlaidTransaction y reconcilia si hay match >= 90%
    /// </summary>
    private async Task ProcessLevel2_NonRecurrentCharges(
        IEnumerable<PlaidTransaction> pendingTransactions,
        IEnumerable<RecurringCharge> recurringChargesNonRecurrent)
    {
        // Rastrea RecurringCharges ya asignados en esta ejecución (candidatos virtuales sin TransactionId)
        var usedCandidateRcIds = new HashSet<int>();

        for (int passNumber = 1; passNumber <= MAX_RECONCILIATION_PASSES; passNumber++)
        {
            bool hasChanges = false;

            foreach (var plaidTx in pendingTransactions)
            {
                // Saltar las ya reconciliadas
                if (plaidTx.Status == PlaidTransactionStatus.AutoReconciled)
                    continue;

                // En la primera pasada, re-evaluar NoMatch por si ahora hay nuevos cargos
                if (plaidTx.Status == PlaidTransactionStatus.NoMatch && passNumber > 1)
                    continue;

                try
                {
                    await _unitOfWork.ExecuteAsTransactionAsync(async () =>
                    {
                        // Obtener candidatos de RecurringCharges con IsRecurrent=false
                        // Para estos, creamos candidatos virtuales usando el Date de la PlaidTransaction
                        var candidates = new List<ChargeCandidate>();
                        foreach (var rc in recurringChargesNonRecurrent)
                        {
                            candidates.Add(new ChargeCandidate
                            {
                                RecurringChargeId = rc.Id,
                                TransactionId = null,  // Virtual
                                ChargeDate = plaidTx.Date,  // Usar Date de PlaidTransaction
                                Amount = rc.Amount,  // Puede ser null
                                Description = $"Virtual {rc.Type}",
                                PropertyId = rc.PropertyId,
                                LeaseId = rc.LeaseId,
                                MatchTags = rc.MatchTags ?? new List<string>(),
                                IsPending = true,
                                IsSpliteable=rc.Spliteable
                            });
                        }

                        // Excluir candidatos ya asignados a otras PlaidTransactions en esta ejecución
                        var availableCandidates = candidates
                            .Where(c => !c.RecurringChargeId.HasValue || !usedCandidateRcIds.Contains(c.RecurringChargeId.Value))
                            .ToList();

                        // Calcular scores
                        var scoredCandidates = availableCandidates
                            .Select(candidate => new ScoredCandidate
                            {
                                Candidate = candidate,
                                Score = CalculateMatchScore(plaidTx, candidate, out var details),
                                Details = details
                            })
                            .Where(sc => sc.Score >= SCORE_THRESHOLD)
                            .OrderByDescending(sc => sc.Score)
                            .ThenBy(sc => sc.Candidate.ChargeDate)
                            .ToList();

                        // Con la reserva en memoria, si quedan candidatos con score >= 90% tomar el primero.
                        var highConfidenceCandidates = scoredCandidates
                            .Where(sc => sc.Score >= AUTO_APPLY_THRESHOLD)
                            .ToList();

                        if (highConfidenceCandidates.Count >= 1)
                        {
                            var selectedCandidate = highConfidenceCandidates[0];

                            // Crear PlaidReconciliation
                            var reconciliation = CreatePlaidReconciliation(plaidTx, selectedCandidate);
                            reconciliation.Status = PlaidReconciliationStatus.AutoApplied;
                            await _plaidReconciliationRepository.AddAsync(reconciliation);

                            // Aplicar pago/cargo
                            await ApplyPayment(reconciliation);

                            // Marcar PlaidTransaction como AutoReconciled
                            plaidTx.Status = PlaidTransactionStatus.AutoReconciled;
                            _plaidRepository.Update(plaidTx);

                            // Reservar este RC para que no sea usado por otras PlaidTransactions
                            if (selectedCandidate.Candidate.RecurringChargeId.HasValue)
                                usedCandidateRcIds.Add(selectedCandidate.Candidate.RecurringChargeId.Value);

                            hasChanges = true;
                        }
                    });
                }
                catch (Exception ex)
                {
                    plaidTx.Status = PlaidTransactionStatus.Error;
                    await _unitOfWork.SaveChangesAsync();
                }
            }

            // Si no hubo cambios, salir del loop de pasadas
            if (!hasChanges) break;
        }

    }


    /// <summary>
    /// NIVEL 3: Procesa RecurringChargesSpliteables con IsRecurrent=false y Spliteable=true
    /// Crea candidatos virtuales usando el Date de cada PlaidTransaction y reconcilia si hay match >= 90%
    /// Si el cargo es spliteable, divide el monto entre todas las propiedades y crea reconciliaciones/pagos para cada una.
    /// </summary>
    private async Task ProcessLevel3_NonRecurrentChargesSpliteable(
        IEnumerable<PlaidTransaction> pendingTransactions,
        IEnumerable<RecurringCharge> recurringChargesNonRecurrentSplitable,
        HashSet<int> propertyIdSet)
    {
        // Rastrea RecurringCharges ya asignados en esta ejecución (candidatos virtuales sin TransactionId)
        var usedCandidateRcIds = new HashSet<int>();

        for (int passNumber = 1; passNumber <= MAX_RECONCILIATION_PASSES; passNumber++)
        {
            bool hasChanges = false;

            foreach (var plaidTx in pendingTransactions)
            {
                // Saltar las ya reconciliadas
                if (plaidTx.Status == PlaidTransactionStatus.AutoReconciled)
                    continue;

                // En la primera pasada, re-evaluar NoMatch por si ahora hay nuevos cargos
                if (plaidTx.Status == PlaidTransactionStatus.NoMatch && passNumber > 1)
                    continue;

                try
                {
                    await _unitOfWork.ExecuteAsTransactionAsync(async () =>
                    {
                        // Obtener candidatos de RecurringCharges con IsRecurrent=false
                        // Para estos, creamos candidatos virtuales usando el Date de la PlaidTransaction
                        var candidates = new List<ChargeCandidate>();
                        foreach (var rc in recurringChargesNonRecurrentSplitable)
                        {
                            candidates.Add(new ChargeCandidate
                            {
                                RecurringChargeId = rc.Id,
                                TransactionId = null,  // Virtual
                                ChargeDate = plaidTx.Date,  // Usar Date de PlaidTransaction
                                Amount = rc.Amount,  // Puede ser null
                                Description = $"Virtual {rc.Type}",
                                PropertyId = rc.PropertyId,
                                LeaseId = rc.LeaseId,
                                MatchTags = rc.MatchTags ?? new List<string>(),
                                IsPending = true,
                                IsSpliteable = rc.Spliteable
                            });
                        }

                        // Excluir candidatos ya asignados a otras PlaidTransactions en esta ejecución
                        var availableCandidates = candidates
                            .Where(c => !c.RecurringChargeId.HasValue || !usedCandidateRcIds.Contains(c.RecurringChargeId.Value))
                            .ToList();

                        // Calcular scores
                        var scoredCandidates = availableCandidates
                            .Select(candidate => new ScoredCandidate
                            {
                                Candidate = candidate,
                                Score = CalculateMatchScore(plaidTx, candidate, out var details),
                                Details = details
                            })
                            .Where(sc => sc.Score >= SCORE_THRESHOLD)
                            .OrderByDescending(sc => sc.Score)
                            .ThenBy(sc => sc.Candidate.ChargeDate)
                            .ToList();

                        // Con la reserva en memoria, si quedan candidatos con score >= 90% tomar el primero.
                        var highConfidenceCandidates = scoredCandidates
                            .Where(sc => sc.Score >= AUTO_APPLY_THRESHOLD)
                            .ToList();

                        if (highConfidenceCandidates.Count >= 1)
                        {
                            var selectedCandidate = highConfidenceCandidates[0];

                            if (selectedCandidate.Candidate.IsSpliteable)
                            {
                                // Dividir el monto entre todas las propiedades
                                int propertyCount = propertyIdSet.Count;
                                if (propertyCount == 0)
                                    return;
                                decimal splitAmount = plaidTx.Amount / propertyCount;
                                foreach (var propertyId in propertyIdSet)
                                {
                                    // Crear un candidato virtual para cada propiedad
                                    var splitCandidate = new ChargeCandidate
                                    {
                                        RecurringChargeId = selectedCandidate.Candidate.RecurringChargeId,
                                        TransactionId = null,
                                        ChargeDate = plaidTx.Date,
                                        Amount = splitAmount,
                                        Description = $"Virtual Split {selectedCandidate.Candidate.Description}",
                                        PropertyId = propertyId,
                                        LeaseId = selectedCandidate.Candidate.LeaseId,
                                        MatchTags = selectedCandidate.Candidate.MatchTags,
                                        IsPending = true,
                                        IsSpliteable = true
                                    };
                                    var splitScoredCandidate = new ScoredCandidate
                                    {
                                        Candidate = splitCandidate,
                                        Score = selectedCandidate.Score,
                                        Details = selectedCandidate.Details
                                    };
                                    var reconciliation = CreatePlaidReconciliation(plaidTx, splitScoredCandidate);
                                    reconciliation.Status = PlaidReconciliationStatus.AutoApplied;
                                    await _plaidReconciliationRepository.AddAsync(reconciliation);
                                    await ApplyPayment(reconciliation);
                                }
                                plaidTx.Status = PlaidTransactionStatus.AutoReconciled;
                                _plaidRepository.Update(plaidTx);

                                // Reservar este RC para que no sea usado por otras PlaidTransactions
                                if (selectedCandidate.Candidate.RecurringChargeId.HasValue)
                                    usedCandidateRcIds.Add(selectedCandidate.Candidate.RecurringChargeId.Value);

                                hasChanges = true;
                            }
                            else
                            {
                                // Comportamiento original para no spliteable
                                var reconciliation = CreatePlaidReconciliation(plaidTx, selectedCandidate);
                                reconciliation.Status = PlaidReconciliationStatus.AutoApplied;
                                await _plaidReconciliationRepository.AddAsync(reconciliation);
                                await ApplyPayment(reconciliation);
                                plaidTx.Status = PlaidTransactionStatus.AutoReconciled;
                                _plaidRepository.Update(plaidTx);

                                // Reservar este RC para que no sea usado por otras PlaidTransactions
                                if (selectedCandidate.Candidate.RecurringChargeId.HasValue)
                                    usedCandidateRcIds.Add(selectedCandidate.Candidate.RecurringChargeId.Value);

                                hasChanges = true;
                            }
                        }
                    });
                }
                catch (Exception ex)
                {
                    plaidTx.Status = PlaidTransactionStatus.Error;
                    await _unitOfWork.SaveChangesAsync();
                }
            }

            // Si no hubo cambios, salir del loop de pasadas
            if (!hasChanges) break;
        }

    }

    /// <summary>
    /// Pasada final: marca las transacciones pendientes como NeedReview con top 5 candidatos de TODOS los niveles
    /// Incluye transacciones sueltas que no pueden auto-reconciliarse (sin tags configurados)
    /// </summary>
    private async Task ProcessFinalPassNeedReview(
        IEnumerable<PlaidTransaction> pendingTransactions,
        IEnumerable<RecurringCharge> recurringChargesRecurrent,
        IEnumerable<RecurringCharge> recurringChargesNonRecurrent,
        int ownerId,
        DateTime utcNow)
    {
        var needReviewTransactionIds = new HashSet<int>();

        foreach (var plaidTx in pendingTransactions)
        {
            // Solo procesar las que NO fueron AutoReconciled
            if (plaidTx.Status == PlaidTransactionStatus.AutoReconciled)
            {
                continue;
            }

            try
            {
                await _unitOfWork.ExecuteAsTransactionAsync(async () =>
                {
                    // Obtener candidatos de TODOS los niveles para esta pasada final
                    var allCandidates = new List<ChargeCandidate>();

                    // Nivel 1: RecurringCharges con IsRecurrent=true
                    foreach (var rc in recurringChargesRecurrent)
                    {
                        var oldestInstance = await GetClosestUnpaidInstanceToDateAsync(rc, utcNow, plaidTx.Date);
                        if (oldestInstance != null)
                        {
                            allCandidates.Add(oldestInstance);
                        }
                    }

                    // Nivel 2: RecurringCharges con IsRecurrent=false (candidatos virtuales)
                    foreach (var rc in recurringChargesNonRecurrent)
                    {
                        allCandidates.Add(new ChargeCandidate
                        {
                            RecurringChargeId = rc.Id,
                            TransactionId = null,  // Virtual
                            ChargeDate = plaidTx.Date,  // Usar Date de PlaidTransaction
                            Amount = rc.Amount,  // Puede ser null
                            Description = $"Virtual {rc.Type}",
                            PropertyId = rc.PropertyId,
                            LeaseId = rc.LeaseId,
                            MatchTags = rc.MatchTags ?? new List<string>(),
                            IsPending = true,
                        });
                    }

                    // Nivel 3: Transacciones sueltas
                    var looseTransactions = await GetLooseTransactionCandidates(ownerId, utcNow);
                    allCandidates.AddRange(looseTransactions);

                    // Filtrar candidatos que ya fueron asignados a NeedReview en esta ejecución
                    var availableCandidates = allCandidates
                        .Where(c => !c.TransactionId.HasValue || !needReviewTransactionIds.Contains(c.TransactionId.Value))
                        .ToList();

                    // Calcular scores
                    var scoredCandidates = availableCandidates
                        .Select(candidate => new ScoredCandidate
                        {
                            Candidate = candidate,
                            Score = CalculateMatchScore(plaidTx, candidate, out var details),
                            Details = details
                        })
                        .Where(sc => sc.Score >= SCORE_THRESHOLD)
                        .OrderByDescending(sc => sc.Score)
                        .ThenBy(sc => sc.Candidate.ChargeDate)
                        .ToList();

                    if (scoredCandidates.Any())
                    {
                        // Tomar top 5 candidatos
                        var selectedCandidates = TakeTop5WithTies(scoredCandidates);

                        // Crear PlaidReconciliations en estado Pending
                        var reconciliations = new List<PlaidReconciliation>();
                        foreach (var scoredCandidate in selectedCandidates)
                        {
                            var reconciliation = CreatePlaidReconciliation(plaidTx, scoredCandidate);
                            reconciliation.Status = PlaidReconciliationStatus.Pending;
                            reconciliations.Add(reconciliation);
                        }

                        await _plaidReconciliationRepository.AddAsync(reconciliations);

                        // Agregar los candidatos seleccionados al filtro para que no se usen en siguientes PlaidTransactions
                        //foreach (var scoredCandidate in selectedCandidates)
                        //{
                        //    if (scoredCandidate.Candidate.TransactionId.HasValue)
                        //    {
                        //        needReviewTransactionIds.Add(scoredCandidate.Candidate.TransactionId.Value);
                        //    }
                        //}

                        // Marcar PlaidTransaction como NeedReview
                        plaidTx.Status = PlaidTransactionStatus.NeedReview;
                        _plaidRepository.Update(plaidTx);
                    }
                    else
                    {
                        // No hay candidatos válidos en ningún nivel
                        plaidTx.Status = PlaidTransactionStatus.NoMatch;
                        _plaidRepository.Update(plaidTx);
                    }
                });
            }
            catch (Exception ex)
            {
                plaidTx.Status = PlaidTransactionStatus.Error;
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }

    /// <summary>
    /// Obtiene la instancia más antigua no pagada de un RecurringCharge
    /// Solo retorna instancias REALES que ya existen en la BD (no virtuales)
    /// Solo incluye transacciones con Status = Unpaid y Date <= utcNow (no futuras)
    /// </summary>
    private async Task<ChargeCandidate?> GetOldestUnpaidInstanceForRecurringCharge(RecurringCharge recurringCharge, DateTime utcNow)
    {
        // Buscar instancias CREADAS no pagadas (ordenadas por fecha)
        // Ya no necesitamos generar candidatos virtuales porque GeneratePendingCharges
        // se ejecuta antes de la reconciliación y crea todos los cargos pendientes
        var createdInstanceQuery = _recurringChargeInstanceRepository.GetAllFull()
            .Where(i => i.RecurringChargeId == recurringCharge.Id)
            .Where(i => i.Transaction != null)
            .Where(i => i.Transaction!.Status == TransactionStatus.Unpaid)  // Solo Unpaid
            .Where(i => i.Transaction!.Date <= utcNow); // Solo cargos no futuros

        var createdInstance = await _recurringChargeInstanceRepository.FirstOrDefaultAsync(
            createdInstanceQuery.OrderBy(i => i.Transaction!.Date)
        );

        if (createdInstance != null)
        {
            return new ChargeCandidate
            {
                RecurringChargeId = recurringCharge.Id,
                TransactionId = createdInstance.TransactionId,
                ChargeDate = createdInstance.Transaction!.Date,
                Amount = createdInstance.Transaction.Amount,
                Description = createdInstance.Transaction.Description,
                PropertyId = createdInstance.Transaction.PropertyId,
                LeaseId = createdInstance.Transaction.LeaseId,
                MatchTags = recurringCharge.MatchTags ?? new List<string>(),
                IsPending = false,
            };
        }

        // No hay instancias disponibles para reconciliar
        return null;
    }

    private async Task<ChargeCandidate?> GetClosestUnpaidInstanceToDateAsync(RecurringCharge recurringCharge, DateTime utcNow, DateTime date)
    {
        var createdInstanceQuery = _recurringChargeInstanceRepository.GetAllFull()
            .Where(i => i.RecurringChargeId == recurringCharge.Id)
            .Where(i => i.Transaction != null)
            .Where(i => i.Transaction!.Status == TransactionStatus.Unpaid)  // Solo Unpaid
            .Where(i => i.Transaction!.Date <= utcNow); // Solo cargos no futuros

        var allCreatedInstances = await _recurringChargeInstanceRepository.ToListAsync(createdInstanceQuery);

        // Si 'allCreatedInstances' está vacía, 'FirstOrDefault' devolverá null.
        var createdInstance = allCreatedInstances
            .OrderBy(i => Math.Abs((i.Transaction!.Date - date).Ticks))
            .FirstOrDefault();

        if (createdInstance != null)
        {
            return new ChargeCandidate
            {
                RecurringChargeId = recurringCharge.Id,
                TransactionId = createdInstance.TransactionId,
                ChargeDate = createdInstance.Transaction!.Date,
                Amount = createdInstance.Transaction.Amount,
                Description = createdInstance.Transaction.Description,
                PropertyId = createdInstance.Transaction.PropertyId,
                LeaseId = createdInstance.Transaction.LeaseId,
                MatchTags = recurringCharge.MatchTags ?? new List<string>(),
                IsPending = false,
            };
        }

        // No hay instancias disponibles para reconciliar
        return null;
    }


    /// <summary>
    /// Obtiene transacciones sueltas (no asociadas a RecurringCharge) que estén sin pagar
    /// Solo incluye CARGOS (SubType = Charge) con Status = Unpaid y Date <= utcNow (no futuras)
    /// </summary>
    private async Task<List<ChargeCandidate>> GetLooseTransactionCandidates(int ownerId, DateTime utcNow)
    {
        var candidates = new List<ChargeCandidate>();

        // Buscar transacciones del owner que no estén en RecurringChargeInstance
        // Solo CARGOS (no pagos) y con estado Unpaid
        var looseTransactionsQuery = _transactionRepository.GetAllFull()
            .Where(t => t.Property.OwnerId == ownerId)
            .Where(t => t.SubType == TransactionSubType.Charge)  // Solo cargos
            .Where(t => t.Status == TransactionStatus.Unpaid)    // Solo unpaid
            .Where(t => t.Date <= utcNow)  // Solo cargos no futuros
            .Where(t => !_recurringChargeInstanceRepository.GetAll()
                .Any(rci => rci.TransactionId == t.Id));

        var looseTransactions = await _transactionRepository.ToListAsync(looseTransactionsQuery);

        foreach (var tx in looseTransactions)
        {
            candidates.Add(new ChargeCandidate
            {
                RecurringChargeId = null,
                TransactionId = tx.Id,
                ChargeDate = tx.Date,
                Amount = tx.Amount,
                Description = tx.Description,
                PropertyId = tx.PropertyId,
                LeaseId = tx.LeaseId,
                MatchTags = new List<string>(), // Transacciones sueltas no tienen tags
                IsPending = false,
            });
        }

        return candidates;
    }



    public async Task ApplyPayment(PlaidReconciliation reconciliation)
    {
        if (reconciliation.TransactionId.HasValue)
        {
            if (reconciliation.Transaction.Type == TransactionType.Lease)
            {
                var leasePaymentresponse = await _createLeasePaymentCommandService.Handle(new CreateLeasePaymentCommand
                {
                    PlaidId = reconciliation.PlaidTransactionId,
                    OwnerId = reconciliation.PlaidTransaction!.OwnerBankAccount!.OwnerId,
                    TransactionId = reconciliation.TransactionId,
                    Amount = Math.Abs(reconciliation.ActualAmount),
                });
                return;
            }

            if (reconciliation.Transaction.Type == TransactionType.Expense)
            {
                var expensePaymentResponse = await _createExpensePaymentCommandService.Handle(new CreateExpensePaymentCommand
                {
                    PlaidId = reconciliation.PlaidTransactionId,
                    OwnerId = reconciliation.PlaidTransaction!.OwnerBankAccount!.OwnerId,
                    TransactionId = reconciliation.TransactionId,
                    Amount = Math.Abs(reconciliation.ActualAmount),
                });


                return;
            }

            var maintenancePaymentResponse = await _createMaintenancePaymentCommandService.Handle(new CreateMaintenancePaymentCommand
            {
                PlaidId = reconciliation.PlaidTransactionId,
                OwnerId = reconciliation.PlaidTransaction!.OwnerBankAccount!.OwnerId,
                TransactionId = reconciliation.TransactionId,
                Amount = Math.Abs(reconciliation.ActualAmount),
            });

            return;


        }
        else if (reconciliation.RecurringChargeId.HasValue)
        {
            if (reconciliation.RecurringCharge.Type == TransactionType.Lease)
            {
                var leaseChargeResponse = await _createLeaseChargeCommandService.Handle(new CreateLeaseChargeCommand
                {
                    OwnerId = reconciliation.PlaidTransaction!.OwnerBankAccount!.OwnerId,
                    PropertyId = reconciliation.RecurringCharge.PropertyId,
                    LeaseId = reconciliation.RecurringCharge.LeaseId,
                    Amount = Math.Abs(reconciliation.ActualAmount),
                    Description = reconciliation.MatchedDescription,
                    Date = reconciliation.PlaidTransaction.Date,
                    DueDate = reconciliation.RecurringCharge.NextChargeDate ?? reconciliation.PlaidTransaction.Date,
                    TypeId = reconciliation.RecurringCharge.LeaseChargeTypeId,
                });

                var leasePaymentresponse = await _createLeasePaymentCommandService.Handle(new CreateLeasePaymentCommand
                {
                    PlaidId = reconciliation.PlaidTransactionId,
                    OwnerId = reconciliation.PlaidTransaction!.OwnerBankAccount!.OwnerId,
                    TransactionId = leaseChargeResponse.Result!.Id,
                    Amount = Math.Abs(reconciliation.ActualAmount),
                });

                RecurringChargeInstance leaseRcInstance = new RecurringChargeInstance()
                {
                    RecurringChargeId = reconciliation.RecurringCharge.Id,
                    TransactionId = leaseChargeResponse.Result!.Id
                };

                await _recurringChargeInstanceRepository.AddAsync(leaseRcInstance);

                // Solo calcular NextChargeDate si es recurrente (tiene schedule)
                if (reconciliation.RecurringCharge.IsRecurrent)
                {
                    reconciliation.RecurringCharge.NextChargeDate = reconciliation.RecurringCharge.CalculateNextDate(reconciliation.RecurringCharge.NextChargeDate!.Value);
                }
                _recurringChargeRepository.Update(reconciliation.RecurringCharge);

                reconciliation.TransactionId = leaseChargeResponse.Result!.Id;
                _plaidReconciliationRepository.Update(reconciliation);

                await _unitOfWork.SaveChangesAsync();

                return;
            }

            if (reconciliation.RecurringCharge.Type == TransactionType.Expense)
            {
                var expenseChargeResponse = await _createExpenseChargeCommandService.Handle(new CreateExpenseChargeCommand
                {
                    OwnerId = reconciliation.PlaidTransaction!.OwnerBankAccount!.OwnerId,
                    PropertyId = reconciliation.RecurringCharge.PropertyId,
                    Amount = Math.Abs(reconciliation.ActualAmount),
                    Date = reconciliation.PlaidTransaction.Date,
                    DueDate = reconciliation.RecurringCharge.NextChargeDate ?? reconciliation.PlaidTransaction.Date,
                    ExpenseId = reconciliation.RecurringCharge.ExpenseId,
                });

                var expensePaymentResponse = await _createExpensePaymentCommandService.Handle(new CreateExpensePaymentCommand
                {
                    PlaidId = reconciliation.PlaidTransactionId,
                    OwnerId = reconciliation.PlaidTransaction!.OwnerBankAccount!.OwnerId,
                    TransactionId = expenseChargeResponse.Result!.Id,
                    Amount = Math.Abs(reconciliation.ActualAmount),
                });

                RecurringChargeInstance expenseRcInstance = new RecurringChargeInstance()
                {
                    RecurringChargeId = reconciliation.RecurringCharge.Id,
                    TransactionId = expenseChargeResponse.Result!.Id
                };

                await _recurringChargeInstanceRepository.AddAsync(expenseRcInstance);

                // Solo calcular NextChargeDate si es recurrente (tiene schedule)
                if (reconciliation.RecurringCharge.IsRecurrent)
                {
                    reconciliation.RecurringCharge.NextChargeDate = reconciliation.RecurringCharge.CalculateNextDate(reconciliation.RecurringCharge.NextChargeDate!.Value);
                }
                _recurringChargeRepository.Update(reconciliation.RecurringCharge);

                reconciliation.TransactionId = expenseChargeResponse.Result!.Id;
                _plaidReconciliationRepository.Update(reconciliation);

                await _unitOfWork.SaveChangesAsync();
                return;
            }

            var maintenanceChargeResponse = await _createMaintenanceChargeCommandService.Handle(new CreateMaintenanceChargeCommand
            {
                OwnerId = reconciliation.PlaidTransaction!.OwnerBankAccount!.OwnerId,
                PropertyId = reconciliation.RecurringCharge.PropertyId,
                Amount = Math.Abs(reconciliation.ActualAmount),
                Title = reconciliation.RecurringCharge.MaintenanceType?.Description,
                Description = reconciliation.MatchedDescription,
                Date = reconciliation.PlaidTransaction.Date,
                DueDate = reconciliation.RecurringCharge.NextChargeDate ?? reconciliation.PlaidTransaction.Date,
                TypeId = reconciliation.RecurringCharge.MaintenanceTypeId,

            });

            var maintenancePaymentResponse = await _createMaintenancePaymentCommandService.Handle(new CreateMaintenancePaymentCommand
            {
                PlaidId = reconciliation.PlaidTransactionId,
                OwnerId = reconciliation.PlaidTransaction!.OwnerBankAccount!.OwnerId,
                TransactionId = maintenanceChargeResponse.Result!.Id,
                Amount = Math.Abs(reconciliation.ActualAmount),
            });

            RecurringChargeInstance maintenanceRcInstance = new RecurringChargeInstance()
            {
                RecurringChargeId = reconciliation.RecurringCharge.Id,
                TransactionId = maintenanceChargeResponse.Result!.Id
            };

            await _recurringChargeInstanceRepository.AddAsync(maintenanceRcInstance);

            // Solo calcular NextChargeDate si es recurrente (tiene schedule)
            if (reconciliation.RecurringCharge.IsRecurrent)
            {
                reconciliation.RecurringCharge.NextChargeDate = reconciliation.RecurringCharge.CalculateNextDate(reconciliation.RecurringCharge.NextChargeDate!.Value);
            }
            _recurringChargeRepository.Update(reconciliation.RecurringCharge);

            reconciliation.TransactionId = maintenanceChargeResponse.Result!.Id;
            _plaidReconciliationRepository.Update(reconciliation);

            await _unitOfWork.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Calcula el score de matching entre PlaidTransaction y Candidato
    /// Score = TagScore (0-100% si Amount=null, 0-50% si Amount!=null) + AmountScore (0-50%)
    /// </summary>
    private decimal CalculateMatchScore(PlaidTransaction plaidTx, ChargeCandidate candidate, out MatchDetails details)
    {
        details = new MatchDetails();

        // 1. Calcular score de Tags (máx 50%)
        var tags = candidate.MatchTags ?? new List<string>();
        if (tags.Count > 0)
        {
            var matchedTags = tags.Where(tag =>
                plaidTx.Description.Contains(tag, StringComparison.OrdinalIgnoreCase)).ToList();

            details.MatchedTags = matchedTags;
            details.UnmatchedTags = tags.Except(matchedTags).ToList();

            if (matchedTags.Count == tags.Count)
            {
                // Todos los tags coinciden
                details.TagScore = EXACT_TAG_SCORE;
            }
            else if (matchedTags.Count > 0)
            {
                // Coincidencia parcial
                details.TagScore = (matchedTags.Count / (decimal)tags.Count) * EXACT_TAG_SCORE;
            }
        }

        // 2. Calcular score de Amount (máx 50%, solo si candidate tiene Amount)
        if (candidate.Amount.HasValue)
        {
            var expectedAmount = Math.Abs(candidate.Amount.Value);
            var actualAmount = Math.Abs(plaidTx.Amount);

            details.AmountDifference = Math.Abs(expectedAmount - actualAmount);
            details.AmountDifferencePercent = expectedAmount > 0
                ? (details.AmountDifference / expectedAmount) * 100
                : 0;

            if (details.AmountDifference == 0)
            {
                // Monto exacto
                details.AmountScore = EXACT_AMOUNT_SCORE;
                details.AmountWithinThreshold = true;
            }
            else if (details.AmountDifferencePercent <= AMOUNT_TOLERANCE_PERCENT)
            {
                // Dentro del umbral de tolerancia (10%)
                details.AmountWithinThreshold = true;
                details.AmountPenalty = (details.AmountDifferencePercent / AMOUNT_TOLERANCE_PERCENT) * 10m;
                details.AmountScore = EXACT_AMOUNT_SCORE - details.AmountPenalty;
            }
            else
            {
                // Fuera del umbral → AmountScore = 0
                details.AmountWithinThreshold = false;
                details.AmountScore = 0m;
                details.AmountPenalty = EXACT_AMOUNT_SCORE;
            }

            // Matching tradicional: TagScore + AmountScore (0-100%)
            return details.TagScore + details.AmountScore;
        }
        else
        {
            // Sin Amount configurado → Matching puro por tags
            // Duplicar TagScore para que vaya de 0-100%
            // Si no matchea ningún tag → 0% (no pasa threshold de 50%)
            // Si matchea todos los tags → 100% (auto-reconcilia)
            details.AmountScore = 0m;
            details.AmountWithinThreshold = false;

            return details.TagScore * 2;
        }
    }

    /// <summary>
    /// Crea un PlaidReconciliation con toda la información de auditoría
    /// </summary>
    private PlaidReconciliation CreatePlaidReconciliation(PlaidTransaction plaidTx, ScoredCandidate scoredCandidate)
    {
        var candidate = scoredCandidate.Candidate;
        var details = scoredCandidate.Details;

        return new PlaidReconciliation
        {
            PlaidTransactionId = plaidTx.Id,
            RecurringChargeId = candidate.RecurringChargeId,
            TransactionId = candidate.TransactionId,
            MatchPercentage = scoredCandidate.Score,
            TagMatchScore = details.TagScore,
            AmountMatchScore = details.AmountScore,
            // Si candidate no tiene Amount (IsRecurrent=false sin Amount), usar ActualAmount
            ExpectedAmount = candidate.Amount ?? plaidTx.Amount,
            ActualAmount = plaidTx.Amount,
            AmountDifference = details.AmountDifference,
            AmountDifferencePercent = details.AmountDifferencePercent,
            AmountThreshold = AMOUNT_TOLERANCE_PERCENT,
            AmountPenalty = details.AmountPenalty,
            AmountWithinThreshold = details.AmountWithinThreshold,
            ConfiguredTags = JsonConvert.SerializeObject(candidate.MatchTags ?? new List<string>()),
            MatchedTagsList = JsonConvert.SerializeObject(details.MatchedTags),
            UnmatchedTagsList = JsonConvert.SerializeObject(details.UnmatchedTags),
            PlaidDescription = plaidTx.Description,
            HasExactAmountMatch = details.AmountScore == EXACT_AMOUNT_SCORE,
            HasExactTagMatch = details.TagScore == EXACT_TAG_SCORE, // TagScore siempre es 0-50%, se duplica en el return
            TagsMatched = details.MatchedTags.Count,
            TotalTags = candidate.MatchTags?.Count ?? 0,
            MatchReason = GetMatchReason(details),
            MatchedDescription = candidate.Description,
            // Si candidate no tiene Amount, usar ActualAmount
            MatchedAmount = candidate.Amount ?? plaidTx.Amount,
            MatchedDate = candidate.ChargeDate,
            RecurringChargeName = candidate.RecurringChargeId.HasValue
                ? $"RC-{candidate.RecurringChargeId}"
                : $"TX-{candidate.TransactionId}"
        };
    }

    /// <summary>
    /// Genera descripción del match para UI
    /// </summary>
    private static string GetMatchReason(MatchDetails details)
    {
        var reasons = new List<string>();

        if (details.TagScore == EXACT_TAG_SCORE)
            reasons.Add("Exact tags");
        else if (details.TagScore > 0)
            reasons.Add($"Partial tags ({details.MatchedTags.Count}/{details.MatchedTags.Count + details.UnmatchedTags.Count})");

        if (details.AmountScore == EXACT_AMOUNT_SCORE)
            reasons.Add("exact amount");
        else if (details.AmountWithinThreshold)
            reasons.Add($"similar amount ({details.AmountDifferencePercent:F1}% diff)");

        return string.Join(" + ", reasons);
    }

    /// <summary>
    /// Toma los Top 5 elementos con empates en el score
    /// </summary>
    private static List<ScoredCandidate> TakeTop5WithTies(List<ScoredCandidate> items)
    {
        if (items.Count <= TOP_CANDIDATES_COUNT)
            return items;

        var top5 = items.Take(TOP_CANDIDATES_COUNT).ToList();
        var fifthScore = top5.Last().Score;

        // Agregar empates (mismas que la posición 5)
        var ties = items.Skip(TOP_CANDIDATES_COUNT)
            .Where(item => item.Score == fifthScore)
            .ToList();

        top5.AddRange(ties);

        return top5;
    }

    // ========== CLASES AUXILIARES ==========

    private class ChargeCandidate
    {
        public int? RecurringChargeId { get; set; }
        public int? TransactionId { get; set; }
        public DateTime ChargeDate { get; set; }
        public decimal? Amount { get; set; }  // Nullable para RC con IsRecurrent=false sin Amount
        public string Description { get; set; } = string.Empty;
        public int PropertyId { get; set; }
        public int? LeaseId { get; set; }
        public List<string>? MatchTags { get; set; }
        public bool IsPending { get; set; }  // Si es instancia pendiente vs creada
        public bool IsSpliteable { get; set; } = false;
    }

    private class ScoredCandidate
    {
        public ChargeCandidate Candidate { get; set; } = null!;
        public decimal Score { get; set; }
        public MatchDetails Details { get; set; } = null!;
    }

    private class MatchDetails
    {
        public decimal TagScore { get; set; }
        public decimal AmountScore { get; set; }
        public List<string> MatchedTags { get; set; } = new();
        public List<string> UnmatchedTags { get; set; } = new();
        public decimal AmountDifference { get; set; }
        public decimal AmountDifferencePercent { get; set; }
        public decimal AmountPenalty { get; set; }
        public bool AmountWithinThreshold { get; set; }
    }

}
