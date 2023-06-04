using Azure.Core;
using Budgeteer.Services.Domain.Budgets;
using Budgeteer.Services.Domain.Common;
using Budgeteer.Services.Domain.Expenses;
using Budgeteer.Services.Domain.Incomes;
using Budgeteer.Services.Persistence;
using Microsoft.EntityFrameworkCore;
using TCRK.DomainHelpers.Exceptions;
using TCRK.Models.Budgeteer.Budgets;

namespace Budgeteer.Services.Repositories.Budgets;

public class MonthlyBudgetRepository : IMonthlyBudgetRepository
{
    private readonly ApplicationDbContext _context;

	public MonthlyBudgetRepository(ApplicationDbContext applicationDbContext)
	{
		_context = applicationDbContext;
	}

	public async Task<List<MonthlyBudget>> GetAsync()
	{
		return await _context.MonthlyBudgets.ToListAsync();
	}


	public async Task<MonthlyBudget> GetByIdAsync(Guid id)
	{
		MonthlyBudget? monthlyBudget = await _context.MonthlyBudgets
			.Include(mb => mb.Incomes)
			.Include(mb => mb.Costs)
			.Include(mb => mb.Savings)
			.FirstOrDefaultAsync(mb => mb.Id == id);

		if (monthlyBudget is null)
		{
			throw new EntityNotFoundException(nameof(MonthlyBudget), id);
		}

		return monthlyBudget;
	}

	public async Task AddIncomeAsync(MonthlyBudgetRequest.AddIncome request)
	{
		MonthlyBudget monthlyBudget = await GetByIdAsync(request.MonthlyBudgetId);

		Income income = new(request.Income.Name, request.Income.Amount, (RecurrenceType)request.Income.RecurrenceType);

		monthlyBudget.AddIncome(income);

		await _context.SaveChangesAsync();
	}

	public async Task RemoveIncomeAsync(MonthlyBudgetRequest.RemoveIncome request)
	{
		MonthlyBudget monthlyBudget = await GetByIdAsync(request.MonthlyBudgetId);

		Income? income = await _context.Incomes.FirstOrDefaultAsync(i => i.Id == request.IncomeId);

		if (income is null)
		{
			throw new EntityNotFoundException(nameof(Income), request.IncomeId);
		}

		monthlyBudget.RemoveIncome(income);

		await _context.SaveChangesAsync();
	}

	public async Task AddCostAsync(MonthlyBudgetRequest.AddCost request)
	{
		MonthlyBudget monthlyBudget = await GetByIdAsync(request.MonthlyBudgetId);

		Cost cost = new(request.Cost.Name, request.Cost.Amount, (RecurrenceType)request.Cost.RecurrenceType);

		monthlyBudget.AddCost(cost);

		await _context.SaveChangesAsync();
	}

	public async Task RemoveCostAsync(MonthlyBudgetRequest.RemoveCost request)
	{
        MonthlyBudget monthlyBudget = await GetByIdAsync(request.MonthlyBudgetId);

		Cost? cost = await _context.Costs.FirstOrDefaultAsync(c => c.Id == request.CostId);

		if (cost is null)
		{
			throw new EntityNotFoundException(nameof(Cost), request.CostId);
		}

		monthlyBudget.RemoveCost(cost);

		await _context.SaveChangesAsync();
	}

	public async Task AddSavingAsync(MonthlyBudgetRequest.AddSaving request)
	{
        MonthlyBudget monthlyBudget = await GetByIdAsync(request.MonthlyBudgetId);

		Saving saving = new(request.Saving.Name, request.Saving.Amount, (RecurrenceType)request.Saving.RecurrenceType, request.Saving.SavingsAccountId);

		monthlyBudget.AddSaving(saving);

		await _context.SaveChangesAsync();
    }

	public async Task RemoveSavingAsync(MonthlyBudgetRequest.RemoveSaving request)
	{
        MonthlyBudget monthlyBudget = await GetByIdAsync(request.MonthlyBudgetId);

		Saving? saving = await _context.Savings.FirstOrDefaultAsync(s => s.Id == request.SavingId);

		if (saving is null)
		{
			throw new EntityNotFoundException(nameof(Saving), request.SavingId);
		}

		monthlyBudget.RemoveSaving(saving);

		await _context.SaveChangesAsync();
    }

	public async Task DeleteByIdAsync(Guid id)
	{
        MonthlyBudget monthlyBudget = await GetByIdAsync(id);

		monthlyBudget.IsEnabled = true;

		await _context.SaveChangesAsync();
    }
}
