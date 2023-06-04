using Budgeteer.Services.Domain.Budgets;
using Budgeteer.Services.Domain.Expenses;
using Budgeteer.Services.Domain.Incomes;
using Budgeteer.Services.Domain.SavingsAccounts;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Budgeteer.Services.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<Budget> Budgets => Set<Budget>();
    public DbSet<MonthlyBudget> MonthlyBudgets => Set<MonthlyBudget>();
    public DbSet<Income> Incomes => Set<Income>();
    public DbSet<AExpense> AExpenses => Set<AExpense>();
    public DbSet<Cost> Costs => Set<Cost>();
    public DbSet<Saving> Savings => Set<Saving>();
    public DbSet<SavingsAccount> SavingsAccounts => Set<SavingsAccount>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        configurationBuilder.Properties<string>().HaveMaxLength(4_000);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
