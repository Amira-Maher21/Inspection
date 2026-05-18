using Inspection.Domain.Models.Inventory.Transaction.GoodsTransferOuts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.Transaction.GoodsTransferOuts
{
    public class GoodsTransferOutLineConfiguration : IEntityTypeConfiguration<GoodsTransferOutLine>
    {
        public void Configure(EntityTypeBuilder<GoodsTransferOutLine> builder)
        {
            builder.ToTable("GoodsTransferOutLine", "Inventory");

            // Primary Key
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.GoodsTransferOutId);

            // Properties
            builder.Property(x => x.Quantity).IsRequired().HasPrecision(18, 6);
            builder.Property(x => x.Cost).HasPrecision(18, 6);
            builder.Property(x => x.FreeItem).IsRequired();
            builder.Property(x => x.Notes).HasMaxLength(250);

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Required FKs
            builder.Property(x => x.GoodsTransferOutId).IsRequired();
            builder.Property(x => x.ItemId).IsRequired();
            builder.Property(x => x.UnitOfMeasureId).IsRequired();

            // Optional FKs
            builder.Property(x => x.WareHouseId).IsRequired(false);
            builder.Property(x => x.CostCenterId).IsRequired(false);
            builder.Property(x => x.CostUnitId).IsRequired(false);
            builder.Property(x => x.OperationId).IsRequired(false);
            builder.Property(x => x.WarehouseLocationId).IsRequired(false);

            // Relationships

            // Parent
            builder.HasOne(x => x.GoodsTransferOut)
                   .WithMany(x => x.GoodsTransferOutLines)
                   .HasForeignKey(x => x.GoodsTransferOutId);

            // Item
            builder.HasOne(x => x.Item)
                   .WithMany()
                   .HasForeignKey(x => x.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Unit Of Measure
            builder.HasOne(x => x.UnitOfMeasure)
                   .WithMany()
                   .HasForeignKey(x => x.UnitOfMeasureId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Warehouse (Optional)
            builder.HasOne(x => x.WareHouse)
                   .WithMany()
                   .HasForeignKey(x => x.WareHouseId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Cost Center (Optional)
            builder.HasOne(x => x.CostCenter)
                   .WithMany()
                   .HasForeignKey(x => x.CostCenterId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Cost Unit (Optional)
            builder.HasOne(x => x.CostUnit)
                   .WithMany()
                   .HasForeignKey(x => x.CostUnitId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Operation (Optional)
            builder.HasOne(x => x.Operation)
                   .WithMany()
                   .HasForeignKey(x => x.OperationId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Location (WarehouseLocation)
            builder.HasOne(x => x.WarehouseLocation)
                   .WithMany()
                   .HasForeignKey(x => x.WarehouseLocationId)
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