using Budgeteer.Services.Domain.SavingsAccounts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Budgeteer.Services.Persistence.Configurations.SavingsAccounts;

internal class SavingsAccountConfiguration : EntityConfiguration<SavingsAccount>
{
    public override void Configure(EntityTypeBuilder<SavingsAccount> builder)
    {
        base
            .Configure(builder);

        builder
            .HasMany(sa => sa.Savings)
            .WithOne()
            .HasForeignKey(s => s.SavingsAccountId);
    }
}
