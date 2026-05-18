using Inspection.Domain.Enums;
using Inspection.Domain.Models.EquipmentManagement.MaintenanceSchedules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.EquipmentManagement.MaintenanceSchedules
{
    public class MaintenanceScheduleConfig : IEntityTypeConfiguration<MaintenanceSchedule>
    {
        public void Configure(EntityTypeBuilder<MaintenanceSchedule> builder)
        {
            builder.ToTable("MaintenanceSchedule", "Inspection");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ScheduledDate).IsRequired();
            builder.Property(x => x.IsCompleted).IsRequired();
            builder.Property(x => x.Notes).HasMaxLength(1000);
            builder.Property(x => x.Tenant_ID).HasMaxLength(100);
            builder.Property(x => x.MaintenanceType).IsRequired()
                   .HasDefaultValue(MaintenanceType.Preventive);

            builder.Property(x => x.TechnicianId).IsRequired(false);

            //builder.HasOne(x => x.Equipment)
            //       .WithMany(e => e.Schedules)
            //       .HasForeignKey(x => x.EquipmentId)
            //       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}