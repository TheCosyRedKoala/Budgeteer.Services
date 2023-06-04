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

	[HttpGet] 
	public async Task<List<SavingsAccountDto.Index>> GetIndexAsync()
	{
		return await _service.GetIndexAsync();
	}
}
