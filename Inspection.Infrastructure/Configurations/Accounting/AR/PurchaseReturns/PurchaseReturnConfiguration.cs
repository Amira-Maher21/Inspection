using Inspection.Domain.Models.Accounting.AR.PurchaseReturns;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.AR.PurchaseReturns
{
    public class PurchaseReturnConfiguration : IEntityTypeConfiguration<PurchaseReturn>
    {
        public void Configure(EntityTypeBuilder<PurchaseReturn> builder)
        {
            builder.ToTable("PurchaseReturn", "Accounting");

            builder.HasKey(x => x.Id);

            // Unique
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.ReturnNumber })
                   .IsUnique();

            // Strings
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

            // Dates
            builder.Property(x => x.ReturnDate)
                   .IsRequired();

            // Amounts
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

            // Enums
            builder.Property(x => x.Posting)
                   .HasConversion<int>();

            builder.Property(x => x.ApprovalStatus)
                   .HasConversion<int>();

            builder.Property(x => x.AdditionalDiscountType)
                   .HasConversion<int>();

            builder.HasMany(x => x.PurchaseReturnAdjustments);

            // Relationships
            builder.HasOne(x => x.Branch)
                   .WithMany()
                   .HasForeignKey(x => x.BranchId)
                 .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.FiscalYear)
                   .WithMany()
                   .HasForeignKey(x => x.FiscalYearId)
                    .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.Supplier)
                   .WithMany()
                   .HasForeignKey(x => x.SupplierId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.Warehouse)
                   .WithMany()
                   .HasForeignKey(x => x.WarehouseId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.Currency)
                   .WithMany()
                   .HasForeignKey(x => x.CurrencyId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.PurchaseInvoice)
                   .WithMany()
                   .HasForeignKey(x => x.PurchaseInvoiceId)
                   .OnDelete(DeleteBehavior.Restrict);


            // Collections
            builder.HasMany(x => x.PurchaseReturnLines)
                   .WithOne(x => x.PurchaseReturn)
                   .HasForeignKey(x => x.PurchaseReturnId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.PurchaseReturnAdjustments)
                  .WithOne(x => x.PurchaseReturn)
                   .HasForeignKey(x => x.PurchaseReturnId)
                   .OnDelete(DeleteBehavior.Cascade);


            // ========================
            // Audit
            // ========================

            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                   .IsRequired();

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100);
        }
    }
}