using TCRK.DomainHelpers.Classes;

namespace Budgeteer.Services.Domain.Budgets;

public class Budget : Entity
{
    private List<MonthlyBudget> _monthlyBudgets = new();

    public string Name { get; private set; }

    public IReadOnlyCollection<MonthlyBudget> MonthlyBudgets => _monthlyBudgets;

    protected Budget() { }

    public Budget(string name)
    {
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
    }

    public void AddMonthlyBudget(MonthlyBudget budget)
    {
        _monthlyBudgets.Add(budget);
    }

    public void RemoveMonthlyBudget(MonthlyBudget budget)
    {
        _monthlyBudgets.Remove(budget);
    }
}
