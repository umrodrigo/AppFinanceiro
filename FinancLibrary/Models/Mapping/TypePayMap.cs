using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financ.Data.Models.Mapping
{
    public sealed class TypePayMap : IEntityTypeConfiguration<TypePay>
    {
        public void Configure(EntityTypeBuilder<TypePay> builder)
        {
            builder.ToTable("typePay", "dbo");

            builder.HasKey(x => x.Id);

            builder
                .HasMany(many => many.ProfilePay)
                .WithOne(one => one.TypePay)
                .HasForeignKey(fk => fk.IdTypePay);

        }

    }
}
