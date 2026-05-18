using Inspection.Domain.Models.Accounting.AR.MasterData;
using Inspection.Domain.Models.Inventory.Ledger;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Infrastructure.Configurations.Inventory.LedgerConfig
{
    public class LedgerConfig : IEntityTypeConfiguration<Ledger>
    {
        public void Configure(EntityTypeBuilder<Ledger> builder)
        {
            builder.ToTable("Ledger", "Accounting");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Tenant_ID);

            // ========================
            // Money Precision
            // ========================
            builder.Property(x => x.TotalDebit)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(x => x.TotalCredit)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(x => x.ExchangeRate)
                   .HasColumnType("decimal(18,6)")
                   .IsRequired();

            builder.Property(x => x.ExchangeRateOfficialCurrency)
                     .HasColumnType("decimal(18,6)")
                     .IsRequired();

            builder.Property(x => x.ExchangeRateReportingCurrency)
                        .HasColumnType("decimal(18,6)")
                        .IsRequired();

            // ========================
            // Dates
            // ========================
            builder.Property(x => x.PostingDate)
                   .HasColumnType("datetime2")
                   .IsRequired();

            builder.Property(x => x.PostedDate)
                   .HasColumnType("datetime2")
                   .IsRequired();

            // ========================
            // Relationships
            // ========================

            builder.HasOne(x => x.PostingDocumentType)
                   .WithMany()
                   .HasForeignKey(x => x.PostingDocumentTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Currency)
                   .WithMany()
                   .HasForeignKey(x => x.CurrencyId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Branch)
                   .WithMany()
                   .HasForeignKey(x => x.BranchId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.LedgerLines)
                   .WithOne(x => x.Ledger)
                   .HasForeignKey(x => x.LedgerId)
                   .OnDelete(DeleteBehavior.Cascade);

            // ========================
            // Accounting Constraints
            // ========================

            //builder.HasCheckConstraint(
            //    "CK_Ledger_Balance",
            //    "[TotalDebit] = [TotalCredit]"
            //);

            // ========================
            // Performance Indexes
            // ========================

            builder.HasIndex(x => x.PostingDate);
            builder.HasIndex(x => x.JournalEntryId);
            builder.HasIndex(x => new { x.CompanyId, x.BranchId });
        }
    }
}
