using Inspection.Domain.Models.Accounting.Assets.Setup.AssetCategories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Assets.Setup.AssetCategories
{
    public class AssetCategoryConfiguration : IEntityTypeConfiguration<AssetCategory>
    {
        public void Configure(EntityTypeBuilder<AssetCategory> builder)
        {
            builder.ToTable("AssetCategory", "Accounting");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.CategoryCode })
                   .IsUnique();

            // Basic Fields
            builder.Property(x => x.Tenant_ID).IsRequired();

            builder.Property(x => x.CompanyId)
                   .IsRequired();

            builder.Property(x => x.CategoryCode)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.CategoryName)
                   .IsRequired()
                   .HasMaxLength(200);

            // Required Accounts
            builder.Property(x => x.AssetAccountId).IsRequired();
            builder.Property(x => x.AccumulatedDepreciationAccountId).IsRequired();
            builder.Property(x => x.DepreciationExpenseAccountId).IsRequired();

            // Optional Accounts
            builder.Property(x => x.AssetDisposalAccountId).IsRequired(false);
            builder.Property(x => x.GainOnDisposalAccountId).IsRequired(false);
            builder.Property(x => x.LossOnDisposalAccountId).IsRequired(false);
            builder.Property(x => x.RevaluationSurplusAccountId).IsRequired(false);
            builder.Property(x => x.ImpairmentLossAccountId).IsRequired(false);

            // Depreciation
            builder.Property(x => x.DefaultDepreciationMethod)
                   .IsRequired();

            builder.Property(x => x.DefaultUsefulLifeMonths)
                   .IsRequired();

            builder.Property(x => x.DefaultResidualValuePct)
                   .HasPrecision(18, 4);

            // Notes
            builder.Property(x => x.Notes)
                   .HasMaxLength(500);

            // Audit
            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                   .IsRequired();

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100);

            builder.Property(x => x.Mod_Date);

            // ================================
            // RELATIONSHIPS
            // ================================

            builder.HasOne(x => x.AssetAccount)
                   .WithMany()
                   .HasForeignKey(x => x.AssetAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.AccumulatedDepreciationAccount)
                   .WithMany()
                   .HasForeignKey(x => x.AccumulatedDepreciationAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.DepreciationExpenseAccount)
                   .WithMany()
                   .HasForeignKey(x => x.DepreciationExpenseAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.AssetDisposalAccount)
                   .WithMany()
                   .HasForeignKey(x => x.AssetDisposalAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.GainOnDisposalAccount)
                   .WithMany()
                   .HasForeignKey(x => x.GainOnDisposalAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.LossOnDisposalAccount)
                   .WithMany()
                   .HasForeignKey(x => x.LossOnDisposalAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.RevaluationSurplusAccount)
                   .WithMany()
                   .HasForeignKey(x => x.RevaluationSurplusAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ImpairmentLossAccount)
                   .WithMany()
                   .HasForeignKey(x => x.ImpairmentLossAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            // 🔹 Performance Indexes
            builder.HasIndex(x => x.AssetAccountId);
            builder.HasIndex(x => x.AccumulatedDepreciationAccountId);
            builder.HasIndex(x => x.DepreciationExpenseAccountId);
        }
    }
}