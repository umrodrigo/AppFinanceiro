using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financ.Data.Models.Mapping
{
    public sealed class IncomeMap : IEntityTypeConfiguration<Income>
    {
        public void Configure(EntityTypeBuilder<Income> builder)
        {
            builder.ToTable("income", "dbo");

            builder.HasKey(x => x.Id);


        }

    }
}
