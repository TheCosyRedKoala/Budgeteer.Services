using Budgeteer.Services.Domain.Expenses;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Budgeteer.Services.Persistence.Configurations.Expenses;

internal class SavingConfiguration : EntityConfiguration<Saving>
{
    public override void Configure(EntityTypeBuilder<Saving> builder)
    {
        base
            .Configure(builder);
    }
}
