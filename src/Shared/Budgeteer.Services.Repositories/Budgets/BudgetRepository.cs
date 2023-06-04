using Budgeteer.Services.Domain.Budgets;
using Budgeteer.Services.Domain.Common;
using Budgeteer.Services.Persistence;
using Microsoft.EntityFrameworkCore;
using TCRK.DomainHelpers.Exceptions;
using TCRK.Models.Budgeteer.Budgets;

namespace Budgeteer.Services.Repositories.Budgets;

public class BudgetRepository : IBudgetRepository
{
    private readonly ApplicationDbContext _context;

	public BudgetRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<Guid> CreateAsync(BudgetDto.Mutate model)
	{
		Budget budget = new(model.Name);

		_context.Budgets.Add(budget);
		await _context.SaveChangesAsync();

		return budget.Id;
	}

	public async Task<List<Budget>> GetAsync()
	{
		return await _context.Budgets.Where(b => b.IsEnabled).ToListAsync();
	}

	public async Task<Budget> GetByIdAsync(Guid id)
	{
		Budget? budget = await _context.Budgets.FirstOrDefaultAsync(b => b.Id == id && b.IsEnabled);

		if (budget is null)
		{
			throw new EntityNotFoundException(nameof(Budget), id);
		}

		return budget;
	}

	public async Task AddMonthlyBudgetAsync(BudgetRequest.AddMonthlyBudget request)
	{
        Budget budget = await GetByIdAsync(request.BudgetId);

		MonthlyBudget monthlyBudget = new(request.MonthlyBudget.StartDate, request.MonthlyBudget.EndDate, (MonthType)request.MonthlyBudget.Month);

		budget.AddMonthlyBudget(monthlyBudget);

		await _context.SaveChangesAsync();
    }

	public async Task RemoveMonthlyBudgetAsync(BudgetRequest.RemoveMonthlyBudget request)
	{
        Budget budget = await GetByIdAsync(request.BudgetId);

		MonthlyBudget? monthlyBudget = budget.MonthlyBudgets.FirstOrDefault(mb => mb.Id == request.MonthlyBudgetId);

		if (monthlyBudget is null)
		{
			throw new EntityNotFoundException(nameof(MonthlyBudget), request.MonthlyBudgetId);
		}

		budget.RemoveMonthlyBudget(monthlyBudget);

		await _context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(Guid id)
	{
		Budget budget = await GetByIdAsync(id);

        budget.IsEnabled = false;

		await _context.SaveChangesAsync();
    }
}
