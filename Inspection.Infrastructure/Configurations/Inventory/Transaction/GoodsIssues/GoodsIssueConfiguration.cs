using Inspection.Domain.Models.Inventory.Transaction.GoodsIssues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.Transaction.GoodsIssues
{
    public class GoodsIssueConfiguration : IEntityTypeConfiguration<GoodsIssue>
    {
        public void Configure(EntityTypeBuilder<GoodsIssue> builder)
        {
            builder.ToTable("GoodsIssue", "Inventory");

            builder.HasKey(x => x.Id);

            // ================= Properties =================

            builder.Property(x => x.GoodsIssueNo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Tenant_ID)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.CompanyId)
                .IsRequired();

            builder.Property(x => x.GoodsIssueDate)
                .IsRequired();

            builder.Property(x => x.Notes)
                .HasMaxLength(500);

            builder.Property(x => x.RunningNumber)
                .IsRequired();

            // ================= Enums =================

            builder.Property(x => x.Posting)
                .HasConversion<int>();

            builder.Property(x => x.ApprovalStatus)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(x => x.DocumentStatus)
                .IsRequired()
                .HasConversion<int>();

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

            builder.HasOne(x => x.Branch)
                .WithMany()
                .HasForeignKey(x => x.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Warehouse)
                .WithMany()
                .HasForeignKey(x => x.WarehouseId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Series)
                .WithMany()
                .HasForeignKey(x => x.SeriesId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // ================= Collections =================

            builder.HasMany(x => x.GoodsIssueLines)
                .WithOne(x => x.GoodsIssue)
                .HasForeignKey(x => x.GoodsIssueId)
                .OnDelete(DeleteBehavior.Cascade);

            // ================= Index =================

            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.GoodsIssueNo })
                .IsUnique();
        }
    }
}