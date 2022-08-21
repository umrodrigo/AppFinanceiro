using Financ.Data.Models;
using Financ.Data.Models.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Financ.Data
{
    public class FinancContext : DbContext
    {
        public FinancContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> User { get; set; } 
        public DbSet<Category> Category { get; set; } 
        public DbSet<Expense> Expense { get; set; } 
        public DbSet<Income> Income { get; set; } 
        public DbSet<Origin> Origin { get; set; } 
        public DbSet<ProfileExpense> ProfileExpense { get; set; } 
        public DbSet<ProfileIncome> ProfileIncome { get; set; } 
        public DbSet<ProfilePay> ProfilePay { get; set; } 
        public DbSet<TypePay> TypePay { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new UserMap())
                .ApplyConfiguration(new CategoryMap())
                .ApplyConfiguration(new ExpenseMap())
                .ApplyConfiguration(new IncomeMap())
                .ApplyConfiguration(new OriginMap())
                .ApplyConfiguration(new ProfileExpenseMap())
                .ApplyConfiguration(new ProfileIncomeMap())
                .ApplyConfiguration(new ProfilePayMap())
                .ApplyConfiguration(new TypePayMap())
                ;
        }
    }
}