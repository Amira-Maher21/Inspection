using Inspection.Domain.Models.Accounting.PR.PurchaseInvoices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.PR.PurchaseInvoices
{
    public class PurchaseInvoiceLineConfiguration : IEntityTypeConfiguration<PurchaseInvoiceLine>
    {
        public void Configure(EntityTypeBuilder<PurchaseInvoiceLine> builder)
        {
            builder.ToTable("PurchaseInvoiceLine", "Accounting");

            // ========================
            // Primary Key
            // ========================
            builder.HasKey(x => x.Id);

            // ========================
            // Indexes
            // ========================
            builder.HasIndex(x => x.PurchaseInvoiceId);

            // ========================
            // Properties
            // ========================

            builder.Property(x => x.UnitOfMeasureId)
                   .IsRequired();

            builder.Property(x => x.Quantity)
                   .IsRequired()
                   .HasPrecision(18, 6);

            builder.Property(x => x.UnitPrice)
                   .IsRequired()
                   .HasPrecision(18, 6);

            builder.Property(x => x.TotalPrice)
                   .IsRequired()
                   .HasPrecision(18, 6);

            builder.Property(x => x.Cost)
                   .HasPrecision(18, 6);

            builder.Property(x => x.TaxRate)
                   .HasPrecision(5, 2);

            builder.Property(x => x.TaxAmount)
                   .HasPrecision(18, 6);

            builder.Property(x => x.DiscountValue)
                   .HasPrecision(18, 6);

            builder.Property(x => x.DiscountAmount)
                   .HasPrecision(18, 6);

            builder.Property(x => x.Notes)
                   .IsRequired()
                   .HasMaxLength(250);

            // ========================
            // Enums
            // ========================
            builder.Property(x => x.DiscountType)
                   .HasConversion<int>();

            builder.Property(x => x.LineType)
                   .HasConversion<int>();

            builder.Property(x => x.AssetTransactionType)
                   .HasConversion<int>();

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

            builder.Property(x => x.Mod_Date);

            // ========================
            // Relationships
            // ========================
            builder.HasOne(x => x.FixedAsset)
                   .WithMany()
                   .HasForeignKey(x => x.AssetId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.WBS)
                   .WithMany()
                   .HasForeignKey(x => x.WBSId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Activity)
                   .WithMany()
                   .HasForeignKey(x => x.ActivityId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CostCode)
                   .WithMany()
                   .HasForeignKey(x => x.CostCodeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SubcontractBOQ)
                   .WithMany()
                   .HasForeignKey(x => x.SubcontractBOQId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ProductionOrder)
                   .WithMany()
                   .HasForeignKey(x => x.ProductionOrderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.BOQLine)
                   .WithMany()
                   .HasForeignKey(x => x.BOQLineId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.PurchaseInvoice)
                   .WithMany(x => x.InvoiceLines)
                   .HasForeignKey(x => x.PurchaseInvoiceId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Item)
                   .WithMany()
                   .HasForeignKey(x => x.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.UnitOfMeasure)
                   .WithMany()
                   .HasForeignKey(x => x.UnitOfMeasureId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Warehouse)
                   .WithMany()
                   .HasForeignKey(x => x.WarehouseId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.WarehouseLocation)
                   .WithMany()
                   .HasForeignKey(x => x.WarehouseLocationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.TaxType)
                   .WithMany()
                   .HasForeignKey(x => x.TaxTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CostCenter)
                   .WithMany()
                   .HasForeignKey(x => x.CostCenterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CostUnit)
                   .WithMany()
                   .HasForeignKey(x => x.CostUnitId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Operation)
                   .WithMany()
                   .HasForeignKey(x => x.OperationId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}