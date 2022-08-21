using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financ.Data.Models.Mapping
{
    public sealed class ProfileExpenseMap : IEntityTypeConfiguration<ProfileExpense>
    {
        public void Configure(EntityTypeBuilder<ProfileExpense> builder)
        {
            builder.ToTable("profileExpense", "dbo");

            builder.HasKey(x => x.Id);

            builder
                .HasOne(one => one.Expense)
                .WithOne(one => one.ProfileExpense)
                .HasForeignKey<ProfileExpense>(fk => fk.IdExpense);

        }

    }
}
