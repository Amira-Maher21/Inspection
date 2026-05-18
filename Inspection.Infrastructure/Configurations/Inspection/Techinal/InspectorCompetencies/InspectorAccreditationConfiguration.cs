using Inspection.Domain.Models.Inspection.Techinal.InspectorCompetencies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inspection.Techinal.InspectorCompetencies
{
    public class InspectorAccreditationConfiguration : IEntityTypeConfiguration<InspectorAccreditation>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<InspectorAccreditation> builder)
        {
            builder.ToTable("InspectorAccreditation", "Inspection");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Foreign Keys
            builder.Property(x => x.InspectorCompetencyId).IsRequired();
            builder.Property(x => x.AccreditationBodyId).IsRequired();

            builder.HasOne(x => x.InspectorCompetency)
                   .WithMany()
                   .HasForeignKey(x => x.InspectorCompetencyId);

            builder.HasOne(x => x.AccreditationBody)
                   .WithMany()
                   .HasForeignKey(x => x.AccreditationBodyId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Certificate Info
            builder.Property(x => x.CertificateNumber)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.IssueDate)
                   .IsRequired();

            builder.Property(x => x.ExpiryDate)
                   .IsRequired();

            builder.Property(x => x.Notes)
                   .HasMaxLength(1000);

            //// Check Constraint
            //builder.HasCheckConstraint(
            //    "CK_InspectorAccreditation_ExpiryDate",
            //    "[ExpiryDate] >= [IssueDate]");
        }
    }
}
