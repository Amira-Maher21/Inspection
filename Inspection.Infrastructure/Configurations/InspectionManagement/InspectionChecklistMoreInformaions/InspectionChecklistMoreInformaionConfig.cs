using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Inspection.Infrastructure.Configurations.InspectionManagement.InspectionChecklistMoreInformations
{
    public class InspectionChecklistMoreInformationConfig : IEntityTypeConfiguration<InspectionChecklistMoreInformation>
    {
        public void Configure(EntityTypeBuilder<InspectionChecklistMoreInformation> builder)
        {
            builder.ToTable("InspectionChecklistMoreInformation", "Inspection");
            builder.HasKey(x => x.Id);

            // DETAIL → SUB-DETAIL
            builder
                .HasMany(m => m.InspectionChecklistMoreInformationDetails)
                .WithOne(d => d.InspectionChecklistMoreInformations)
                .HasForeignKey(d => d.InspectionChecklistMoreInformationId)
                .OnDelete(DeleteBehavior.Cascade);

            // EquipmentType relation (NO CASCADE)
            builder
                .HasOne(m => m.EquipmentTypes)
                .WithMany()
                .HasForeignKey(m => m.EquipmentTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}