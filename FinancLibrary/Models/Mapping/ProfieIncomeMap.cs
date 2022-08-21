using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financ.Data.Models.Mapping
{
    public sealed class ProfileIncomeMap : IEntityTypeConfiguration<ProfileIncome>
    {
        public void Configure(EntityTypeBuilder<ProfileIncome> builder)
        {
            builder.ToTable("profileIncome", "dbo");

            builder.HasKey(x => x.Id);

            builder
                .HasOne(one => one.Income)
                .WithOne(one => one.ProfileIncome)
                .HasForeignKey<ProfileIncome>(fk => fk.IdIncome);

        }

    }
}
