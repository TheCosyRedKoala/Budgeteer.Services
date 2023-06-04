using Budgeteer.Services.Domain.Budgets;
using Budgeteer.Services.Repositories.Budgets;
using TCRK.Models.Budgeteer.Budgets;
using TCRK.Models.Budgeteer.Common;
using TCRK.Models.Budgeteer.Expenses;
using TCRK.Models.Budgeteer.Incomes;

namespace Budgeteer.Services.Services.Budgets;

public class MonthlyBudgetService : IMonthlyBudgetService
{
    private readonly IMonthlyBudgetRepository _repository;

    public MonthlyBudgetService(IMonthlyBudgetRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<MonthlyBudgetDto.Index>> GetIndexAsync()
    {
        List<MonthlyBudget> monthlyBudgets = await _repository.GetAsync();

        return monthlyBudgets.Select(mb => new MonthlyBudgetDto.Index
        {
            Id = mb.Id,
            StartDate = mb.StartDate,
            EndDate = mb.EndDate,
            Month = (MonthType)mb.Month
        }).ToList();
    }

    public async Task<MonthlyBudgetDto.Detail> GetDetailAsync(Guid id)
    {
        MonthlyBudget monthlyBudget = await _repository.GetByIdAsync(id);

        return new MonthlyBudgetDto.Detail
        {
            Id = monthlyBudget.Id,
            StartDate = monthlyBudget.StartDate,
            EndDate = monthlyBudget.EndDate,
            Month = (MonthType)monthlyBudget.Month,
            Incomes = monthlyBudget.Incomes.Select(i => new IncomeDto.Index
            {
                Id = i.Id,
                Name = i.Name,
                Amount = i.Amount,
                RecurrenceType = (RecurrenceType)i.Recurrence
            }),
            Costs = monthlyBudget.Costs.Select(c => new CostDto.Index
            {
                Id = c.Id,
                Name = c.Name,
                Amount = c.Amount,
                RecurrenceType = (RecurrenceType)c.Recurrence
            }),
            Savings = monthlyBudget.Savings.Select(s => new SavingDto.Index
            {
                Id = s.Id,
                Name = s.Name,
                Amount = s.Amount,
                RecurrenceType = (RecurrenceType)s.Recurrence
            }),
            IncomeAmount = monthlyBudget.IncomeAmount,
            CostAmount = monthlyBudget.CostAmount,
            SavingAmount = monthlyBudget.SavingAmount,
            AvailableBudget = monthlyBudget.AvailableBudget
        };
    }

    public async Task AddIncomeAsync(MonthlyBudgetRequest.AddIncome request)
    {
        await _repository.AddIncomeAsync(request);
    }

    public async Task RemoveIncomeAsync(MonthlyBudgetRequest.RemoveIncome request)
    {
        await _repository.RemoveIncomeAsync(request);
    }


    public async Task AddCostAsync(MonthlyBudgetRequest.AddCost request)
    {
        await _repository.AddCostAsync(request);
    }

    public async Task RemoveCostAsync(MonthlyBudgetRequest.RemoveCost request)
    {
        await _repository.RemoveCostAsync(request);
    }

    public async Task AddSavingAsync(MonthlyBudgetRequest.AddSaving request)
    {
        await _repository.AddSavingAsync(request);
    }

    public async Task RemoveSavingAsync(MonthlyBudgetRequest.RemoveSaving request)
    {
        await _repository.RemoveSavingAsync(request);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        await _repository.DeleteByIdAsync(id);
    }
}
