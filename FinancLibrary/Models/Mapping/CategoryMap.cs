using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financ.Data.Models.Mapping
{
    public sealed class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("category", "dbo");

            builder.HasKey(x => x.Id);

            builder
                .HasMany(many => many.Expense)
                .WithOne(one => one.Category)
                .HasForeignKey(fk => fk.IdCategory);

        }

    }
}
