using Inspection.Domain.Models.SystemConfigurations.CurrencyExchangRates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.SystemConfigurations.CurrencyExchangRates
{
    public class CurrencyExchangRateConfig : IEntityTypeConfiguration<CurrencyExchangRate>

    {
        public void Configure(EntityTypeBuilder<CurrencyExchangRate> builder)
        {
            builder.ToTable("CurrencyExchangRate", "Sec");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);

            builder.HasOne(x => x.Currency)
                   .WithMany()
                   .HasForeignKey(x => new { x.CurrencyId });

            builder.HasIndex(x => new { x.Tenant_ID, x.CurrencyId, x.EffectiveDate }).IsUnique();

            builder.Property(x => x.EffectiveDate).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Mod_User).HasMaxLength(100);
        }
    }
}