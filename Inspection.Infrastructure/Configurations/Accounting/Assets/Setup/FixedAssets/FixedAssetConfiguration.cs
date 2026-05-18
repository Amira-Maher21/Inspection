using Inspection.Domain.Models.Accounting.Assets.Setup.FixedAssets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Inspection.Infrastructure.Configurations.Accounting.Assets.Setup.FixedAssets
{
    public class FixedAssetConfiguration : IEntityTypeConfiguration<FixedAsset>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<FixedAsset> builder)
        {
            builder.ToTable("FixedAsset", "Accounting");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Series)
                               .WithMany()
                               .HasForeignKey(x => x.SeriesId)
                               .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.Tenant_ID, x.Code }).IsUnique()
                   .HasDatabaseName("UQ_FixedAsset_AssetCode");

            builder.Property(x => x.Tenant_ID).IsRequired();
            builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.AssetCategoryId).IsRequired();
            builder.Property(x => x.AcquisitionDate).IsRequired().HasColumnType("date");
            builder.Property(x => x.CapitalizationDate).HasColumnType("date");
            builder.Property(x => x.AcquisitionCost).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.ResidualValue).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.UsefulLifeMonths).IsRequired();
            builder.Property(x => x.DepreciationMethod).IsRequired().HasMaxLength(50);

            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);

            builder.HasOne(x => x.AssetCategory)
                   .WithMany()
                   .HasForeignKey(x => x.AssetCategoryId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_FixedAsset_AssetCategory");

            // Acquisition cost must be >= residual value
            builder.HasCheckConstraint(
                "CK_FixedAsset_Cost_Greater_Than_Residual",
                "[AcquisitionCost] >= [ResidualValue]");

            // Useful life must be positive
            builder.HasCheckConstraint(
                "CK_FixedAsset_UsefulLife_Positive",
                "[UsefulLifeMonths] > 0");

            // Capitalization date cannot be before acquisition date
            builder.HasCheckConstraint(
                "CK_FixedAsset_CapitalizationDate_Valid",
                "[CapitalizationDate] IS NULL OR [CapitalizationDate] >= [AcquisitionDate]");
        }
    }
}