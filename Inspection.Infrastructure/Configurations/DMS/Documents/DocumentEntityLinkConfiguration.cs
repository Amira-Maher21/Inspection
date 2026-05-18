using Inspection.Domain.Enums.DMS.DocumentEnums;
using Inspection.Domain.Models.DMS.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.DMS.Documents
{
    public class DocumentEntityLinkConfiguration : IEntityTypeConfiguration<DocumentEntityLink>
    {
        public void Configure(EntityTypeBuilder<DocumentEntityLink> builder)
        {
            // TABLE
            builder.ToTable("DocumentEntityLink", "DMS");

            // PRIMARY KEY
            builder.HasKey(x => x.Id);

            // RELATIONSHIP (FK)
            builder.HasOne(x => x.Document)
                   .WithMany()
                   .HasForeignKey(x => x.DocumentId);

            // FIELDS
            builder.Property(x => x.DocumentId).IsRequired();
            builder.Property(x => x.ScreenId).IsRequired().HasMaxLength(200);
            builder.Property(x => x.EntityId).IsRequired().HasMaxLength(100);
            builder.Property(x => x.EntityName).HasMaxLength(255);

            // ENUM CONFIGURATION
            builder.Property(x => x.LinkedEntityType)
                   .HasConversion<int>()
                   .IsRequired()
                   .HasDefaultValue(LinkedEntityType.Primary);

            // INDEXES (IMPORTANT 🔥)
            builder.HasIndex(x => x.DocumentId);
            builder.HasIndex(x => new { x.ScreenId, x.EntityId });
            builder.HasIndex(x => new { x.DocumentId, x.ScreenId, x.EntityId }).IsUnique();

            // AUDIT
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
        }
    }
}