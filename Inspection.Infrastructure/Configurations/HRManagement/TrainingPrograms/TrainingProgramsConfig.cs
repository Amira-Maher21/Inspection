using Inspection.Domain.Models.HRManagement.TrainingPrograms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.HRManagement.TrainingPrograms
{
    public class TrainingProgramsConfig : IEntityTypeConfiguration<TrainingProgram>
    {
        public void Configure(EntityTypeBuilder<TrainingProgram> builder)
        {
            builder.ToTable("TrainingProgram", "HR");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.Supervisor).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Tenant_ID).HasMaxLength(100);
        }
    }
}