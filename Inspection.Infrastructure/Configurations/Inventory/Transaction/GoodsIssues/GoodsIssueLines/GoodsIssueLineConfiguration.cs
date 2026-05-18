using Inspection.Domain.Models.Inventory.Transaction.GoodsIssues.GoodsIssueLines;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.Transaction.GoodsIssues.GoodsIssueLines
{
    public class GoodsIssueLineConfiguration : IEntityTypeConfiguration<GoodsIssueLine>
    {
        public void Configure(EntityTypeBuilder<GoodsIssueLine> builder)
        {
            builder.ToTable("GoodsIssueLine", "Inventory");

            builder.HasKey(x => x.Id);

            // ================= Properties =================

            builder.Property(x => x.Quantity)
                .IsRequired()
                .HasPrecision(18, 6);

            builder.Property(x => x.Cost)
                .HasPrecision(18, 6);

            builder.Property(x => x.Notes)
                .HasMaxLength(500);

            builder.Property(x => x.FreeItem);

            // ================= Audit =================

            builder.Property(x => x.In_User)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                .IsRequired();

            builder.Property(x => x.Mod_User)
                .HasMaxLength(100);

            builder.Property(x => x.Mod_Date);

            // ================= Relations =================

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



            builder.HasOne(x => x.GoodsIssue)
                .WithMany(x => x.GoodsIssueLines)
                .HasForeignKey(x => x.GoodsIssueId)
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
                .IsRequired(false)
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

            // ================= Index =================

            builder.HasIndex(x => new { x.GoodsIssueId, x.ItemId, x.WarehouseLocationId })
                .HasDatabaseName("IX_GoodsIssueLine_Main");
        }
    }
}