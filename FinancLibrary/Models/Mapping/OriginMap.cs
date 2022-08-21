using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financ.Data.Models.Mapping
{
    public sealed class OriginMap : IEntityTypeConfiguration<Origin>
    {
        public void Configure(EntityTypeBuilder<Origin> builder)
        {
            builder.ToTable("origin", "dbo");

            builder.HasKey(x => x.Id);

            builder
                .HasMany(many => many.Income)
                .WithOne(one => one.Origin)
                .HasForeignKey(fk => fk.IdOrigin);

            builder
                .HasMany(many => many.Expense)
                .WithOne(one => one.Origin)
                .HasForeignKey(fk => fk.IdOrigin);

        }

    }
}
