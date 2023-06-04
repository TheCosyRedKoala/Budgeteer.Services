namespace TCRK.Models.Budgeteer.SavingsAccounts;

public static class SavingsAccountRequest
{
    public class RemoveSaving
    {
        public Guid SavingsAccountId { get; set; }
        public Guid SavingId { get; set; }
    }
}
