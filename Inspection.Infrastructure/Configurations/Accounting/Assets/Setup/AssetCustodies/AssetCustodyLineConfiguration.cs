using Inspection.Domain.Enums.Accounting.Assets.Setup.AssetCustody;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetCustodies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Assets.Setup.AssetCustodies
{
    public class AssetCustodyLineConfiguration : IEntityTypeConfiguration<AssetCustodyLine>
    {
        [Obsolete]

        public void Configure(EntityTypeBuilder<AssetCustodyLine> builder)
        {
            builder.ToTable("AssetCustodyLine", "Accounting");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Indexes
            builder.HasIndex(x => x.AssetCustodyId);

            // Properties

            builder.Property(x => x.CustodyType).IsRequired().HasDefaultValue(AssetCustodyLineCustodyType.Issue);
            builder.Property(x => x.CustodyStartDate).IsRequired();
            builder.Property(x => x.IsAcknowledged).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.Notes).HasMaxLength(500);
            builder.Property(x => x.HandoverDocumentUrl).HasMaxLength(500);
            builder.Property(x => x.DocumentStatus).IsRequired().HasDefaultValue(AssetCustodyLineDocumentStatus.Draft);
            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Required FKs
            builder.Property(x => x.AssetCustodyId).IsRequired().HasMaxLength(50);
            builder.Property(x => x.FixedAssetId).IsRequired();

            // Relationships

            // Parent CashTransfer
            builder.HasOne(x => x.AssetCustody)
                   .WithMany()
                   .HasForeignKey(x => x.AssetCustodyId);


            // Chart Of Account
            builder.HasOne(x => x.FromOperation)
                   .WithMany()
                   .HasForeignKey(x => x.FromEmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.ToEmployee)
                   .WithMany()
                   .HasForeignKey(x => x.ToEmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.FixedAsset)
                   .WithMany()
                   .HasForeignKey(x => x.FixedAssetId)
                   .OnDelete(DeleteBehavior.Restrict);




            builder.HasOne(x => x.FromOperation)
                   .WithMany()
                   .HasForeignKey(x => x.FromOperationId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.ToOperation)
                   .WithMany()
                   .HasForeignKey(x => x.ToOperationId)
                   .OnDelete(DeleteBehavior.Restrict);



            builder.HasOne(x => x.FromCostCenter)
                   .WithMany()
                   .HasForeignKey(x => x.FromCostCenterId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.ToCostCenter)
                   .WithMany()
                   .HasForeignKey(x => x.ToCostCenterId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.FromCostCode)
                   .WithMany()
                   .HasForeignKey(x => x.FromCostCenterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ToCostCode)
                   .WithMany()
                   .HasForeignKey(x => x.ToCostCodeId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}