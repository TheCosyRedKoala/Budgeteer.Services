using Budgeteer.Services.Domain.Budgets;
using TCRK.Models.Budgeteer.Budgets;

namespace Budgeteer.Services.Repositories.Budgets;

public interface IMonthlyBudgetRepository
{
    Task<List<MonthlyBudget>> GetAsync();
    Task<MonthlyBudget> GetByIdAsync(Guid id);
    Task AddIncomeAsync(MonthlyBudgetRequest.AddIncome request);
    Task RemoveIncomeAsync(MonthlyBudgetRequest.RemoveIncome request);
    Task AddCostAsync(MonthlyBudgetRequest.AddCost request);
    Task RemoveCostAsync(MonthlyBudgetRequest.RemoveCost request);
    Task AddSavingAsync(MonthlyBudgetRequest.AddSaving request);
    Task RemoveSavingAsync(MonthlyBudgetRequest.RemoveSaving request);
    Task DeleteByIdAsync(Guid id);
}
