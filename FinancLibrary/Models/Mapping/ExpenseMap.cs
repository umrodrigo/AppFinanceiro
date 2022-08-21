using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financ.Data.Models.Mapping
{
    public sealed class ExpenseMap : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable("expense", "dbo");

            builder.HasKey(x => x.Id);


        }

    }
}
