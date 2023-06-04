using Budgeteer.Services.Domain.Budgets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Budgeteer.Services.Persistence.Configurations.Budgets;

internal class MonthlyBudgetConfiguration : EntityConfiguration<MonthlyBudget>
{
    public override void Configure(EntityTypeBuilder<MonthlyBudget> builder)
    {
        base
            .Configure(builder);

        builder
            .HasMany(mb => mb.Incomes)
            .WithOne();

        builder
            .HasMany(mb => mb.Costs)
            .WithOne();

        builder
            .HasMany(mb => mb.Savings)
            .WithOne();
    }
}
