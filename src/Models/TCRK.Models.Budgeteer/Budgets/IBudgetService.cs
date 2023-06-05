namespace TCRK.Models.Budgeteer.Budgets;

public interface IBudgetService
{
    Task<Guid> CreateAsync(BudgetDto.Mutate model);
    Task<List<BudgetDto.Index>> GetIndexAsync();
    Task<BudgetDto.Detail> GetDetailAsync(Guid id);
    Task UpdateByIdAsync(Guid id, BudgetDto.Mutate model);
    Task AddMonthlyBudgetAsync(BudgetRequest.AddMonthlyBudget request);
    Task RemoveMonthlyBudgetAsync(BudgetRequest.RemoveMonthlyBudget request);
    Task DeleteByIdAsync(Guid id);
}
