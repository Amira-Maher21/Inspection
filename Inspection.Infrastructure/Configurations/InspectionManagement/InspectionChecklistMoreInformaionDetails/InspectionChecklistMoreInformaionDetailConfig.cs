using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.InspectionManagement.InspectionChecklistMoreInformationDetails
{
    public class InspectionChecklistMoreInformationDetailConfig : IEntityTypeConfiguration<InspectionChecklistMoreInformationDetail>
    {
        public void Configure(EntityTypeBuilder<InspectionChecklistMoreInformationDetail> builder)
        {
            builder.ToTable("InspectionChecklistMoreInformationDetail", "Inspection");
            builder.HasKey(x => x.Id);
        }
    }
}