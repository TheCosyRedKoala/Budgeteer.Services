using Budgeteer.Services.Domain.Budgets;
using Budgeteer.Services.Repositories.Budgets;
using TCRK.Models.Budgeteer.Budgets;
using TCRK.Models.Budgeteer.Common;

namespace Budgeteer.Services.Services.Budgets;

public class BudgetService : IBudgetService
{
    private readonly IBudgetRepository _repository;

	public BudgetService(IBudgetRepository repository)
	{
		_repository = repository;
	}

    public async Task<Guid> CreateAsync(BudgetDto.Mutate model)
    {
        return await _repository.CreateAsync(model);
    }

    public async Task<List<BudgetDto.Index>> GetIndexAsync()
    {
        List<Budget> budgets = await _repository.GetAsync();

        return budgets.Select(b => new BudgetDto.Index
        {
            Id = b.Id,
            Name = b.Name
        }).ToList();
    }

    public async Task<BudgetDto.Detail> GetDetailAsync(Guid id)
    {
        Budget budget = await _repository.GetByIdAsync(id);

        return new BudgetDto.Detail
        {
            Id = budget.Id,
            Name = budget.Name,
            MonthlyBudgets = budget.MonthlyBudgets.Select(mb => new MonthlyBudgetDto.Index
            {
                Id = mb.Id,
                StartDate = mb.StartDate,
                EndDate = mb.EndDate,
                Month = (MonthType)mb.Month
            }).ToList()
        };
    }

    public async Task AddMonthlyBudgetAsync(BudgetRequest.AddMonthlyBudget request)
    {
        await _repository.AddMonthlyBudgetAsync(request);
    }

    public async Task RemoveMonthlyBudgetAsync(BudgetRequest.RemoveMonthlyBudget request)
    {
        await _repository.RemoveMonthlyBudgetAsync(request);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        await _repository.DeleteByIdAsync(id);
    }
}
