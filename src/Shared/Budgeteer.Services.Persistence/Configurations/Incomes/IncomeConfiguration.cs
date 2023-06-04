using Budgeteer.Services.Domain.Incomes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Budgeteer.Services.Persistence.Configurations.Incomes;

internal class IncomeConfiguration : EntityConfiguration<Income>
{
    public override void Configure(EntityTypeBuilder<Income> builder)
    {
        base.Configure(builder);
    }
}
