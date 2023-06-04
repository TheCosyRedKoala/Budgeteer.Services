using Budgeteer.Services.Domain.Expenses;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Budgeteer.Services.Persistence.Configurations.Expenses;

internal class AExpenseConfiguration : EntityConfiguration<AExpense>
{
    public override void Configure(EntityTypeBuilder<AExpense> builder)
    {
        base
            .Configure(builder);
    }
}
