using Inspection.Domain.Models.InspectionManagement.InspectionReports;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.InspectionManagement.InspectionReports
{
    public class InspectionReportConfig : IEntityTypeConfiguration<InspectionReport>
    {
        public void Configure(EntityTypeBuilder<InspectionReport> builder)
        {
            builder.ToTable("InspectionReport", "Inspection");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Summary).IsRequired().HasMaxLength(1000);

            //builder.HasOne(x => x.InspectionOrder)
            //       .WithOne() 
            //       .HasForeignKey<InspectionReport>(x => x.InspectionOrderId)
            //       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}