using TCRK.Models.Budgeteer.Common;
using TCRK.Models.Budgeteer.SavingsAccounts;

namespace TCRK.Models.Budgeteer.Expenses;

public class SavingDto : AExpensesDto
{
    new public class Mutate
    {
        public string Name { get; set; } = default!;
        public decimal Amount { get; set; }
        public RecurrenceType RecurrenceType { get; set; }
        public Guid SavingsAccountId { get; set; }

        public class Validator : AbstractValidator<Mutate>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
                RuleFor(x => x.RecurrenceType).IsInEnum();
                RuleFor(x => x.SavingsAccountId).NotEmpty();
            }
        }
    }

    public class Detail
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Amount { get; set; }
        public RecurrenceType RecurrenceType { get; set; }
        public SavingsAccountDto.Index SavingsAccount { get; set; } = new();
    }
}
