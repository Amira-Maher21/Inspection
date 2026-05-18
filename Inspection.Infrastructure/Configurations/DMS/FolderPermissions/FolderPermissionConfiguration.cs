using Inspection.Domain.Models.DMS.FolderPermissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.DMS.FolderPermissions
{
    public class FolderPermissionConfiguration : IEntityTypeConfiguration<FolderPermission>
    {
        public void Configure(EntityTypeBuilder<FolderPermission> builder)
        {
            // TABLE
            builder.ToTable("FolderPermission", "DMS");

            // PRIMARY KEY
            builder.HasKey(x => x.Id);

            // INDEXES (recommended)
            // prevent duplicate permission per folder + group
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.FolderId/*, x.UserGroupId*/ })
                   .IsUnique()/*.HasFilter("[UserGroupId] IS NOT NULL")*/;

            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.FolderId })
                   .IsUnique()
                   /*.HasFilter("[UserGroupId] IS NULL")*/;

            // REQUIRED FIELDS
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(10);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.FolderId).IsRequired();

            // PERMISSION FLAGS (DEFAULT 0)
            builder.Property(x => x.CanView).HasDefaultValue(false);
            builder.Property(x => x.CanDownload).HasDefaultValue(false);
            builder.Property(x => x.CanUpload).HasDefaultValue(false);
            builder.Property(x => x.CanEdit).HasDefaultValue(false);
            builder.Property(x => x.CanDelete).HasDefaultValue(false);
            builder.Property(x => x.CanShare).HasDefaultValue(false);
            builder.Property(x => x.CanManage).HasDefaultValue(false);

            // VALIDITY DATES
            builder.Property(x => x.ValidFrom).IsRequired(false);
            builder.Property(x => x.ValidUntil).IsRequired(false);

            // AUDIT
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // RELATIONSHIPS

            // Folder (Required)
            builder.HasOne(x => x.Folder)
                   .WithMany()
                   .HasForeignKey(x => x.FolderId)
                   .OnDelete(DeleteBehavior.Restrict);

            // User Group (Optional)
            builder.HasOne(x => x.UserGroup)
                   .WithMany()
                   .HasForeignKey(d => new {/* d.Tenant_ID,*/ d.UserGroupId })
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}