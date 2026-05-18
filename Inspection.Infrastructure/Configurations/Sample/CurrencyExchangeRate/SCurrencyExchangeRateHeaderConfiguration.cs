using Inspection.Domain.Models.Sample.CurrencyExchangeRate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Sample.CurrencyExchangeRate
{
    internal class SCurrencyExchangeRateHeaderConfiguration : IEntityTypeConfiguration<SCurrencyExchangeRateHeader>
    {
        public void Configure(EntityTypeBuilder<SCurrencyExchangeRateHeader> builder)
        {
            builder.ToTable("CurrencyExchangeRateHeader", "Accounting");

            builder.HasKey(x => x.Id).HasName("PK_CurrencyExchangeRateHeader");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.BaseCurrencyId).IsRequired();
            builder.Property(x => x.EffectiveDate).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(512);
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(50);

            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Header unique constraint: prevent duplicate base-currency / effective date per tenant
            builder.HasIndex(x => new { x.Tenant_ID, x.BaseCurrencyId, x.EffectiveDate })
                   .IsUnique()
                   .HasDatabaseName("UX_CurrencyExchangeRate_Tenant_BaseCurrency_EffectiveDate");

            // Relationship with Currency (base currency)
            builder.HasOne(x => x.Currency)
                   .WithMany()
                   .HasForeignKey(x => x.BaseCurrencyId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_CurrencyExchangeRateHeader_BaseCurrency_Currency");
        }
    }
}