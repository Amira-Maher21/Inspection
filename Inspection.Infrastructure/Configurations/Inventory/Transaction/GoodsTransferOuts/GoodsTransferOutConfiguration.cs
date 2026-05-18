using Inspection.Domain.Models.Inventory.Transaction.GoodsTransferOuts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.Transaction.GoodsTransferOuts
{
    public class GoodsTransferOutConfiguration : IEntityTypeConfiguration<GoodsTransferOut>
    {
        public void Configure(EntityTypeBuilder<GoodsTransferOut> builder)
        {
            builder.ToTable("GoodsTransferOut", "Inventory");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Unique Index
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.GoodsTransferOutNumber }).IsUnique();

            // Properties
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.GoodsTransferOutNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.GoodsTransferOutDate).IsRequired();
            builder.Property(x => x.Notes).HasMaxLength(500);

            // Enums
            builder.Property(x => x.Posting).IsRequired();
            builder.Property(x => x.ApprovalStatus).IsRequired();

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Relations (FKs Required)
            builder.Property(x => x.BranchId).IsRequired();
            builder.Property(x => x.WareHouseFromId).IsRequired();

            // Optional FK
            builder.Property(x => x.WareHouseId).IsRequired(false);

            // Relationships

            // Branch
            builder.HasOne(x => x.Branch)
                   .WithMany()
                   .HasForeignKey(x => x.BranchId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Warehouse From
            builder.HasOne(x => x.WareHouseFrom)
                   .WithMany()
                   .HasForeignKey(x => x.WareHouseFromId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Warehouse To (Optional)
            builder.HasOne(x => x.WareHouse)
                   .WithMany()
                   .HasForeignKey(x => x.WareHouseId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Series
            builder.HasOne(x => x.Series)
                   .WithMany()
                   .HasForeignKey(x => x.SeriesId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Details

            builder.HasMany(x => x.GoodsTransferOutLines)
                   .WithOne(x => x.GoodsTransferOut)
                   .HasForeignKey(x => x.GoodsTransferOutId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}