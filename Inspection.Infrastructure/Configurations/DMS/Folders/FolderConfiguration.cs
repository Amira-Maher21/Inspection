using Inspection.Domain.Enums.DMS.FolderEnums;
using Inspection.Domain.Models.DMS.Folders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.DMS.Folders
{
    public class FolderConfiguration : IEntityTypeConfiguration<Folder>
    {
        public void Configure(EntityTypeBuilder<Folder> builder)
        {
            // TABLE
            builder.ToTable("Folder", "DMS");

            // PRIMARY KEY
            builder.HasKey(x => x.Id);

            // INDEXES
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.Path }).IsUnique();

            // REQUIRED FIELDS
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Path).IsRequired().HasMaxLength(1000);

            // OPTIONAL FIELDS
            builder.Property(x => x.Description).HasColumnType("nvarchar(max)");
            builder.Property(x => x.ScreenId).HasMaxLength(100);
            builder.Property(x => x.Icon).HasMaxLength(50).HasDefaultValue("Folder");
            builder.Property(x => x.Color).HasMaxLength(20).HasDefaultValue("#FFA500");

            // ENUMS
            builder.Property(x => x.FolderType).IsRequired().HasDefaultValue(FolderType.Standard); // Standard
            builder.Property(x => x.PermissionType).IsRequired();

            // DEFAULT VALUES
            builder.Property(x => x.IsPublic).HasDefaultValue(false);
            builder.Property(x => x.InheritPermissions).HasDefaultValue(true);
            builder.Property(x => x.SortOrder).HasDefaultValue(0);

            // AUDIT
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // RELATIONSHIPS

            // Self reference (Parent Folder)
            builder.HasOne<Folder>()
                   .WithMany()
                   .HasForeignKey(x => x.ParentFolderId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Screen relationship
            builder.HasOne(x => x.Screen)
                   .WithMany()
                   .HasForeignKey(x => x.ScreenId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}