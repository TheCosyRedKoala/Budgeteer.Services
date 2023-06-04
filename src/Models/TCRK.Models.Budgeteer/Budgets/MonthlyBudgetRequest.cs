using TCRK.Models.Budgeteer.Expenses;
using TCRK.Models.Budgeteer.Incomes;

namespace TCRK.Models.Budgeteer.Budgets;

public static class MonthlyBudgetRequest
{
    public class AddIncome
    {
        public Guid MonthlyBudgetId { get; set; }
        public IncomeDto.Mutate Income { get; set; } = new();
    }

    public class RemoveIncome
    {
        public Guid MonthlyBudgetId { get; set; }
        public Guid IncomeId { get; set; }
    }

    public class AddCost
    {
        public Guid MonthlyBudgetId { get; set; }
        public AExpensesDto.Mutate Cost { get; set; } = new();
    }

    public class RemoveCost
    {
        public Guid MonthlyBudgetId { get; set; }
        public Guid CostId { get; set; }
    }

    public class AddSaving
    {
        public Guid MonthlyBudgetId { get; set; }
        public SavingDto.Mutate Saving { get; set; } = new();
    }

    public class RemoveSaving
    {
        public Guid MonthlyBudgetId { get; set; }
        public Guid SavingId { get; set; }
    }
}