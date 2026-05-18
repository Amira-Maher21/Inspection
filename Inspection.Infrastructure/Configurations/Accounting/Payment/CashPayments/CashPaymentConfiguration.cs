using Inspection.Domain.Models.Accounting.Payment.CashPayments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Payment.CashPayments
{
    public class CashPaymentConfiguration : IEntityTypeConfiguration<CashPayment>
    {
        public void Configure(EntityTypeBuilder<CashPayment> builder)
        {
            builder.ToTable("CashPayment", "Accounting");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Unique Index
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.ReceiptNumber }).IsUnique();

            // Properties
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.ReceiptNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ManualNumber).HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.ReceivedFrom).HasMaxLength(200);
            builder.Property(x => x.ReceiptDate).IsRequired();
            builder.Property(x => x.PostingDate).IsRequired();

            // Tax
            builder.Property(x => x.TaxPercent).HasPrecision(5, 2);
            builder.Property(x => x.TaxAmount).HasPrecision(18, 2);

            // Amount
            builder.Property(x => x.TotalAmount).IsRequired().HasPrecision(18, 2);

            // Enums
            builder.Property(x => x.Posting).IsRequired();
            builder.Property(x => x.ApprovalStatus).IsRequired();

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Relationships
            builder.Property(x => x.BranchId).IsRequired();
            builder.Property(x => x.FiscalYearId).IsRequired();
            builder.Property(x => x.AccountId).IsRequired();
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.CurrencyId).IsRequired();

            // Details
            builder.HasMany(x => x.CashPaymentLines)
                   .WithOne(x => x.CashPayment)
                   .HasForeignKey(x => x.CashPaymentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.CashPaymentAdjustments)
                   .WithOne(x => x.CashPayment)
                   .HasForeignKey(x => x.CashPaymentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.PurchaseInvoiceAllocations)
                   .WithOne(x => x.CashPayment)
                   .HasForeignKey(x => x.CashPaymentId)
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

            // ChartOfAccount
            builder.HasOne(x => x.ChartOfAccount)
                   .WithMany()
                   .HasForeignKey(x => x.AccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Customer
            builder.HasOne(x => x.Customer)
                   .WithMany()
                   .HasForeignKey(x => x.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Currency
            builder.HasOne(x => x.Currency)
                   .WithMany()
                   .HasForeignKey(x => x.CurrencyId)
                   .OnDelete(DeleteBehavior.Restrict);

            // TaxType (Optional)
            builder.HasOne(x => x.TaxType)
                   .WithMany()
                   .HasForeignKey(x => x.TaxTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Series
            builder.HasOne(x => x.Series)
                   .WithMany()
                   .HasForeignKey(x => x.SeriesId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}