
using Levara.Domain.Enum;

namespace Levara.Domain.Models;

public class PlaidReconciliation : Entity
{
    public int? TransactionId { get; set; }
    public Transaction? Transaction { get; set; }
    public int PlaidTransactionId { get; set; }
    public PlaidTransaction PlaidTransaction { get; set; }

    public int? RecurringChargeId { get; set; }
    public RecurringCharge? RecurringCharge { get; set; }

    // Estado de la reconciliación
    public PlaidReconciliationStatus Status { get; set; }

    // Score total de matching (0-100%)
    public decimal MatchPercentage { get; set; }

    // Desglose del score para UI (porcentajes)
    public decimal TagMatchScore { get; set; }        // Score por coincidencia de tags (0-50%)
    public decimal AmountMatchScore { get; set; }     // Score por coincidencia de monto (0-50%)
    public decimal DateMatchScore { get; set; }       // Score por coincidencia de fecha (para sistema antiguo)

    // === DETALLES DE AUDITORÍA - MONTO ===
    public decimal ExpectedAmount { get; set; }       // Monto esperado del RecurringCharge
    public decimal ActualAmount { get; set; }         // Monto real de la transacción Plaid
    public decimal AmountDifference { get; set; }     // Diferencia absoluta en monto
    public decimal AmountDifferencePercent { get; set; } // Diferencia en porcentaje
    public decimal AmountThreshold { get; set; }      // Umbral usado para monto (ej: 10%)
    public decimal AmountPenalty { get; set; }        // Penalización aplicada al monto
    public bool AmountWithinThreshold { get; set; }   // Si está dentro del umbral

    // === DETALLES DE AUDITORÍA - TAGS ===
    public string? ConfiguredTags { get; set; }       // Tags configurados (JSON array string)
    public string? MatchedTagsList { get; set; }      // Tags que coincidieron (JSON array string)
    public string? UnmatchedTagsList { get; set; }    // Tags que NO coincidieron (JSON array string)
    public string? PlaidDescription { get; set; }     // Descripción de Plaid evaluada

    // Flags de matching exacto
    public bool HasExactAmountMatch { get; set; }
    public bool HasExactTagMatch { get; set; }

    // Información para UI
    public string? MatchReason { get; set; }          // "Exact tags + amount", "Partial tags only"
    public int TagsMatched { get; set; }              // Número de tags que coincidieron
    public int TotalTags { get; set; }                // Total de tags configurados

    // Contexto del match para mostrar en UI
    public string? MatchedDescription { get; set; }   // Descripción de lo que se matcheó
    public decimal MatchedAmount { get; set; }        // Monto de lo que se matcheó
    public DateTime? MatchedDate { get; set; }        // Fecha de lo que se matcheó
    public string? PropertyName { get; set; }         // Nombre de la propiedad
    public string? TenantName { get; set; }           // Nombre del tenant (si aplica)
    public string? RecurringChargeName { get; set; }  // Nombre del cargo recurrente

    // Auditoría de aplicación
    public DateTime? AppliedAt { get; set; }
    public int? AppliedByUserId { get; set; }  // Null si auto-aplicado
}
