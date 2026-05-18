using Inspection.Domain.Models.Inventory.Transaction.GoodsReceipts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.Transaction.GoodsReceipts
{
    public class GoodsReceiptConfigration : IEntityTypeConfiguration<GoodsReceipt>
    {
        public void Configure(EntityTypeBuilder<GoodsReceipt> builder)
        {
            builder.ToTable("GoodsReceipt", "Inventory");

            builder.HasKey(x => x.Id);

            // ================= Properties =================

            builder.Property(x => x.GoodsReceiptNo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Tenant_ID)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.CompanyId)
                .IsRequired();

            builder.Property(x => x.GoodsReceiptDate)
                .IsRequired();

            builder.Property(x => x.Notes)
                .HasMaxLength(500);

            builder.Property(x => x.Posting)
                 .HasConversion<int>();

            // ================= Relations =================

            builder.HasOne(x => x.Branch)
                .WithMany()
                .HasForeignKey(x => x.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Warehouse)
                .WithMany()
                .HasForeignKey(x => x.WarehouseId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.GoodsReceiptLines)
                .WithOne(x => x.GoodsReceipt)
                .HasForeignKey(x => x.GoodsReceiptId)
                .OnDelete(DeleteBehavior.Cascade);





            builder.Property(x => x.In_User)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                .IsRequired();

            builder.Property(x => x.Mod_User)
                .HasMaxLength(100);

            builder.Property(x => x.Mod_Date);
            // ================= Index =================

            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.GoodsReceiptNo })
                 .IsUnique();


        }
    }
}