using Budgeteer.Services.Domain.Expenses;
using TCRK.DomainHelpers.Classes;

namespace Budgeteer.Services.Domain.SavingsAccounts;

public class SavingsAccount : Entity
{
    private List<Saving> _savings = new();

    public string Name { get; private set; } = default!;
    public string IBAN { get; private set; } = default!;

    public IReadOnlyCollection<Saving> Savings => _savings;

    protected SavingsAccount() { }

    public SavingsAccount(string name, string iban)
    {
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        IBAN = Guard.Against.NullOrWhiteSpace(iban, nameof(iban));
    }

    public void RemoveSaving(Saving saving) 
    {
        _savings.Remove(saving);    
    }
}
