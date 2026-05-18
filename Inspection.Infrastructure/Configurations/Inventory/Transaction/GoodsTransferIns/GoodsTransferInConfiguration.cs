using Inspection.Domain.Models.Inventory.Transaction.GoodsTransferIns;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.Transaction.GoodsTransferIns
{
    public class GoodsTransferInConfiguration : IEntityTypeConfiguration<GoodsTransferIn>
    {
        public void Configure(EntityTypeBuilder<GoodsTransferIn> builder)
        {
            builder.ToTable("GoodsTransferIn", "Inventory");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Unique Index
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.GoodsTransferInNumber }).IsUnique();

            // Properties
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.GoodsTransferInNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.GoodsTransferInDate).IsRequired();
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
            builder.Property(x => x.GoodsTransferOutId).IsRequired();

            // Optional FK
            builder.Property(x => x.WareHouseId).IsRequired(false);

            // Relationships

            // Branch
            builder.HasOne(x => x.Branch)
                   .WithMany()
                   .HasForeignKey(x => x.BranchId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Warehouse From
            builder.HasOne(x => x.GoodsTransferOut)
                   .WithMany()
                   .HasForeignKey(x => x.GoodsTransferOutId)
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

            builder.HasMany(x => x.GoodsTransferInLines)
                   .WithOne(x => x.GoodsTransferIn)
                   .HasForeignKey(x => x.GoodsTransferInId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}