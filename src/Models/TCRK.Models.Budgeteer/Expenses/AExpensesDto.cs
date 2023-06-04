using TCRK.Models.Budgeteer.Common;

namespace TCRK.Models.Budgeteer.Expenses;

public abstract class AExpensesDto
{
    public class Mutate
    {
        public string Name { get; set; } = default!;
        public decimal Amount { get; set; }
        public RecurrenceType RecurrenceType { get; set; }

        public class Validator : AbstractValidator<Mutate>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
                RuleFor(x => x.RecurrenceType).IsInEnum();
            }
        }
    }

    public class Index
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Amount { get; set; }
        public RecurrenceType RecurrenceType { get; set; }
    }
}
