namespace TCRK.Models.Budgeteer.Budgets;

public interface IMonthlyBudgetService
{
    Task<List<MonthlyBudgetDto.Index>> GetIndexAsync();
    Task<MonthlyBudgetDto.Detail> GetDetailAsync(Guid id);
    Task AddIncomeAsync(MonthlyBudgetRequest.AddIncome request);
    Task RemoveIncomeAsync(MonthlyBudgetRequest.RemoveIncome request);
    Task AddCostAsync(MonthlyBudgetRequest.AddCost request);
    Task RemoveCostAsync(MonthlyBudgetRequest.RemoveCost request);
    Task AddSavingAsync(MonthlyBudgetRequest.AddSaving request);
    Task RemoveSavingAsync(MonthlyBudgetRequest.RemoveSaving request);
    Task DeleteByIdAsync(Guid id);
}
