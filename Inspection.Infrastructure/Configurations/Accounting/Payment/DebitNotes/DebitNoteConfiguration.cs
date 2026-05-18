using Inspection.Domain.Models.Accounting.Payment.DebitNotes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Payment.DebitNotes
{
    public class DebitNoteConfiguration : IEntityTypeConfiguration<DebitNote>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<DebitNote> builder)
        {
            builder.ToTable("DebitNote", "Accounting");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Unique Index (Tenant + Company + DebitNoteNumber)
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.DebitNoteNumber }).IsUnique();

            // Properties

            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.DebitNoteNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.DebitNoteDate).IsRequired();

            // Tax
            builder.Property(x => x.TaxAmount).HasPrecision(18, 2);

            // Total
            builder.Property(x => x.TotalAmount).IsRequired().HasPrecision(18, 2);

            // Discount
            builder.Property(x => x.AdditionalDiscountValue).HasPrecision(18, 2);
            builder.Property(x => x.AdditionalDiscountAmount).HasPrecision(18, 2);
            builder.Property(x => x.TotalDiscount).HasPrecision(18, 2);

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

            // Optional
            builder.Property(x => x.SalesInvoiceId).IsRequired(false);
            builder.Property(x => x.SeriesId).IsRequired(false);

            // Relationships

            // Lines
            builder.HasMany(x => x.DebitNoteLines)
                   .WithOne(x => x.DebitNote)
                   .HasForeignKey(x => x.DebitNoteId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Adjustments
            builder.HasMany(x => x.DebitNoteAdjustments)
                   .WithOne(x => x.DebitNote)
                   .HasForeignKey(x => x.DebitNoteId)
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

            // Account
            builder.HasOne(x => x.ChartOfAccount)
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

            // CHECK CONSTRAINTS

            // Posting values
            builder.HasCheckConstraint(
                "CK_DebitNote_Posting",
                "[Posting] IN (1,2,3)"
            );

            // TotalAmount >= 0
            builder.HasCheckConstraint(
                "CK_DebitNote_TotalAmount",
                "[TotalAmount] >= 0"
            );
        }
    }
}