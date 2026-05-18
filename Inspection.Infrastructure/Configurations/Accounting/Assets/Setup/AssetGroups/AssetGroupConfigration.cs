using Inspection.Domain.Models.Accounting.Assets.Setup.AssetGroups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Assets.Setup.AssetGroups
{
    public class AssetGroupConfigration : IEntityTypeConfiguration<AssetGroup>
    {
        public void Configure(EntityTypeBuilder<AssetGroup> builder)
        {
            builder.ToTable("AssetGroup", "Accounting");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tenant_ID).IsRequired();
            builder.Property(x => x.CompanyId).IsRequired();

            builder.Property(x => x.GroupCode).IsRequired().HasMaxLength(50);
            builder.Property(x => x.GroupName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.IsLeaf).IsRequired().HasDefaultValue(false);

            builder.Property(x => x.Notes).HasMaxLength(500);

            // Unique Index
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.GroupCode, x.AssetCategoryId }).IsUnique();


            builder.HasOne(x => x.AssetCategory)
                   .WithMany()
                   .HasForeignKey(x => x.AssetCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);
        }
    }
}