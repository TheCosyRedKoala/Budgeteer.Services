using Budgeteer.Services.Domain.Common;

namespace Budgeteer.Services.Domain.Expenses;

public class Cost : AExpense
{
	protected Cost() : base() { }

	public Cost(string name, decimal amount, RecurrenceType recurrence) : base(name, amount, recurrence)
	{

	}
}
