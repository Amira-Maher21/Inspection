using Inspection.Domain.Models.Accounting.Assets.AssetTransactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Assets.AssetTransactions
{
    public class AssetTransactionConfiguration : IEntityTypeConfiguration<AssetTransaction>
    {
        public void Configure(EntityTypeBuilder<AssetTransaction> builder)
        {
            builder.ToTable("AssetTransaction", "Accounting");

            builder.HasKey(x => x.Id);

            //builder.HasIndex(x => x.AssetId);
            builder.HasIndex(x => x.TransactionDate);

            builder.Property(x => x.Tenant_ID)
                   .IsRequired();

            //builder.Property(x => x.AssetId)
            //       .IsRequired();

            builder.Property(x => x.TransactionType)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.TransactionDate)
                   .IsRequired();

            builder.Property(x => x.ReferenceId);
            builder.Property(x => x.ReferenceType).HasMaxLength(50);
            builder.Property(x => x.Notes).HasMaxLength(500);

            //// FK with FixedAsset
            //builder.HasOne(x => x.Asset)
            //       .WithMany(a => a.AssetTransactions)
            //       .HasForeignKey(x => x.AssetId)
            //       .OnDelete(DeleteBehavior.Restrict);


            builder.Property(x => x.TransactionType)
            .HasMaxLength(50)
            .IsRequired();



            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                   .IsRequired();

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100);

            builder.Property(x => x.Mod_Date);
        }
    }
}
