using Inspection.Domain.Models.HRManagement.InterviewEvaluations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.HRManagement.InterviewEvaluations
{
    public class InterviewEvaluationsConfig : IEntityTypeConfiguration<InterviewEvaluation>
    {
        public void Configure(EntityTypeBuilder<InterviewEvaluation> builder)
        {
            builder.ToTable("InterviewEvaluation", "HR");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TechnicalEvaluation).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.BehavioralEvaluation).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.Notes).HasMaxLength(2000);
            builder.Property(x => x.InterviewerName).IsRequired().HasMaxLength(250);
            builder.Property(x => x.InterviewDate).IsRequired();
            builder.Property(x => x.Result).IsRequired();
            builder.Property(x => x.Tenant_ID).HasMaxLength(100);
        }
    }
}