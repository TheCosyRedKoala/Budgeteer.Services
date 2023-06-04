using Budgeteer.Services.Domain.SavingsAccounts;
using Budgeteer.Services.Repositories.SavingsAccounts;
using TCRK.Models.Budgeteer.SavingsAccounts;

namespace Budgeteer.Services.Services.SavingsAccounts;

public class SavingsAccountService : ISavingsAccountService
{
    private readonly ISavingsAccountRepository _repository;

    public SavingsAccountService(ISavingsAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> CreateAsync(SavingsAccountDto.Mutate model)
    {
        return await _repository.CreateAsync(model);
    }

    public async Task<List<SavingsAccountDto.Index>> GetIndexAsync()
    {
        List<SavingsAccount> savingsAccounts = await _repository.GetAsync();

        return savingsAccounts.Select(sa => new SavingsAccountDto.Index
        {
            Id = sa.Id,
            Name = sa.Name,
            IBAN = sa.IBAN
        }).ToList();
    }

    public async Task RemoveSavingAsync(SavingsAccountRequest.RemoveSaving request)
    {
        await _repository.RemoveSavingAsync(request);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        await _repository.DeleteByIdAsync(id);
    }
}
