using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationTemplates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.InspectionManagement.InspectionChecklistMoreInformaionTemplates
{

    public class InspectionChecklistMoreInformaionTemplateConfig : IEntityTypeConfiguration<InspectionChecklistMoreInformationTemplate>
    {
        public void Configure(EntityTypeBuilder<InspectionChecklistMoreInformationTemplate> builder)
        {
            builder.ToTable("InspectionChecklistMoreInformationTemplate", "Inspection");
            builder.HasKey(x => x.Id);

            // DETAIL → SUB-DETAIL
            builder
                .HasMany(m => m.InspectionChecklistMoreInformationTemplateDetails)
                .WithOne(d => d.InspectionChecklistMoreInformationTemplates)
                .HasForeignKey(d => d.InspectionChecklistMoreInformationTemplateId)
                .OnDelete(DeleteBehavior.Cascade);

            // EquipmentType relation (NO CASCADE)
            builder
                .HasOne(m => m.EquipmentTypes)
                .WithMany()
                .HasForeignKey(m => m.EquipmentTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(e => new { e.EquipmentTypeId, e.Tenant_ID })
                   .HasDatabaseName("UX_EquipmentType_EquipmentTypeId_Tenant")
                   .IsUnique();
        }
    }
}