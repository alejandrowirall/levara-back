using Levara.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Levara.Domain.Models
{
    public class RecurringCharge : Entity
    {
        [Required]
        public TransactionType Type { get; set; }

        // Indica si el cargo se repite o es solo para matching
        [Required]
        public bool IsRecurrent { get; set; }

        // Campos opcionales (requeridos solo si IsRecurrent = true)
        [Range(0, double.MaxValue)]
        public decimal? Amount { get; set; }

        public FrequencyType? Frequency { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool Active { get; set; } = true;

        public bool Spliteable { get; set; } = false;

        // NUEVO: Próxima fecha a generar (solo para IsRecurrent = true)
        public DateTime? NextChargeDate { get; set; }

        // Relaciones opcionales según el tipo
        public int? LeaseId { get; set; }
        public Lease? Lease { get; set; }

        public int PropertyId { get; set; }
        public Property Property { get; set; }

        public int? ExpenseId { get; set; }
        public Expense? Expense { get; set; }

        public int? MaintenanceTypeId { get; set; }
        public MaintenanceType? MaintenanceType { get; set; }

        public int? LeaseChargeTypeId { get; set; }
        public LeaseChargeType? LeaseChargeType { get; set; }

        public List<string>? MatchTags { get; set; } = new List<string>();

        public string GetChargeDescription()
        {
            return Type switch
            {
                TransactionType.Lease => LeaseChargeType != null ? LeaseChargeType.Name : string.Empty,
                TransactionType.Maintenance => MaintenanceType != null ? MaintenanceType.Name : string.Empty,
                TransactionType.Expense => Expense != null ? Expense.Description : string.Empty,
                _ => string.Empty
            };
        }

        // Validación por tipo
        public void ValidateForType()
        {
            // Validaciones por tipo de transacción
            switch (Type)
            {
                case TransactionType.Lease when !LeaseId.HasValue:
                    throw new ValidationException("LeaseId is required for Lease recurring charges");
                case TransactionType.Maintenance when !MaintenanceTypeId.HasValue:
                    throw new ValidationException("MaintenanceTypeId is required for Maintenance recurring charges");
                case TransactionType.Expense when !ExpenseId.HasValue:
                    throw new ValidationException("ExpenseId is required for Expense recurring charges");
            }

            // Validaciones según IsRecurrent
            if (IsRecurrent)
            {
                // Si es recurrente, requiere: Amount, Frequency, StartDate, EndDate
                if (!Amount.HasValue)
                    throw new ValidationException("Amount is required for recurrent charges");

                if (!Frequency.HasValue)
                    throw new ValidationException("Frequency is required for recurrent charges");

                if (!StartDate.HasValue)
                    throw new ValidationException("StartDate is required for recurrent charges");

                if (!EndDate.HasValue)
                    throw new ValidationException("EndDate is required for recurrent charges");

                if (StartDate >= EndDate)
                    throw new ValidationException("StartDate must be before EndDate");
            }
            else
            {
                // Si NO es recurrente, requiere al menos 1 MatchTag
                if (MatchTags == null || !MatchTags.Any())
                    throw new ValidationException("At least one MatchTag is required for non-recurrent charges");
            }
        }

        // NUEVO: Calcular próxima fecha basada en frecuencia (solo para IsRecurrent = true)
        public DateTime CalculateNextDate(DateTime fromDate)
        {
            if (!IsRecurrent || !Frequency.HasValue)
                throw new InvalidOperationException("CalculateNextDate can only be called for recurrent charges with a frequency");

            return Frequency.Value switch
            {
                FrequencyType.Daily => fromDate.AddDays(1),
                FrequencyType.Weekly => fromDate.AddDays(7),
                FrequencyType.Monthly => fromDate.AddMonths(1),
                FrequencyType.Annual => fromDate.AddYears(1),
                _ => throw new ArgumentException($"Frequency type {Frequency} not supported")
            };
        }

        // NUEVO: Inicializar NextDate (solo para IsRecurrent = true)
        public void InitializeNextDate()
        {
            if (!IsRecurrent || !StartDate.HasValue)
                return;

            NextChargeDate = CalculateNextDate(StartDate.Value);
        }

        // NUEVO: Recalcular NextDate basado en última instancia procesada (solo para IsRecurrent = true)
        public void RecalculateNextDate(DateTime? lastProcessedDate = null)
        {
            if (!IsRecurrent)
                return;

            if (!Active)
            {
                NextChargeDate = null;
                return;
            }

            if (!StartDate.HasValue || !EndDate.HasValue)
                return;

            DateTime baseDate;

            if (lastProcessedDate.HasValue)
            {
                // Calcular desde la última instancia procesada
                baseDate = CalculateNextDate(lastProcessedDate.Value);
            }
            else
            {
                // No hay instancias procesadas, usar StartDate
                baseDate = CalculateNextDate(StartDate.Value);
            }

            // Verificar que la próxima fecha esté dentro del rango
            if (baseDate <= CalculateNextDate(EndDate.Value))
            {
                NextChargeDate = baseDate;
            }
            else
            {
                NextChargeDate = null; // Ya no hay más fechas por generar
            }
        }

        public static RecurringCharge CreateForLease(
            int propertyId,
            int leaseChargeTypeId,
            int leaseId,
            bool isRecurrent,
            decimal? amount,
            FrequencyType? frequency,
            DateTime? startDate,
            DateTime? endDate,
            bool active,
            List<string>? matchTags = null)
        {
            var recurringCharge = new RecurringCharge
            {
                Type = TransactionType.Lease,
                IsRecurrent = isRecurrent,
                Amount = amount,
                Frequency = frequency,
                StartDate = startDate,
                EndDate = endDate,
                PropertyId = propertyId,
                LeaseId = leaseId,
                LeaseChargeTypeId = leaseChargeTypeId,
                Active = active,
                MatchTags = matchTags
            };

            recurringCharge.ValidateForType();

            if (isRecurrent)
            {
                recurringCharge.InitializeNextDate();
            }

            return recurringCharge;
        }

        public static RecurringCharge CreateForMaintenance(
            int propertyId,
            int maintenanceTypeId,
            bool isRecurrent,
            decimal? amount,
            FrequencyType? frequency,
            DateTime? startDate,
            DateTime? endDate,
            bool active,
            bool spliteable,
            List<string>? matchTags = null)
        {
            var recurringCharge = new RecurringCharge
            {
                Type = TransactionType.Maintenance,
                IsRecurrent = isRecurrent,
                Amount = amount,
                Frequency = frequency,
                StartDate = startDate,
                EndDate = endDate,
                PropertyId = propertyId,
                MaintenanceTypeId = maintenanceTypeId,
                Active = active,
                Spliteable = spliteable,
                MatchTags = matchTags
            };

            recurringCharge.ValidateForType();

            if (isRecurrent)
            {
                recurringCharge.InitializeNextDate();
            }

            return recurringCharge;
        }

        public static RecurringCharge CreateForExpense(
            int propertyId,
            int expenseId,
            bool isRecurrent,
            decimal? amount,
            FrequencyType? frequency,
            DateTime? startDate,
            DateTime? endDate,
            bool active,
            List<string>? matchTags = null, 
            bool spliteable=false)
        {
            var recurringCharge = new RecurringCharge
            {
                Type = TransactionType.Expense,
                IsRecurrent = isRecurrent,
                Amount = amount,
                Frequency = frequency,
                StartDate = startDate,
                EndDate = endDate,
                PropertyId = propertyId,
                ExpenseId = expenseId,
                Active = active,
                MatchTags = matchTags,
                Spliteable= spliteable
            };

            recurringCharge.ValidateForType();

            if (isRecurrent)
            {
                recurringCharge.InitializeNextDate();
            }

            return recurringCharge;
        }
    }


}
