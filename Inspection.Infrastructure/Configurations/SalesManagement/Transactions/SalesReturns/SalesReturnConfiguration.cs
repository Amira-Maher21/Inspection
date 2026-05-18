using Inspection.Domain.Models.SalesManagment.Transaction.SalesReturns;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.SalesManagement.Transactions.SalesReturns
{
    public class SalesReturnConfiguration : IEntityTypeConfiguration<SalesReturn>
    {
        public void Configure(EntityTypeBuilder<SalesReturn> builder)
        {
            builder.ToTable("SalesReturn", "Sales");

            builder.HasKey(x => x.Id);

            // ======================
            // Unique Constraint
            // ======================
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.ReturnNumber })
                   .IsUnique();

            // ======================
            // Strings
            // ======================
            builder.Property(x => x.Tenant_ID)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.ReturnNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Description)
                   .HasMaxLength(500);

            builder.Property(x => x.ReturnReason)
                   .HasMaxLength(500);

            // ======================
            // Dates
            // ======================
            builder.Property(x => x.ReturnDate)
                   .IsRequired();

            // ======================
            // Amounts
            // ======================
            builder.Property(x => x.NetAmount)
                   .HasPrecision(18, 6);

            builder.Property(x => x.TotalAmount)
                   .HasPrecision(18, 6);

            builder.Property(x => x.TaxAmount)
                   .HasPrecision(18, 6);

            builder.Property(x => x.AdditionalDiscountValue)
                   .HasPrecision(18, 6);

            builder.Property(x => x.AdditionalDiscountAmount)
                   .HasPrecision(18, 6);

            builder.Property(x => x.TotalDiscount)
                   .HasPrecision(18, 6);

            // ======================
            // Enums
            // ======================
            builder.Property(x => x.Posting)
                   .HasConversion<int>();

            builder.Property(x => x.ApprovalStatus)
                   .HasConversion<int>();

            builder.Property(x => x.AdditionalDiscountType)
                   .HasConversion<int>();

            // ======================
            // Relationships (IMPORTANT → Restrict)
            // ======================

            builder.HasOne(x => x.Branch)
                   .WithMany()
                   .HasForeignKey(x => x.BranchId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.FiscalYear)
                   .WithMany()
                   .HasForeignKey(x => x.FiscalYearId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SalesInvoice)
                   .WithMany()
                   .HasForeignKey(x => x.SalesInvoiceId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Customer)
                   .WithMany()
                   .HasForeignKey(x => x.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ChartOfAccount)
                   .WithMany()
                   .HasForeignKey(x => x.ChartOfAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Warehouse)
                   .WithMany()
                   .HasForeignKey(x => x.WarehouseId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Currency)
                   .WithMany()
                   .HasForeignKey(x => x.CurrencyId)
                   .OnDelete(DeleteBehavior.Restrict);

            // ======================
            // Collections
            // ======================

            builder.HasMany(x => x.SalesReturnLines)
                   .WithOne(x => x.SalesReturn)
                   .HasForeignKey(x => x.SalesReturnId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.SalesReturnAdjustments)
                   .WithOne(x => x.SalesReturn)
                   .HasForeignKey(x => x.SalesReturnId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}