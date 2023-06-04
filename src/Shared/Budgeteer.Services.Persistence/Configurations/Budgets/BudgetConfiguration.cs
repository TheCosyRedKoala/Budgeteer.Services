using Budgeteer.Services.Domain.Budgets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Budgeteer.Services.Persistence.Configurations.Budgets;

internal class BudgetConfiguration : EntityConfiguration<Budget>
{
    public override void Configure(EntityTypeBuilder<Budget> builder)
    {
        base
            .Configure(builder);

        builder
            .HasMany(b => b.MonthlyBudgets)
            .WithOne();
    }
}
