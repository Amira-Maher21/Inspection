using Inspection.Domain.Models.Inventory.Transaction.InventoryScraps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.Transaction.InventoryScraps
{
    public class InventoryScrapConfiguration : IEntityTypeConfiguration<InventoryScrap>
    {
        public void Configure(EntityTypeBuilder<InventoryScrap> builder)
        {
            builder.ToTable("InventoryScrap", "Inventory");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Notes)
                .HasMaxLength(500);


            // Required fields
            builder.Property(x => x.Tenant_ID)
           .IsRequired()
           .HasMaxLength(100);

            builder.Property(x => x.CompanyId)
                .IsRequired();


            builder.Property(x => x.InventoryScrapNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.InventoryScrapDate)
                   .IsRequired();

            // Relationships
            builder.HasOne(x => x.Branch)
                   .WithMany()
                   .HasForeignKey(x => x.BranchId)
                   .OnDelete(DeleteBehavior.Restrict);





            // Lines
            builder.HasMany(x => x.InventoryScrapLines)
                   .WithOne(x => x.InventoryScrap)
                   .HasForeignKey(x => x.InventoryScrapId)
                   .OnDelete(DeleteBehavior.Cascade);

            // ================= Enums =================

            builder.Property(x => x.Posting)
                .HasConversion<int>();

            builder.Property(x => x.ApprovalStatus)
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

            // ================= Index =================

            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.InventoryScrapNumber })
                .IsUnique();
        }
    }
}