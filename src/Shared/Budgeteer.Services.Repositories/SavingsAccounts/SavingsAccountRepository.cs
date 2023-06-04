using Budgeteer.Services.Domain.Expenses;
using Budgeteer.Services.Domain.SavingsAccounts;
using Budgeteer.Services.Persistence;
using Microsoft.EntityFrameworkCore;
using TCRK.DomainHelpers.Exceptions;
using TCRK.Models.Budgeteer.SavingsAccounts;

namespace Budgeteer.Services.Repositories.SavingsAccounts;

public class SavingsAccountRepository : ISavingsAccountRepository
{
    private readonly ApplicationDbContext _context;

	public SavingsAccountRepository(ApplicationDbContext applicationDbContext)
	{
		_context = applicationDbContext;
	}

	public async Task<Guid> CreateAsync(SavingsAccountDto.Mutate model)
	{
		SavingsAccount savingsAccount = new(model.Name, model.IBAN);

		_context.SavingsAccounts.Add(savingsAccount);
		await _context.SaveChangesAsync();

		return savingsAccount.Id;
	}

	public async Task<List<SavingsAccount>> GetAsync()
	{
		return await _context.SavingsAccounts.ToListAsync();
	}

	public async Task<SavingsAccount> GetByIdAsync(Guid id)
	{
		SavingsAccount? savingsAccount = await _context.SavingsAccounts
			.Include(sa => sa.Savings)
			.FirstOrDefaultAsync(sa => sa.Id == id);

		if (savingsAccount is null)
		{
			throw new EntityNotFoundException(nameof(SavingsAccount), id);
		}

		return savingsAccount;
	}

	public async Task RemoveSavingAsync(SavingsAccountRequest.RemoveSaving request)
	{
		SavingsAccount savingsAccount = await GetByIdAsync(request.SavingsAccountId);

		Saving? saving = savingsAccount.Savings.FirstOrDefault(s =>
			s.Id == request.SavingId
			&& s.IsEnabled
		);

		if (saving is null)
		{
			throw new EntityNotFoundException(nameof(Saving), request.SavingId);
		}

		savingsAccount.RemoveSaving(saving);

		await _context.SaveChangesAsync();
	}

	public async Task DeleteByIdAsync(Guid id)
	{
		SavingsAccount savingsAccount = await GetByIdAsync(id);

		savingsAccount.IsEnabled = false;

		await _context.SaveChangesAsync();
	}
}
