using Inspection.Domain.Models.Inspection.Techinal.AccreditationBodies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inspection.Techinal.AccreditationBodies
{
    public class AccreditationBodyConfiguration : IEntityTypeConfiguration<AccreditationBody>
    {
        public void Configure(EntityTypeBuilder<AccreditationBody> builder)
        {
            builder.ToTable("AccreditationBody", "Inspection");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Indexes
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.Code }).IsUnique();

            // Properties
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.WebsiteUrl).HasMaxLength(300).HasAnnotation("RegularExpression", @"^https?://.*"); ;
            builder.Property(x => x.IsInternationallyRecognized).IsRequired();

            builder.Property(x => x.CountryId).IsRequired();

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Relationships

            builder.HasMany(x => x.AccreditationBodyLines)
                   .WithOne(x => x.AccreditationBody)
                   .HasForeignKey(x => x.AccreditationBodyId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Checklist (Required)
            builder.HasOne(x => x.Country)
                   .WithMany()
                   .HasForeignKey(x => x.CountryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}