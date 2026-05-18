using Inspection.Domain.Models.Accounting.PR.PurchaseInvoices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.PR.PurchaseInvoices
{
    public class PurchaseInvoiceConfiguration : IEntityTypeConfiguration<PurchaseInvoice>
    {
        public void Configure(EntityTypeBuilder<PurchaseInvoice> builder)
        {
            builder.ToTable("PurchaseInvoice", "Accounting");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Indexes

            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.InvoiceNo })
                   .IsUnique();

            // Properties
            builder.Property(x => x.Tenant_ID)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.CompanyId)
                   .IsRequired();

            builder.Property(x => x.BranchId)
                   .IsRequired();

            builder.Property(x => x.InvoiceNo)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.InvoiceDate)
                   .IsRequired();

            builder.Property(x => x.PaymentDueDate)
                   .IsRequired();

            builder.Property(x => x.RunningNumber)
                   .IsRequired();

            // Amounts
            builder.Property(x => x.TotalAmount)
                   .IsRequired()
                   .HasPrecision(18, 6);

            builder.Property(x => x.NetAmount)
                   .IsRequired()
                   .HasPrecision(18, 6);

            builder.Property(x => x.TaxAmount)
                   .HasPrecision(18, 6);

            builder.Property(x => x.AdditionalDiscountValue)
                   .HasPrecision(18, 6);

            builder.Property(x => x.AdditionalDiscountAmount)
                   .HasPrecision(18, 6);

            builder.Property(x => x.TotalDiscount)
                   .HasPrecision(18, 6);

            builder.Property(x => x.ShipmentAmount)
                   .HasPrecision(18, 6);

            builder.Property(x => x.Notes)
                   .HasMaxLength(500);

            builder.Property(x => x.ShipmentAddress)
                   .HasMaxLength(500);

            // Enums
            builder.Property(x => x.Posting)
                   .HasConversion<int>();

            builder.Property(x => x.AdditionalDiscountType)
                   .HasConversion<int>();

            builder.Property(x => x.ShipmentStatus)
                   .HasConversion<int>();

            builder.Property(x => x.ShipmentMethod)
                   .HasConversion<int>();

            builder.Property(x => x.ApprovalStatus)
                   .IsRequired()
                   .HasConversion<int>();

            builder.Property(x => x.Status)
                   .IsRequired()
                   .HasConversion<int>();

            // Audit
            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                   .IsRequired();

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100);

            builder.Property(x => x.Mod_Date);

            // Relationships
            builder.HasOne(x => x.Branch)
                   .WithMany()
                   .HasForeignKey(x => x.BranchId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Warehouse)
                   .WithMany()
                   .HasForeignKey(x => x.WarehouseId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Supplier)
                   .WithMany()
                   .HasForeignKey(x => x.SupplierId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SalesOrder)
                   .WithMany()
                   .HasForeignKey(x => x.SalesOrderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SalesPerson)
                   .WithMany()
                   .HasForeignKey(x => x.SalesPersonId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Currency)
                   .WithMany()
                   .HasForeignKey(x => x.CurrencyId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.PaymentTerm)
                   .WithMany()
                   .HasForeignKey(x => x.PaymentTermId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Series)
                   .WithMany()
                   .HasForeignKey(x => x.SeriesId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Collections

            builder.HasMany(x => x.InvoiceLines)
                   .WithOne(x => x.PurchaseInvoice)
                   .HasForeignKey(x => x.PurchaseInvoiceId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(x => x.Adjustments)
                   .WithOne(x => x.PurchaseInvoice)
                   .HasForeignKey(x => x.PurchaseInvoiceId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}