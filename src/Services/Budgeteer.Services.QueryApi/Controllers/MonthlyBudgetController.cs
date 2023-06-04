using Microsoft.AspNetCore.Mvc;
using TCRK.Models.Budgeteer.Budgets;

namespace Budgeteer.Services.QueryApi.Controllers;

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
}
