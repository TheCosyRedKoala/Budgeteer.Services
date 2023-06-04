namespace TCRK.Models.Budgeteer.Budgets;

public static class BudgetDto
{
    public class Mutate
    {
        public string Name { get; set; } = default!;

        public class Validator : AbstractValidator<Mutate> 
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotEmpty();
            }
        }
    }

    public class Index
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
    }

    public class Detail
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public IEnumerable<MonthlyBudgetDto.Index> MonthlyBudgets { get; set; } = new List<MonthlyBudgetDto.Index>();
    }
}
