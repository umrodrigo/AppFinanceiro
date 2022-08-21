using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financ.Data.Models.Mapping
{
    public sealed class ProfilePayMap : IEntityTypeConfiguration<ProfilePay>
    {
        public void Configure(EntityTypeBuilder<ProfilePay> builder)
        {
            builder.ToTable("profilePay", "dbo");

            builder.HasKey(x => x.Id);

            builder
                .HasMany(many => many.Expense)
                .WithOne(one => one.ProfilePay)
                .HasForeignKey(fk => fk.IdProfilePay);

        }

    }
}
