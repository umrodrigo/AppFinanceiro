using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financ.Data.Models.Mapping
{
    public sealed class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user", "dbo");

            builder.HasKey(x => x.Id);

            builder
                .HasMany(many => many.ProfileIncome)
                .WithOne(one => one.User)
                .HasForeignKey(fk => fk.IdUser);

            builder
                .HasMany(many => many.ProfileExpense)
                .WithOne(one => one.User)
                .HasForeignKey(fk => fk.IdUser);

        }

    }
}
