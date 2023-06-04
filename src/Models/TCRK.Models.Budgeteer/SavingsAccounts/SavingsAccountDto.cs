using TCRK.Models.Budgeteer.Expenses;

namespace TCRK.Models.Budgeteer.SavingsAccounts;

public static class SavingsAccountDto
{
    public class Mutate
    {
        public string Name { get; set; } = default!;
        public string IBAN { get; set; } = default!;

        public class Validator : AbstractValidator<Mutate>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.IBAN).NotEmpty();
            }
        }
    }

    public class Index
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string IBAN { get; set; } = default!;
    }
}
