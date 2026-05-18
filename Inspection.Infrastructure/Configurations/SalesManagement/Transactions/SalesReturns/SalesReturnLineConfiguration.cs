using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.SalesManagement.Transactions.SalesReturns
{
    public class SalesReturnLineConfiguration : IEntityTypeConfiguration<SalesReturnLine>
    {
        public void Configure(EntityTypeBuilder<SalesReturnLine> builder)
        {
            builder.ToTable("SalesReturnLine", "Sales");

            builder.HasKey(x => x.Id);

            // Strings
            builder.Property(x => x.Description)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(x => x.BatchNumber)
                   .HasMaxLength(100);

            builder.Property(x => x.SerialNumber)
                   .HasMaxLength(100);

            builder.Property(x => x.Notes)
                   .HasMaxLength(500);

            // Quantities
            builder.Property(x => x.InvoicedQty)
                   .HasPrecision(18, 4);

            builder.Property(x => x.PreviousReturnedQty)
                   .HasPrecision(18, 4);

            builder.Property(x => x.ReturnedQty)
                   .HasPrecision(18, 4);

            // Prices
            builder.Property(x => x.UnitPrice)
                   .HasPrecision(18, 4);

            builder.Property(x => x.Cost)
                   .HasPrecision(18, 4);

            builder.Property(x => x.TotalCost)
                   .HasPrecision(18, 2);

            builder.Property(x => x.NetAmount)
                   .HasPrecision(18, 2);

            // Tax
            builder.Property(x => x.TaxRate)
                   .HasPrecision(5, 2);

            builder.Property(x => x.TaxAmount)
                   .HasPrecision(18, 6);

            // Discount
            builder.Property(x => x.DiscountValue)
                   .HasPrecision(18, 6);

            builder.Property(x => x.DiscountAmount)
                   .HasPrecision(18, 6);

            // Enum
            builder.Property(x => x.DiscountType)
                   .HasConversion<int>();

            builder.Property(x => x.Condition)
                   .HasConversion<int>();

            builder.Property(x => x.IsInclusive)
                   .IsRequired();

            builder.Property(x => x.LineType)
                   .HasConversion<int>();

            builder.Property(x => x.AssetTransactionType)
                   .HasConversion<int>();

            // Relationships
            builder.HasOne(x => x.FixedAsset)
                   .WithMany()
                   .HasForeignKey(x => x.AssetId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SalesReturn)
                   .WithMany()
                   .HasForeignKey(x => x.SalesReturnId);

            builder.HasOne(x => x.SalesInvoiceLine)
                   .WithMany()
                   .HasForeignKey(x => x.SalesInvoiceLineId)
                   .OnDelete(DeleteBehavior.Restrict);

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
            // Audit

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