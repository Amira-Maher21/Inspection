using Inspection.Domain.Models.DMS.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.DMS.Documents
{
    public class DocumentTagConfiguration : IEntityTypeConfiguration<DocumentTag>
    {
        public void Configure(EntityTypeBuilder<DocumentTag> builder)
        {
            builder.ToTable("DocumentTag", "DMS");

            // ✅ Composite PK
            builder.HasKey(x => new { x.DocumentId, x.TagId });

            builder.HasOne(x => x.Document)
                   .WithMany(d => d.DocumentTags)
                   .HasForeignKey(x => x.DocumentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Tag)
                   .WithMany(t => t.DocumentTags)
                   .HasForeignKey(x => x.TagId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Prevent duplicates
            builder.HasIndex(x => new { x.DocumentId, x.TagId }).IsUnique();
        }
    }
}