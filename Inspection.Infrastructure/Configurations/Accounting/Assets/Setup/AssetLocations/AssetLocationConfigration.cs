using Inspection.Domain.Models.Accounting.Assets.Setup.AssetLocations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Assets.Setup.AssetLocations
{
    public class AssetLocationConfigration : IEntityTypeConfiguration<AssetLocation>
    {
        public void Configure(EntityTypeBuilder<AssetLocation> builder)
        {
            builder.ToTable("AssetLocation", "Accounting");
            builder.HasKey(x => x.Id);

            // Unique constraint
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.LocationCode })
                   .IsUnique();

            // Basic Fields
            builder.Property(x => x.Tenant_ID)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.CompanyId)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.LocationCode)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.LocationName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.IsLeaf)
                   .IsRequired();

            // Self-referencing relationship 
            builder.HasOne(x => x.ParentLocation)
                   .WithMany(x => x.Children)
                   .HasForeignKey(x => x.ParentLocationId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Audit
            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                   .IsRequired();

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100);

            builder.Property(x => x.Mod_Date);

            // index for hierarchy queries
            builder.HasIndex(x => x.ParentLocationId);
        }
    }
}