using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Enum;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.RecurringCharges.UpdateRExpenseCharges;

public class UpdateRExpenseChargeCommandHandler : ICommandHandler<UpdateRExpenseChargeCommand, UpdateRExpenseChargeCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRecurringChargeRepository _recurringChargeRepository;
    private readonly IRecurringChargeInstanceRepository _rcInstanceRepository;
    private readonly IExpenseRepository _expenseRepository;

    public UpdateRExpenseChargeCommandHandler(IUnitOfWork unitOfWork,
        IRecurringChargeRepository recurringChargeRepository,
        IRecurringChargeInstanceRepository rcInstanceRepository,
        IExpenseRepository expenseRepository)
    {
        _unitOfWork = unitOfWork;
        _recurringChargeRepository = recurringChargeRepository;
        _rcInstanceRepository = rcInstanceRepository;
        _expenseRepository = expenseRepository;
    }

    public async Task<OperationResult<UpdateRExpenseChargeCommandResponse>> Handle(UpdateRExpenseChargeCommand command)
    {
        // 1. Obtener el RecurringCharge existente con Property y historial de instancias
        var existingChargeQuery = _recurringChargeRepository.GetAllFull().Where(rc => rc.Id == command.Id!.Value);
        var existingCharge = await _recurringChargeRepository.FirstOrDefaultAsync(existingChargeQuery);

        if (existingCharge == null)
            return OperationResult<UpdateRExpenseChargeCommandResponse>.ErrorResult(
                new ErrorDetails(404, $"RecurringCharge with id {command.Id} not found"));

        // 2. Validar ownership (si se proporciona OwnerId)
        if (command.OwnerId.HasValue && existingCharge.Property?.OwnerId != command.OwnerId.Value)
            return OperationResult<UpdateRExpenseChargeCommandResponse>.ErrorResult(
                new ErrorDetails(403, "Access denied to this RecurringCharge"));

        // 3. Validar ExpenseId
        if (!await _expenseRepository.AnyAsync(lct => lct.Id == command.ExpenseId))
            return OperationResult<UpdateRExpenseChargeCommandResponse>.ErrorResult(
                new ErrorDetails(404, $"Expense with id {command.ExpenseId} not found"));

        var rcInstanceQuery = _rcInstanceRepository.GetAll().Where(rci => rci.RecurringChargeId == existingCharge.Id);
        var processedInstances = await _rcInstanceRepository.ToListAsync(rcInstanceQuery);

        // 4. Validar reglas de negocio
        var validationResult = ValidateBusinessRules(existingCharge, command, processedInstances);
        if (!validationResult.Success)
            return validationResult;

        // 5. Determinar si NextDate necesita recalcularse
        bool needsNextDateRecalculation = DetermineIfNeedsRecalculation(existingCharge, command);

        // 6. Guardar valores originales para generar mensaje
        var originalNextDate = existingCharge.NextChargeDate;
        var originalActive = existingCharge.Active;

        // 7. Actualizar campos del RecurringCharge
        UpdateChargeFields(existingCharge, command);

        // 8. Recalcular NextDate si es necesario
        if (needsNextDateRecalculation)
        {
            RecalculateNextChargeDate(existingCharge, processedInstances);
        }

        // 10. Guardar cambios
        await _unitOfWork.SaveChangesAsync();

        // 11. Preparar respuesta con mensaje descriptivo
        var response = new UpdateRExpenseChargeCommandResponse
        {
            Id = existingCharge.Id,
        };

        return OperationResult<UpdateRExpenseChargeCommandResponse>.SuccessResult(response);
    }

    private OperationResult<UpdateRExpenseChargeCommandResponse> ValidateBusinessRules(
        RecurringCharge existingCharge, UpdateRExpenseChargeCommand command, IEnumerable<RecurringChargeInstance> processedInstances)
    {
        // Validaciones específicas para cargos recurrentes
        if (command.IsRecurrent == true)
        {
            // Validar que los campos requeridos estén presentes
            if (!command.Amount.HasValue)
                return OperationResult<UpdateRExpenseChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "Amount is required for recurrent charges"));

            if (!command.Frequency.HasValue)
                return OperationResult<UpdateRExpenseChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "Frequency is required for recurrent charges"));

            if (!command.StartDate.HasValue)
                return OperationResult<UpdateRExpenseChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "StartDate is required for recurrent charges"));

            if (!command.EndDate.HasValue)
                return OperationResult<UpdateRExpenseChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "EndDate is required for recurrent charges"));

            // Validar que StartDate < EndDate
            if (command.StartDate >= command.EndDate)
                return OperationResult<UpdateRExpenseChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "StartDate must be before EndDate"));

            // Validar cambio de StartDate si hay instancias procesadas
            var hasProcessedInstances = processedInstances.Any();

            if (hasProcessedInstances && command.Frequency != existingCharge.Frequency)
            {
                return OperationResult<UpdateRExpenseChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "Cannot change Frequency when there are processed instances"));
            }

            if (hasProcessedInstances && command.StartDate != existingCharge.StartDate)
            {
                return OperationResult<UpdateRExpenseChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "Cannot change StartDate when there are processed instances"));
            }

            // Para EndDate, validamos que no sea anterior a la fecha que correspondería a la última instancia
            if (hasProcessedInstances)
            {
                var executionCount = processedInstances.Count();
                var lastExpectedDate = CalculateExpectedDateForExecution(existingCharge.StartDate!.Value, existingCharge.Frequency!.Value, executionCount - 1);

                if (command.EndDate < lastExpectedDate)
                {
                    return OperationResult<UpdateRExpenseChargeCommandResponse>.ErrorResult(
                        new ErrorDetails(400, $"EndDate cannot be before the last expected execution date ({lastExpectedDate:yyyy-MM-dd})"));
                }
            }
        }
        else
        {
            // Validaciones para cargos NO recurrentes (solo matching)
            if (command.MatchTags == null || !command.MatchTags.Any())
                return OperationResult<UpdateRExpenseChargeCommandResponse>.ErrorResult(
                    new ErrorDetails(400, "At least one MatchTag is required for non-recurrent charges"));
        }

        return OperationResult<UpdateRExpenseChargeCommandResponse>.SuccessResult(new());
    }

    private bool DetermineIfNeedsRecalculation(RecurringCharge existingCharge,
        UpdateRExpenseChargeCommand command)
    {
        // Solo recalcular si es recurrente
        if (command.IsRecurrent != true)
            return false;

        return existingCharge.Frequency != command.Frequency ||
               existingCharge.StartDate != command.StartDate ||
               existingCharge.EndDate != command.EndDate ||
               existingCharge.Active != command.Active;
    }

    private void UpdateChargeFields(RecurringCharge existingCharge,
        UpdateRExpenseChargeCommand command)
    {
        existingCharge.IsRecurrent = command.IsRecurrent!.Value;
        existingCharge.Frequency = command.Frequency;
        existingCharge.StartDate = command.StartDate;
        existingCharge.EndDate = command.EndDate;
        existingCharge.Amount = command.Amount;
        existingCharge.ExpenseId = command.ExpenseId!.Value;
        existingCharge.Active = command.Active!.Value;
        existingCharge.MatchTags = command.MatchTags;
    }

    private void RecalculateNextChargeDate(RecurringCharge recurringCharge,
        IEnumerable<RecurringChargeInstance> processedInstances)
    {
        if (!recurringCharge.Active || !recurringCharge.IsRecurrent)
        {
            recurringCharge.NextChargeDate = null;
            return;
        }

        if (!recurringCharge.StartDate.HasValue || !recurringCharge.EndDate.HasValue || !recurringCharge.Frequency.HasValue)
        {
            recurringCharge.NextChargeDate = null;
            return;
        }

        // Calcular la próxima fecha basada en StartDate + (executionCount * frequency)
        var candidateNextChargeDate = CalculateExpectedDateForExecution(
            recurringCharge.StartDate.Value,
            recurringCharge.Frequency.Value,
            processedInstances.Count());

        // Verificar que la fecha candidata esté dentro del rango válido
        if (candidateNextChargeDate <= recurringCharge.EndDate.Value)
        {
            recurringCharge.NextChargeDate = candidateNextChargeDate;
        }
        else
        {
            recurringCharge.NextChargeDate = null; // Ya no hay más fechas por generar
        }
    }

    private DateTime CalculateExpectedDateForExecution(DateTime startDate, FrequencyType frequency, int executionIndex)
    {
        var currentDate = startDate;

        for (int i = 0; i < executionIndex; i++)
        {
            currentDate = frequency switch
            {
                FrequencyType.Daily => currentDate.AddDays(1),
                FrequencyType.Weekly => currentDate.AddDays(7),
                FrequencyType.Monthly => currentDate.AddMonths(1),
                FrequencyType.Annual => currentDate.AddYears(1),
                _ => throw new ArgumentException($"Frequency type {frequency} not supported")
            };
        }

        return currentDate;
    }
}
