using Inspection.Domain.Models.Accounting.Payment.JournalEntryTemplates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Payment.JournalEntryTemplates
{
    public class JournalEntryTemplateConfigration
        : IEntityTypeConfiguration<JournalEntryTemplate>
    {
        public void Configure(EntityTypeBuilder<JournalEntryTemplate> builder)
        {
            builder.ToTable("JournalEntryTemplate", "Accounting");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tenant_ID).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CurrencyId).IsRequired();
            builder.Property(x => x.TotalDebit).HasPrecision(18, 6).IsRequired();
            builder.Property(x => x.TotalCredit).HasPrecision(18, 6).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired(false);
            builder.Property(x => x.SeriesId).IsRequired(false);
            builder.Property(x => x.RunningNumber).IsRequired();

            // Details
            builder.HasMany(x => x.JournalEntryTemplateLines)
                   .WithOne(x => x.JournalEntryTemplate)
                   .HasForeignKey(x => x.JournalEntryTemplateId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Currency
            builder.HasOne(x => x.Currency)
                   .WithMany()
                   .HasForeignKey(x => x.CurrencyId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Series)
                    .WithMany()
                    .HasForeignKey(x => x.SeriesId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.Mod_Date).IsRequired(false);
        }
    }
}