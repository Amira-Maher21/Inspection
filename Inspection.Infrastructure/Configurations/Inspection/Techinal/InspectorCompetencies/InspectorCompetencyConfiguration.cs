using Inspection.Domain.Models.Inspection.Techinal.InspectorCompetencies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inspection.Techinal.InspectorCompetencies
{

    public class InspectorCompetencyConfiguration : IEntityTypeConfiguration<InspectorCompetency>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<InspectorCompetency> builder)
        {
            builder.ToTable("InspectorCompetency", "Inspection");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Tenant & Company
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CompanyId).IsRequired();

            // Inspector FK
            builder.Property(x => x.InspectorId).IsRequired();

            builder.HasOne(x => x.Inspector)
                   .WithMany()
                   .HasForeignKey(x => x.InspectorId)
                   .OnDelete(DeleteBehavior.Restrict);
            // Lines
            builder.HasMany(x => x.InspectorCompetencyLines)
                   .WithOne(x => x.InspectorCompetency)
                   .HasForeignKey(x => x.InspectorCompetencyId)
                   .OnDelete(DeleteBehavior.Cascade);



            builder.HasMany(x => x.InspectorAccreditation)
               .WithOne(x => x.InspectorCompetency)
               .HasForeignKey(x => x.InspectorCompetencyId)
               .OnDelete(DeleteBehavior.Cascade);

            // Dates

            builder.Property(x => x.IssueDate).IsRequired().HasColumnType("date");
            builder.Property(x => x.ExpiryDate).HasColumnType("date");

            // Notes
            builder.Property(x => x.Notes).HasMaxLength(500);

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);

            // Optional Check Constraints

            builder.HasCheckConstraint(
                "CK_InspectorCompetency_ExpiryDate",
                "[ExpiryDate] IS NULL OR [ExpiryDate] >= [IssueDate]");
        }
    }
}