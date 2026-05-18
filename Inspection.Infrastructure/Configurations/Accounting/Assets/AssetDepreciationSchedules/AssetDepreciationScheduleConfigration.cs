using Inspection.Domain.Models.Accounting.Assets;
using Inspection.Domain.Models.Accounting.Assets.FixedAssets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Assets.AssetDepreciationSchedules
{
    public class AssetDepreciationScheduleConfigration : IEntityTypeConfiguration<AssetDepreciationSchedule>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<AssetDepreciationSchedule> builder)
        {
            builder.ToTable("AssetDepreciationSchedule", "Accounting");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tenant_ID)
                   .IsRequired();

            //builder.Property(x => x.AssetId)
            //       .IsRequired();

            builder.Property(x => x.PeriodYear)
                   .IsRequired();

            builder.Property(x => x.PeriodMonth)
                   .IsRequired();

            builder.Property(x => x.DepreciationAmount)
                   .IsRequired();

            builder.Property(x => x.IsPosted)
                   .IsRequired()
                   .HasDefaultValue(false);

            builder.HasOne(x => x.FixedAsset)
                   .WithMany()
                   .HasForeignKey(x => x.AssetId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new { x.AssetId, x.Tenant_ID, x.PeriodYear, x.PeriodMonth })
               .IsUnique()
                 .HasDatabaseName("UQ_AssetDepreciationSchedule_Code_Tenant");

            builder.HasCheckConstraint(
                "CK_AssetDepreciation_PeriodMonth",
                "[PeriodMonth] >= 1 AND [PeriodMonth] <= 12"
            );

            builder.HasCheckConstraint(
                "CK_AssetDepreciation_DepreciationAmount",
                "[DepreciationAmount] >= 0"
            );

            builder.HasIndex(x => x.AssetId)
                   .HasDatabaseName("IX_AssetDepreciation_AssetId");

            builder.HasIndex(x => x.IsPosted)
                   .HasDatabaseName("IX_AssetDepreciation_IsPosted");


        }
    }
}