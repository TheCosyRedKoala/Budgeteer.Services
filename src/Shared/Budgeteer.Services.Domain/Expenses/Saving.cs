using Budgeteer.Services.Domain.Common;

namespace Budgeteer.Services.Domain.Expenses;

public class Saving : AExpense
{
	public Guid SavingsAccountId { get; private set; }

	protected Saving() : base() { }

	public Saving(string name, decimal amount, RecurrenceType recurrence, Guid savingsAccountId) : base(name, amount, recurrence)
	{
		SavingsAccountId = Guard.Against.Null(savingsAccountId, nameof(SavingsAccountId));
	}
}
