using Microsoft.AspNetCore.Mvc;
using TCRK.Models.Budgeteer.Budgets;

namespace Budgeteer.Services.CommandApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MonthlyBudgetController : ControllerBase
{
    private readonly IMonthlyBudgetService _service;

	public MonthlyBudgetController(IMonthlyBudgetService service)
	{
		_service = service;
	}

	[HttpGet]
	public async Task<List<MonthlyBudgetDto.Index>> GetIndexAsync()
	{
		return await _service.GetIndexAsync();
	}

	[HttpGet("{id}")]
	public async Task<MonthlyBudgetDto.Detail> GetDetailAsync(Guid id)
	{
		return await _service.GetDetailAsync(id);
	}

	[HttpPut("AddIncome")]
	public async Task AddIncomeAsync([FromBody] MonthlyBudgetRequest.AddIncome request)
	{
		await _service.AddIncomeAsync(request);
	}

	[HttpPut("RemoveIncome")]
	public async Task RemoveIncomeAsync([FromBody] MonthlyBudgetRequest.RemoveIncome request)
	{
		await _service.RemoveIncomeAsync(request);
	}

	[HttpPut("AddCost")]
	public async Task AddCostAsync([FromBody] MonthlyBudgetRequest.AddCost request)
	{
		await _service.AddCostAsync(request);
	}

	[HttpPut("RemoveCost")]
	public async Task RemoveCostAsync([FromBody] MonthlyBudgetRequest.RemoveCost request)
	{
		await _service.RemoveCostAsync(request);
	}

	[HttpPut("AddSaving")]
	public async Task AddSavingAsync([FromBody] MonthlyBudgetRequest.AddSaving request)
	{
		await _service.AddSavingAsync(request);
	}

	[HttpPut("RemoveSaving")]
	public async Task RemoveSavingAsync([FromBody] MonthlyBudgetRequest.RemoveSaving request)
	{
		await _service.RemoveSavingAsync(request);
	}

	[HttpDelete("{id}")]
	public async Task DeleteByIdAsync(Guid id)
	{
		await _service.DeleteByIdAsync(id);
	}
}
