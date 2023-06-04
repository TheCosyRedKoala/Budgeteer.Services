using Budgeteer.Services.Domain.SavingsAccounts;
using TCRK.Models.Budgeteer.SavingsAccounts;

namespace Budgeteer.Services.Repositories.SavingsAccounts;

public interface ISavingsAccountRepository
{
    Task<Guid> CreateAsync(SavingsAccountDto.Mutate model);
    Task<List<SavingsAccount>> GetAsync();
    Task<SavingsAccount> GetByIdAsync(Guid id);
    Task RemoveSavingAsync(SavingsAccountRequest.RemoveSaving request);
    Task DeleteByIdAsync(Guid id);
}