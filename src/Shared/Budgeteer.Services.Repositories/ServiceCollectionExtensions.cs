using Budgeteer.Services.Repositories.Budgets;
using Budgeteer.Services.Repositories.SavingsAccounts;
using Microsoft.Extensions.DependencyInjection;

namespace Budgeteer.Services.Repositories;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRestRepositories(this IServiceCollection services)
    {
        services.AddTransient<IBudgetRepository, BudgetRepository>();
        services.AddTransient<IMonthlyBudgetRepository, MonthlyBudgetRepository>();
        services.AddTransient<ISavingsAccountRepository, SavingsAccountRepository>();

        return services;
    }
}
