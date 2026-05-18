using Inspection.Domain.Enums.DMS.DocumentEnums;
using Inspection.Domain.Models.DMS.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.DMS.Documents
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            // TABLE
            builder.ToTable("Document", "DMS");

            // PRIMARY KEY
            builder.HasKey(x => x.Id);

            // UNIQUE CONSTRAINT
            builder.HasIndex(x => x.DocumentNumber).IsUnique();
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.DocumentNumber }).IsUnique();

            // BASIC FIELDS
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.DocumentNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Description).HasColumnType("nvarchar(max)");

            // FILE INFORMATION
            builder.Property(x => x.OriginalFilename).IsRequired().HasMaxLength(500);
            builder.Property(x => x.FileExtension).IsRequired().HasMaxLength(20);
            builder.Property(x => x.MimeType).IsRequired().HasMaxLength(100);
            builder.Property(x => x.FileSize).IsRequired();
            builder.Property(x => x.FileHash).IsRequired().HasMaxLength(64);

            // duplicate detection index 🔥
            builder.HasIndex(x => x.FileHash);

            // STORAGE
            builder.Property(x => x.StorageType).HasConversion<int>().IsRequired().HasDefaultValue(StorageType.Local);
            builder.Property(x => x.URL).HasMaxLength(2000);
            builder.Property(x => x.StoragePath).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.StorageBucket).HasMaxLength(255);

            // FK_Document_Folder
            builder.HasOne(x => x.Folder)
                   .WithMany()
                   .HasForeignKey(x => x.FolderId)
                   .OnDelete(DeleteBehavior.Restrict);

            // VERSIONING
            builder.Property(x => x.VersionNumber).HasDefaultValue(1);
            builder.Property(x => x.IsLatestVersion).HasDefaultValue(true);

            // Self reference (version chain)
            builder.HasOne<Document>()
                   .WithMany()
                   .HasForeignKey(x => x.ParentDocumentId)
                   .OnDelete(DeleteBehavior.Restrict);

            // SEARCH CONTENT
            builder.Property(x => x.SearchableContent).HasColumnType("nvarchar(max)");

            // ANALYTICS
            builder.Property(x => x.ViewCount).HasDefaultValue(0);
            builder.Property(x => x.DownloadCount).HasDefaultValue(0);
            builder.Property(x => x.ShareCount).HasDefaultValue(0);

            // AUDIT
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);

            // MANY-TO-MANY (Document ↔ Tags)
            builder.HasMany(x => x.DocumentTags)
                   .WithOne(dt => dt.Document)
                   .HasForeignKey(dt => dt.DocumentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}