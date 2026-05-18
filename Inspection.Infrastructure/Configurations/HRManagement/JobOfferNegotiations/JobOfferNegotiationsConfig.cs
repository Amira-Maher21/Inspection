using Inspection.Domain.Models.HRManagement.JobOfferNegotiations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.HRManagement.JobOfferNegotiations
{
    public class JobOfferNegotiationsConfig : IEntityTypeConfiguration<JobOfferNegotiation>
    {
        public void Configure(EntityTypeBuilder<JobOfferNegotiation> builder)
        {
            builder.ToTable("JobOfferNegotiation", "HRManagement");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProposedSalary).IsRequired();
            builder.Property(x => x.ProposedStartDate).IsRequired();
            builder.Property(x => x.Notes).HasMaxLength(2000);
            builder.Property(x => x.Tenant_ID).HasMaxLength(100);
        }
    }
}