using TCRK.Models.Budgeteer.Common;
using TCRK.Models.Budgeteer.Expenses;
using TCRK.Models.Budgeteer.Incomes;

namespace TCRK.Models.Budgeteer.Budgets;

public static class MonthlyBudgetDto
{
    public class Mutate
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MonthType Month { get; set; }

        public class Validator : AbstractValidator<Mutate> 
        {
            public Validator()
            {
                RuleFor(x => x.StartDate).LessThan(x => x.EndDate);
                RuleFor(x => x.EndDate).GreaterThan(x => x.StartDate);
                RuleFor(x => x.Month).IsInEnum();
            }
        }
    }

    public class Index
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MonthType Month { get; set; }
    }

    public class Detail
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MonthType Month { get; set; }
        public IEnumerable<IncomeDto.Index> Incomes { get; set; } = new List<IncomeDto.Index>();
        public IEnumerable<CostDto.Index> Costs { get; set; } = new List<CostDto.Index>();
        public IEnumerable<SavingDto.Index> Savings { get; set; } = new List<SavingDto.Index>();
        public decimal IncomeAmount { get; set; }
        public decimal CostAmount { get; set; }
        public decimal SavingAmount { get; set; }
        public decimal AvailableBudget { get; set; }
    }
}
