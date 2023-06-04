using Budgeteer.Services.Domain.Expenses;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Budgeteer.Services.Persistence.Configurations.Expenses;

internal class CostConfiguration : EntityConfiguration<Cost>
{
    public override void Configure(EntityTypeBuilder<Cost> builder)
    {
        base
            .Configure(builder);
    }
}
