using Microsoft.AspNetCore.Mvc;
using TCRK.Models.Budgeteer.Budgets;

namespace Budgeteer.Services.QueryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BudgetController : ControllerBase
{
    private readonly IBudgetService _service;

    public BudgetController(IBudgetService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<List<BudgetDto.Index>> GetIndexAsync()
    {
        return await _service.GetIndexAsync();
    }

    [HttpGet("{id}")]
    public async Task<BudgetDto.Detail> GetDetailAsync(Guid id)
    {
        return await _service.GetDetailAsync(id);
    }
}
