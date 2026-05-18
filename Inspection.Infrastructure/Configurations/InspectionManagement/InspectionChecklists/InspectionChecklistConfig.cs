using Inspection.Domain.Models.InspectionManagement.InspectionChecklists;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.InspectionManagement.InspectionChecklists
{


    public class InspectionChecklistConfig : IEntityTypeConfiguration<InspectionChecklist>
    {
        public void Configure(EntityTypeBuilder<InspectionChecklist> builder)
        {
            builder.ToTable("InspectionChecklist", "Inspection");
            builder.HasKey(x => x.Id);

            builder.HasMany(o => o.InspectionChecklistMoreInformations)
                   .WithOne(oi => oi.InspectionChecklists)
                   .HasForeignKey(oi => oi.InspectionChecklistId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Status);
            builder.HasIndex(e => new { e.ChecklistNumber, e.Tenant_ID })
                   .HasDatabaseName("UX_InspectionChecklist_ChecklistNumber_Tenant");
        }
    }
}