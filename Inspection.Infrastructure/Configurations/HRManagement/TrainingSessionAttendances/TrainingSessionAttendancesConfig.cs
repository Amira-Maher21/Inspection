using Inspection.Domain.Models.HRManagement.TrainingSessionAttendances;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.HRManagement.TrainingSessionAttendances
{

    public class TrainingSessionAttendancesConfig : IEntityTypeConfiguration<TrainingSessionAttendance>
    {
        public void Configure(EntityTypeBuilder<TrainingSessionAttendance> builder)
        {
            builder.ToTable("TrainingSessionAttendance", "HR");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Attended).IsRequired();
            builder.Property(x => x.SignedByEmployee).IsRequired();
            builder.Property(x => x.SignedBySupervisor).IsRequired();
            builder.Property(x => x.Result).IsRequired();
            builder.Property(x => x.Notes).HasMaxLength(2000);
            builder.Property(x => x.Tenant_ID).HasMaxLength(100);

            builder.HasOne(x => x.Employee)
                   .WithMany(x => x.Trainings)
                   .HasForeignKey(x => x.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.TrainingProgram)
                   .WithMany()
                   .HasForeignKey(x => x.TrainingProgramId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}