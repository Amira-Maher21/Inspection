using Inspection.Domain.Models.Accounting.Payment.CreditNotes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Payment.CreditNotes
{
    public class CreditNoteConfiguration : IEntityTypeConfiguration<CreditNote>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<CreditNote> builder)
        {
            builder.ToTable("CreditNote", "Accounting");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Unique Index
            // (Tenant + Company + CreditNoteNumber)
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.CreditNoteNumber }).IsUnique();

            // Properties
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.CreditNoteNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.CreditNoteDate).IsRequired();

            //  Discount
            builder.Property(x => x.AdditionalDiscountValue).HasPrecision(18, 2);
            builder.Property(x => x.AdditionalDiscountAmount).HasPrecision(18, 2);
            builder.Property(x => x.TotalDiscount).HasPrecision(18, 2);

            // Tax
            builder.Property(x => x.TaxAmount).HasPrecision(18, 2);

            // Total
            builder.Property(x => x.TotalAmount).IsRequired().HasPrecision(18, 2);

            // Enums
            builder.Property(x => x.Posting).IsRequired();
            builder.Property(x => x.AdditionalDiscountType);

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Required Relationships
            builder.Property(x => x.BranchId).IsRequired();
            builder.Property(x => x.FiscalYearId).IsRequired();
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.ChartOfAccountId).IsRequired();
            builder.Property(x => x.CurrencyId).IsRequired();

            // Optional Relationships
            builder.Property(x => x.SalesInvoiceId).IsRequired(false);

            // Relationships

            // Details
            builder.HasMany(x => x.CreditNoteLines)
                   .WithOne(x => x.CreditNote)
                   .HasForeignKey(x => x.CreditNoteId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.CreditNoteAdjustments)
                   .WithOne(x => x.CreditNote)
                   .HasForeignKey(x => x.CreditNoteId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Branch
            builder.HasOne(x => x.Branch)
                   .WithMany()
                   .HasForeignKey(x => x.BranchId)
                   .OnDelete(DeleteBehavior.Restrict);

            // FiscalYear
            builder.HasOne(x => x.FiscalYear)
                   .WithMany()
                   .HasForeignKey(x => x.FiscalYearId)
                   .OnDelete(DeleteBehavior.Restrict);

            // SalesInvoice (Optional)
            builder.HasOne(x => x.SalesInvoice)
                   .WithMany()
                   .HasForeignKey(x => x.SalesInvoiceId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Customer
            builder.HasOne(x => x.Customer)
                   .WithMany()
                   .HasForeignKey(x => x.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);

            // ChartOfAccount
            builder.HasOne(x => x.Account)
                   .WithMany()
                   .HasForeignKey(x => x.ChartOfAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Currency
            builder.HasOne(x => x.Currency)
                   .WithMany()
                   .HasForeignKey(x => x.CurrencyId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Series
            builder.HasOne(x => x.Series)
                   .WithMany()
                   .HasForeignKey(x => x.SeriesId)
                   .OnDelete(DeleteBehavior.Restrict);

            // CHECK CONSTRAINTS (Recommended)

            // Posting values
            builder.HasCheckConstraint(
                "CK_CreditNote_Posting",
                "[Posting] IN (1,2,3)"
            );

            // TotalAmount >= 0
            builder.HasCheckConstraint(
                "CK_CreditNote_TotalAmount",
                "[TotalAmount] >= 0"
            );
        }
    }
}