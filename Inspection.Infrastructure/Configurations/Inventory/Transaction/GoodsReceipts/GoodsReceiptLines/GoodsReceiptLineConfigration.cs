using Inspection.Domain.Models.Inventory.Transaction.GoodsReceipts.GoodsReceiptLines;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.Transaction.GoodsReceipts.GoodsReceiptLines
{
    public class GoodsReceiptLineConfigration : IEntityTypeConfiguration<GoodsReceiptLine>
    {


        public void Configure(EntityTypeBuilder<GoodsReceiptLine> builder)
        {
            builder.ToTable("GoodsReceiptLine", "Inventory");

            builder.HasKey(x => x.Id);

            // ================= Properties =================
            builder.Property(x => x.Quantity)
                .IsRequired()
                .HasColumnType("decimal(18,6)");

            builder.Property(x => x.Cost)
                .IsRequired()
                .HasColumnType("decimal(18,6)");

            builder.Property(x => x.TotalCost)
                .IsRequired()
                .HasColumnType("decimal(18,6)");

            builder.Property(x => x.FreeItem);

            builder.Property(x => x.Notes)
                .HasMaxLength(500);

            // ================= Relations =================

            builder.HasOne(x => x.GoodsReceipt)
                .WithMany(gr => gr.GoodsReceiptLines)
                .HasForeignKey(x => x.GoodsReceiptId)
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
                .IsRequired(false)
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


            builder.Property(x => x.In_User)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                .IsRequired();

            builder.Property(x => x.Mod_User)
                .HasMaxLength(100);

            builder.Property(x => x.Mod_Date);
            // ================= Index =================

            builder.HasIndex(x => new { x.GoodsReceiptId, x.ItemId, x.WarehouseLocationId })
                    .IsUnique();
        }
    }
}