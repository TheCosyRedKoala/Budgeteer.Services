using FluentValidation.Results;

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

            public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
            {
                ValidationResult result = await ValidateAsync(ValidationContext<Mutate>.CreateWithOptions((Mutate)model, x => x.IncludeProperties(propertyName)));

                if (result.IsValid)
                {
                    return Array.Empty<string>();
                }

                return result.Errors.Select(e => e.ErrorMessage);
            };
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
