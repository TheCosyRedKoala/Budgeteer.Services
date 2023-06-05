using Budgeteer.Services.Domain.Budgets;
using TCRK.Models.Budgeteer.Budgets;

namespace Budgeteer.Services.Repositories.Budgets;

public interface IBudgetRepository
{
    Task<Guid> CreateAsync(BudgetDto.Mutate model);
    Task<List<Budget>> GetAsync();
    Task<Budget> GetByIdAsync(Guid id);
    Task UpdateByIdAsync(Guid id, BudgetDto.Mutate model);
    Task AddMonthlyBudgetAsync(BudgetRequest.AddMonthlyBudget request);
    Task RemoveMonthlyBudgetAsync(BudgetRequest.RemoveMonthlyBudget request);
    Task DeleteByIdAsync(Guid id);
}
