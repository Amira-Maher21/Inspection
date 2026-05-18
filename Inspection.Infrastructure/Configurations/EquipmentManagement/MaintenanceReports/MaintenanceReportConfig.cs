using Inspection.Domain.Models.EquipmentManagement.MaintenanceReports;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.EquipmentManagement.MaintenanceReports
{
    public class MaintenanceReportConfig : IEntityTypeConfiguration<MaintenanceReport>
    {
        public void Configure(EntityTypeBuilder<MaintenanceReport> builder)
        {
            builder.ToTable("MaintenanceReport", "Inspection");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MaintenanceDate).IsRequired();
            builder.Property(x => x.PerformedBy).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Summary).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.FileUrl).HasMaxLength(500);

            //builder.Property(x => x.Tenant_ID)
            //       .HasMaxLength(100);

            //builder.HasOne(x => x.Equipment)
            //       .WithMany()
            //       .HasForeignKey(x => x.EquipmentId)
            //       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}