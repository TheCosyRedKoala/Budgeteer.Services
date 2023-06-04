namespace TCRK.Models.Budgeteer.SavingsAccounts;

public interface ISavingsAccountService
{
    Task<Guid> CreateAsync(SavingsAccountDto.Mutate model);
    Task<List<SavingsAccountDto.Index>> GetIndexAsync();
    Task RemoveSavingAsync(SavingsAccountRequest.RemoveSaving request);
    Task DeleteByIdAsync(Guid id);
}
