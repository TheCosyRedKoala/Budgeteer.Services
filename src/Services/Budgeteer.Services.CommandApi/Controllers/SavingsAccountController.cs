using Microsoft.AspNetCore.Mvc;
using TCRK.Models.Budgeteer.SavingsAccounts;

namespace Budgeteer.Services.CommandApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SavingsAccountController : ControllerBase
{
	private readonly ISavingsAccountService _service;

	public SavingsAccountController(ISavingsAccountService service)
	{
		_service = service;
	}

	[HttpPost]
	public async Task<Guid> CreateAsync([FromBody] SavingsAccountDto.Mutate model)
	{
		return await _service.CreateAsync(model);
	}

	[HttpPut("RemoveSaving")]
	public async Task RemoveSavingAsync([FromBody] SavingsAccountRequest.RemoveSaving request)
	{
		await _service.RemoveSavingAsync(request);
	}

	[HttpDelete("{id}")]
	public async Task DeleteByIdAsync(Guid id)
	{
		await _service.DeleteByIdAsync(id);
	}
}
