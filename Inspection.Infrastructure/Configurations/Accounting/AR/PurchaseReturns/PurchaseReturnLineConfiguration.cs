using Inspection.Domain.Models.Accounting.AR.PurchaseReturns.PurchaseReturnLines;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.AR.PurchaseReturns
{
    public class PurchaseReturnLineConfiguration : IEntityTypeConfiguration<PurchaseReturnLine>
    {
        public void Configure(EntityTypeBuilder<PurchaseReturnLine> builder)
        {
            builder.ToTable("PurchaseReturnLine", "Accounting");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.BatchNumber)
                   .HasMaxLength(100);

            builder.Property(x => x.SerialNumber)
                   .HasMaxLength(100);

            builder.Property(x => x.ReturnedQty)
                   .HasPrecision(18, 4);

            builder.Property(x => x.UnitPrice)
                   .HasPrecision(18, 4);

            builder.Property(x => x.Cost)
                   .HasPrecision(18, 4);

            builder.Property(x => x.TotalCost)
                   .HasPrecision(18, 2);

            builder.Property(x => x.NetAmount)
                   .HasPrecision(18, 2);

            builder.Property(x => x.TaxRate)
                   .HasPrecision(5, 2);

            builder.Property(x => x.TaxAmount)
                   .HasPrecision(18, 6);

            builder.Property(x => x.DiscountValue)
                   .HasPrecision(18, 6);

            builder.Property(x => x.DiscountAmount)
                   .HasPrecision(18, 6);

            builder.Property(x => x.Condition)
                   .HasConversion<int>();

            builder.Property(x => x.IsInclusive)
                   .IsRequired();

            builder.Property(x => x.Description)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(x => x.DiscountType)
                   .HasConversion<int>();

            builder.Property(x => x.LineType)
                   .HasConversion<int>();

            builder.Property(x => x.AssetTransactionType)
                   .HasConversion<int>();

            // Relationships
            builder.HasOne(x => x.FixedAsset)
                   .WithMany()
                   .HasForeignKey(x => x.AssetId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.PurchaseInvoiceLine)
                   .WithMany()
                   .HasForeignKey(x => x.PurchaseInvoiceLineId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.PurchaseReturn)
                   .WithMany()
                   .HasForeignKey(x => x.PurchaseReturnId);

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

            builder.HasOne(x => x.CostCenter)
                   .WithMany()
                   .HasForeignKey(x => x.CostCenterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CostUnit)
                   .WithMany()
                   .HasForeignKey(x => x.CostUnitId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.TaxType)
                   .WithMany()
                   .HasForeignKey(x => x.TaxTypeId)
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
        }
    }
}