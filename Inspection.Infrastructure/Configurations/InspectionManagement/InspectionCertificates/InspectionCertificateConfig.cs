using Inspection.Domain.Models.InspectionManagement.InspectionCertificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.InspectionManagement.InspectionCertificates
{
    public class InspectionCertificateConfig : IEntityTypeConfiguration<InspectionCertificate>
    {
        public void Configure(EntityTypeBuilder<InspectionCertificate> builder)
        {
            builder.ToTable("InspectionCertificate", "Inspection");
            builder.HasKey(x => x.Id);

            builder.HasIndex(e => new { e.CertificateNumber, e.Tenant_ID })
                   .HasDatabaseName("UX_InspectionCertificate_CertificateNumber_Tenant")
                   .IsUnique();

            //builder.HasOne(x => x.InspectionOrder)
            //       .WithMany()
            //       .HasForeignKey(x => x.InspectionOrderId)
            //       .OnDelete(DeleteBehavior.Restrict);
        }
    }
}