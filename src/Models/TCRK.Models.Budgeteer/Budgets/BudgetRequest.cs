namespace TCRK.Models.Budgeteer.Budgets;

public static class BudgetRequest
{
    public class AddMonthlyBudget
    {
        public Guid BudgetId { get; set; }
        public MonthlyBudgetDto.Mutate MonthlyBudget { get; set; } = new();
    }

    public class RemoveMonthlyBudget
    {
        public Guid BudgetId { get; set; }
        public Guid MonthlyBudgetId { get; set; }
    }
}
