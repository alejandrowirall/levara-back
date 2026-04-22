# Reconciliation Scoring Algorithm

Motor de puntuación para emparejar transacciones Plaid con cargos registrados en Levara.
Implementado en `ReconciliationScoreCalculator` (`Levara.Application/Plaid/ReconcileTransaction/ReconciliationScoreCalculator.cs`).

---

## Constantes

| Constante | Valor | Descripción |
|-----------|-------|-------------|
| `EXACT_AMOUNT_SCORE` | 70 | Puntuación máxima por monto |
| `EXACT_TAG_SCORE` | 30 | Puntuación máxima por tags |
| `AMOUNT_TOLERANCE_PERCENT` | 10 % | Umbral de tolerancia de diferencia de monto |
| `SCORE_THRESHOLD` | 50 | Mínimo para que un candidato sea considerado |
| `AUTO_APPLY_THRESHOLD` | 90 | Mínimo para auto-reconciliar sin revisión humana |

---

## Reglas de decisión

```
score >= AUTO_APPLY_THRESHOLD (90)  →  AutoReconcile   (se aplica automáticamente)
score >= SCORE_THRESHOLD (50)       →  NeedReview      (requiere revisión manual)
score <  SCORE_THRESHOLD (50)       →  NoCandidate     (descartado)
```

---

## Flujo del método `CalculateMatchScore`

```
CalculateMatchScore(plaidTx, candidate)
│
├─ [STEP 1] TagScore (0–30)
│    ├─ candidate.MatchTags == null/empty  → TagScore = 0
│    ├─ ALL tags found in description      → TagScore = 30
│    └─ PARTIAL tags found                 → TagScore = (matched/total) × 30
│
└─ [STEP 2] AmountScore (0–70) — depende de candidate.Amount
     │
     ├─ candidate.Amount == null  (sin monto configurado)
     │    AmountScore = 0
     │    normalizedScore = TagScore × (100/30)
     │    ├─ MatchedTags > 0  → return max(90, normalizedScore)  [AutoReconcile guaranteed]
     │    └─ MatchedTags = 0  → return normalizedScore            [= 0 if no tags]
     │
     └─ candidate.Amount != null  (monto configurado)
          diff = |expected - actual|
          diffPct = diff / expected × 100
          │
          ├─ diff == 0  (monto exacto)
          │    AmountScore = 70, AmountWithinThreshold = true
          │    ├─ No tags configured  → return max(90, 70) = 90   [early return]
          │    └─ Tags configured     → fall-through to TagScore + AmountScore
          │
          ├─ diffPct <= 10 %  (dentro del umbral)
          │    penalty = (diffPct / 10) × 10
          │    AmountScore = 70 - penalty
          │    return TagScore + AmountScore
          │
          └─ diffPct > 10 %  (fuera del umbral)
               AmountScore = 0
               return TagScore + 0
```

---

## Tabla de impacto — 10 escenarios

| ID | Escenario | TagScore | AmountScore | Score | Resultado |
|----|-----------|----------|-------------|-------|-----------|
| T01 | Monto exacto, sin tags configurados | 0 | 70 | **90** | AutoReconcile |
| T02 | Monto exacto, todos los tags coinciden | 30 | 70 | **100** | AutoReconcile |
| T03 | Monto exacto, tags parciales (1 de 2) | 15 | 70 | **85** | NeedReview |
| T04 | Monto exacto, tags configurados sin match | 0 | 70 | **70** | NeedReview |
| T05 | Todos los tags, sin monto configurado | 30 | 0 | **100** | AutoReconcile |
| T06 | 1 de 2 tags, sin monto configurado | 15 | 0 | **90** | AutoReconcile |
| T07 | Monto +5 %, todos los tags | 30 | 65 | **95** | AutoReconcile |
| T08 | Monto +10 % (límite umbral), sin tags | 0 | 60 | **60** | NeedReview |
| T09 | Monto +15 % (fuera umbral), todos los tags | 30 | 0 | **30** | NoCandidate |
| T10 | Sin tags, sin monto configurado | 0 | 0 | **0** | NoCandidate |

> **Nota T01**: El retorno anticipado garantiza score = max(90, 70) = 90 cuando no hay tags configurados y el monto es exacto.
> **Nota T06**: El retorno anticipado garantiza score = max(90, 50) = 90 cuando hay tag match y no hay monto configurado.

---

## Sección de verificación — 7 escenarios con detalle de MatchDetails

| ID | Verifica | TagScore | AmountScore | Score final |
|----|----------|----------|-------------|-------------|
| V01 | Sin tags + monto exacto → AmountScore=70, TagScore=0 | 0 | 70 | 90 |
| V02 | Tags sin match + monto exacto → AmountScore=70, TagScore=0 | 0 | 70 | 70 |
| V03 | Todos los tags + monto exacto → AmountScore=70, TagScore=30 | 30 | 70 | 100 |
| V04 | Tags parciales (1/2) + monto exacto → AmountScore=70, TagScore=15 | 15 | 70 | 85 |
| V05 | Todos los tags, sin monto → normalizado=100, AmountScore=0 | 30 | 0 | 100 |
| V06 | Tags parciales (1/2), sin monto → normalizado=50, max(90,50)=90 | 15 | 0 | 90 |
| V07 | Monto >10 % diff, sin tags → score=0, AmountScore=0 | 0 | 0 | 0 |

---

## Fórmulas de penalización de monto

Cuando `0 < diffPct ≤ 10 %`:

```
penalty     = (diffPct / AMOUNT_TOLERANCE_PERCENT) × 10
            = (diffPct / 10) × 10
AmountScore = 70 - penalty
```

Ejemplos:

| Diferencia | penalty | AmountScore |
|------------|---------|-------------|
| 0 % | 0 | 70 |
| 5 % | 5 | 65 |
| 10 % | 10 | 60 |
| > 10 % | — | 0 |

---

## Casos especiales: retorno anticipado

### Monto exacto sin tags
Cuando `diff == 0` y `MatchedTags.Count == 0 && UnmatchedTags.Count == 0`:
```
return max(AUTO_APPLY_THRESHOLD, EXACT_AMOUNT_SCORE)
     = max(90, 70)
     = 90
```
Esto garantiza que una coincidencia de monto perfecta sin configuración de tags sea siempre AutoReconcile, incluso si la suma TagScore(0) + AmountScore(70) = 70 quedaría en NeedReview.

### Tag match sin monto configurado
Cuando `candidate.Amount == null` y `MatchedTags.Count > 0`:
```
normalizedScore = TagScore × (100 / 30)
return max(AUTO_APPLY_THRESHOLD, normalizedScore)
     = max(90, normalizedScore)
```
Cualquier tag match sin monto configurado garantiza AutoReconcile.

---

## Testabilidad

La lógica de scoring está en `ReconciliationScoreCalculator` (clase `internal static`).
El ensamblado expone sus internals al proyecto de tests mediante:

```csharp
// Levara.Application/Properties/AssemblyInfo.cs
[assembly: InternalsVisibleTo("Levara.Application.Tests")]
```

Los tests se encuentran en `Levara.Application.Tests/Plaid/ReconcileTransaction/ReconciliationScoreCalculatorTests.cs`.

Para ejecutar los tests:
```bash
dotnet test Levara.Application.Tests
```
