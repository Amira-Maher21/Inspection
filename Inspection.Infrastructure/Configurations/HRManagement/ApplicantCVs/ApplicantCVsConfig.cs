using Inspection.Domain.Enums;
using Inspection.Domain.Models.HRManagement.ApplicantCVs;
using Inspection.Domain.Models.HRManagement.InterviewEvaluations;
using Inspection.Domain.Models.HRManagement.JobOfferNegotiations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.HRManagement.ApplicantCVs
{
    public class ApplicantCVsConfig : IEntityTypeConfiguration<ApplicantCV>
    {
        public void Configure(EntityTypeBuilder<ApplicantCV> builder)
        {
            builder.ToTable("ApplicantCV", "HR");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FullName).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CVUrl).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Qualifications).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Status).HasDefaultValue(CVStatus.Received);
            builder.Property(x => x.IsInterviewed).HasDefaultValue(false);
            builder.Property(x => x.AcceptedOffer).HasDefaultValue(null);
            builder.Property(x => x.WillJoin).HasDefaultValue(null);
            builder.Property(x => x.Tenant_ID).HasMaxLength(100);

            builder.HasOne(x => x.JobRequest)
                   .WithMany(x => x.CVs)
                   .HasForeignKey(x => x.JobRequestId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.InterviewEvaluation)
                   .WithOne(x => x.ApplicantCV)
                   .HasForeignKey<InterviewEvaluation>(x => x.ApplicantCVId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Negotiation)
                   .WithOne(x => x.ApplicantCV)
                   .HasForeignKey<JobOfferNegotiation>(x => x.ApplicantCVId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}