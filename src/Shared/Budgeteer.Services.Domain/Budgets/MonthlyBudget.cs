using Budgeteer.Services.Domain.Common;
using Budgeteer.Services.Domain.Expenses;
using Budgeteer.Services.Domain.Incomes;
using TCRK.DomainHelpers.Classes;

namespace Budgeteer.Services.Domain.Budgets;

public class MonthlyBudget : Entity
{
    private List<Income> _incomes = new();
    private List<Cost> _costs = new();
    private List<Saving> _savings = new();

    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public MonthType Month { get; private set; }

    public IReadOnlyCollection<Income> Incomes => _incomes;
    public IReadOnlyCollection<Cost> Costs => _costs;
    public IReadOnlyCollection<Saving> Savings => _savings;
    public decimal IncomeAmount => _incomes.Sum(i => i.Amount);
    public decimal CostAmount => _costs.Sum(c => c.Amount);
    public decimal SavingAmount => _costs.Sum(s => s.Amount);
    public decimal AvailableBudget => IncomeAmount - CostAmount - SavingAmount;

    protected MonthlyBudget() { }

    public MonthlyBudget(DateTime startDate, DateTime endDate, MonthType month)
    {
        StartDate = startDate;
        EndDate = endDate;
        Month = Guard.Against.EnumOutOfRange(month, nameof(month));
    }

    public void AddIncome(Income income)
    {
        _incomes.Add(income);
    }

    public void RemoveIncome(Income income)
    {
        _incomes.Remove(income);
    }

    public void AddCost(Cost cost)
    {
        _costs.Add(cost);
    }

    public void RemoveCost(Cost cost)
    {
        _costs.Remove(cost);
    }

    public void AddSaving(Saving saving)
    {
        _savings.Add(saving);
    }

    public void RemoveSaving(Saving saving)
    {
        _savings.Remove(saving);
    }
}
