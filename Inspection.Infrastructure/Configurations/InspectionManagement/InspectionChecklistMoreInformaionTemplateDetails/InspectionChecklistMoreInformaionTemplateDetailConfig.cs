using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.InspectionManagement.InspectionChecklistMoreInformaionTemplateDetails
{

    public class InspectionChecklistMoreInformaionTemplateDetailConfig : IEntityTypeConfiguration<InspectionChecklistMoreInformationTemplateDetail>
    {
        public void Configure(EntityTypeBuilder<InspectionChecklistMoreInformationTemplateDetail> builder)
        {
            builder.ToTable("InspectionChecklistMoreInformaionTemplateDetail", "Inspection");
            builder.HasKey(x => x.Id);

            builder.HasIndex(e => new { e.KeyName, e.Tenant_ID })
         .HasDatabaseName("UX_InspectionChecklistMoreInformaionTemplateDetail_KeyName_Tenant")
         .IsUnique();
        }
    }
}