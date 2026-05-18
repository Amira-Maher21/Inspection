using Inspection.Domain.Enums.Accounting.Assets.Setup.AssetCustody;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetCustodies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Assets.Setup.AssetCustodies
{
    public class AssetCustodyConfiguration : IEntityTypeConfiguration<AssetCustody>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<AssetCustody> builder)
        {
            builder.ToTable("AssetCustody", "Accounting");

            // Primary Key
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.DocumentNumber }).IsUnique();


            // Properties
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.DocumentNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.DocumentDate).IsRequired();
            builder.Property(x => x.Notes).HasMaxLength(500);

            builder.Property(x => x.DocumentStatus).IsRequired().HasDefaultValue(AssetCustodyDocumentStatus.Draft);
            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            builder.HasMany(x => x.AssetCustodyLines)
              .WithOne(x => x.AssetCustody)
              .HasForeignKey(x => x.AssetCustodyId)
              .OnDelete(DeleteBehavior.Cascade);

        }
    }
}