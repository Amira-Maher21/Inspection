using Inspection.Domain.Models.SystemConfigurations.Currencies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.SystemConfigurations.Currencies
{
    public class CurrencyConfig : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("Currency", "Sec");
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.Tenant_ID, x.Code }).IsUnique();

            builder.Property(x => x.Tenant_ID).IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Code).IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Name).IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.CurrencySymbol).IsRequired()
                   .HasMaxLength(10);

            builder.Property(x => x.Sub_Currency)
                   .HasMaxLength(100);



            builder.Property(x => x.Disabled)
                   .IsRequired()
                   .HasDefaultValue(false);


            builder.Property(x => x.In_User).IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date).IsRequired();

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100);

            builder.Property(x => x.Mod_Date);
        }
    }
}