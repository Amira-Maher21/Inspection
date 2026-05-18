using Inspection.Domain.Models.DMS.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.DMS.Tags
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            // TABLE
            builder.ToTable("Tag", "DMS");

            // PRIMARY KEY
            builder.HasKey(x => x.Id);

            // INDEXES
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.Name }).IsUnique();

            // FIELDS
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Color).HasMaxLength(20).HasDefaultValue("#808080");


            // MANY-TO-MANY (Document ↔ Tags)
            builder.HasMany(x => x.DocumentTags)
                   .WithOne(dt => dt.Tag)
                   .HasForeignKey(dt => dt.TagId)
                   .OnDelete(DeleteBehavior.Cascade);

            // AUDIT
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);
        }
    }
}