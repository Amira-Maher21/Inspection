using Inspection.Domain.Models.Accounting.Payment.JonrnalEntrys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Payment.JournalEntrys
{
    public class JournalEntryConfigration : IEntityTypeConfiguration<JournalEntry>
    {
        public void Configure(EntityTypeBuilder<JournalEntry> builder)
        {
            builder.ToTable("JournalEntry", "Accounting");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.JournalNo }).IsUnique();

            builder.Property(x => x.Id);

            builder.Property(x => x.CompanyId)
                   .IsRequired();

            builder.Property(x => x.JournalNo)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.FiscalYearId)
                   .IsRequired();

            builder.Property(x => x.JournalDate)
                   .IsRequired();

            builder.Property(x => x.PostingDate)
                   .IsRequired();

            builder.Property(x => x.BranchId)
                   .IsRequired();

            builder.Property(x => x.CurrencyId)
                   .IsRequired();

            builder.Property(x => x.JournalEntryTemplateId)
                   .IsRequired(false);

            builder.Property(x => x.IsReverseJournal)
                   .IsRequired(false);

            builder.Property(x => x.ReversalOfJournalEntryId)
                   .IsRequired(false);

            builder.Property(x => x.TotalDebit)
                   .HasPrecision(18, 6)
                   .IsRequired();

            builder.Property(x => x.TotalCredit)
                   .HasPrecision(18, 6)
                   .IsRequired();

            builder.Property(x => x.ReferenceNumber)
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(x => x.ReferenceDate)
                   .IsRequired(false);


            builder.Property(x => x.DocumentStatus)
                   .IsRequired(false);

            builder.Property(x => x.ApprovalStatus)
                   .IsRequired(false);

            builder.Property(x => x.Description)
                   .HasMaxLength(500)
                   .IsRequired(false);

            builder.Property(x => x.Tenant_ID)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                   .IsRequired();

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(x => x.Mod_Date)
                   .IsRequired(false);

            builder.HasOne(x => x.FiscalYear)
                  .WithMany()
                  .HasForeignKey(x => x.FiscalYearId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Branch)
                   .WithMany()
                   .HasForeignKey(x => x.BranchId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Currency)
                   .WithMany()
                   .HasForeignKey(x => x.CurrencyId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.JournalEntryTemplate)
                   .WithMany()
                   .HasForeignKey(x => x.JournalEntryTemplateId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.SeriesId)
                       .IsRequired(false);

            builder.Property(x => x.RunningNumber)
                   .HasDefaultValue(1)
                   .IsRequired();

            builder.HasOne(x => x.Series)
                      .WithMany()
                      .HasForeignKey(x => x.SeriesId)
                      .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(x => x.JournalEntryLines)
                       .WithOne(x => x.JournalEntry)
                       .HasForeignKey(x => x.JournalEntryId)
                       .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ReversalOfJournalEntry)
               .WithMany()
               .HasForeignKey(x => x.ReversalOfJournalEntryId)
               .OnDelete(DeleteBehavior.Restrict);


            // Indexes


        }
    }
}