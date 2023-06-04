using Budgeteer.Services.Services.Budgets;
using Budgeteer.Services.Services.SavingsAccounts;
using Microsoft.Extensions.DependencyInjection;
using TCRK.Models.Budgeteer.Budgets;
using TCRK.Models.Budgeteer.SavingsAccounts;

namespace Budgeteer.Services.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRestServices(this IServiceCollection services)
    {
        services.AddTransient<IBudgetService, BudgetService>();
        services.AddTransient<IMonthlyBudgetService, MonthlyBudgetService>();
        services.AddTransient<ISavingsAccountService, SavingsAccountService>();

        return services;
    }
}
