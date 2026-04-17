using Levara.Application.ExpenseCharges.Create;
using Levara.Application.Identity.Services.Jwt;
using Levara.Application.LeaseCharges.Create;
using Levara.Application.MaintenancesCharges.Create;
using Levara.Application.Plaid.CreateExpensePayment;
using Levara.Application.Plaid.CreateLeasePayment;
using Levara.Application.Plaid.CreateMaintenancePayment;
using Levara.Application.Plaid.ReconcileTransaction.Services;
using Levara.Shared.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Levara.Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddQueryServices(assembly);
        services.AddCommandServices(assembly);
        services.AddSubscriberServices(assembly);

        services.AddScoped<JwtService>();

        services.AddScoped<CreateExpensePaymentCommandService>();
        services.AddScoped<CreateLeasePaymentCommandService>();
        services.AddScoped<CreateMaintenancePaymentCommandService>();
        services.AddScoped<CreateLeaseChargeCommandService>();
        services.AddScoped<CreateExpenseChargeCommandService>();
        services.AddScoped<CreateMaintenanceChargeCommandService>();

        // Reconciliation services
        services.AddSingleton<ReconciliationScoreCalculator>();
        services.AddScoped<PendingChargeGenerator>();
        services.AddScoped<ReconciliationCandidateBuilder>();
        services.AddScoped<ReconciliationPaymentApplier>();
        services.AddScoped<ReconciliationLevelProcessor>();

        return services;
    }
}
