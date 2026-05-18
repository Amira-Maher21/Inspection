using Inspection.Domain.Models.Accounting.Assets.Setup.AssetCategories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Assets.Setup.AssetComponents
{
    public class AssetComponentConfiguration : IEntityTypeConfiguration<AssetComponent>
    {
        public void Configure(EntityTypeBuilder<AssetComponent> builder)
        {
            // Table
            builder.ToTable("AssetComponent", "Accounting");

            // Primary Key
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.ComponentName }).IsUnique();

            // Properties
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.FixedAssetId).IsRequired();
            builder.Property(x => x.ComponentName).IsRequired().HasMaxLength(300);
            builder.Property(x => x.ComponentCost).IsRequired().HasPrecision(18, 6);
            builder.Property(x => x.UsefulLifeMonths).IsRequired();
            builder.Property(x => x.ResidualValue).HasPrecision(18, 6);
            builder.Property(x => x.DepreciationMethodId).IsRequired();
            builder.Property(x => x.Notes).HasMaxLength(500);


            // Fixed Asset
            builder.HasOne(x => x.FixedAsset)
                   .WithMany()
                   .HasForeignKey(x => x.FixedAssetId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);
        }
    }
}