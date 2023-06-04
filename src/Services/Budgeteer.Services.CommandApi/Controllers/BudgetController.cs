using Microsoft.AspNetCore.Mvc;
using TCRK.Models.Budgeteer.Budgets;

namespace Budgeteer.Services.CommandApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BudgetController : ControllerBase
{
    private readonly IBudgetService _service;

	public BudgetController(IBudgetService service)
	{
		_service = service;
	}

	[HttpPost]
	public async Task<Guid> CreateAsync([FromBody] BudgetDto.Mutate model)
	{
		return await _service.CreateAsync(model);
	}

	[HttpPut("AddMonthlyBudget")]
	public async Task AddMonthlyBudgetAsync([FromBody] BudgetRequest.AddMonthlyBudget request)
	{
		await _service.AddMonthlyBudgetAsync(request);
	}

    [HttpPut("RemoveMonthlyBudget")]
    public async Task RemoveMonthlyBudgetAsync([FromBody] BudgetRequest.RemoveMonthlyBudget request)
    {
        await _service.RemoveMonthlyBudgetAsync(request);
    }

	[HttpDelete("{id}")]
	public async Task DeleteByIdAsync(Guid id)
	{
		await _service.DeleteByIdAsync(id);
	}
}
