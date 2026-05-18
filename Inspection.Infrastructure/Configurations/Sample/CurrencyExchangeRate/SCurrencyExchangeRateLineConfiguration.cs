using Inspection.Domain.Models.Sample.CurrencyExchangeRate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Sample.CurrencyExchangeRate
{
    internal class SCurrencyExchangeRateLineConfiguration : IEntityTypeConfiguration<SCurrencyExchangeRateLine>
    {
        public void Configure(EntityTypeBuilder<SCurrencyExchangeRateLine> builder)
        {
            builder.ToTable("CurrencyExchangeRateLine", "Accounting");

            builder.HasKey(x => x.Id).HasName("PK_CurrencyExchangeRateLine");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CurrencyExchangHeaderId).IsRequired();
            builder.Property(x => x.TargetCurrencyId).IsRequired();

            // Rate must be positive and choose a reasonable precision/scale
            builder.Property(x => x.Rate)
                   .HasColumnType("decimal(18,6)")
                   .IsRequired();

            // Check → Rate > 0

            builder.ToTable(t => t.HasCheckConstraint(
             "CK_CurrencyExchangeRateLine_Rate_Positive",
             "[Rate] > 0"
             ));

            // Auditable properties
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Prevent duplicate details for same target currency under same master
            builder.HasIndex(x => new { x.CurrencyExchangHeaderId, x.TargetCurrencyId })
                   .IsUnique()
                   .HasDatabaseName("UX_CurrencyExchangeRateLine_Header_TargetCurrency");

            // Relationship with Currency (Target currency)
            builder.HasOne(x => x.Currency)
                   .WithMany()
                   .HasForeignKey(x => x.TargetCurrencyId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_CurrencyExchangeRateHeader_TargetCurrencyId_Currency");

            // Relationship to header
            builder.HasOne<SCurrencyExchangeRateHeader>()
                   .WithMany(h => h.Lines)
                   .HasForeignKey(x => x.CurrencyExchangHeaderId)
                   .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CurrencyExchangeRateLines_Header_CurrencyExchangeRates");
        }
    }
}