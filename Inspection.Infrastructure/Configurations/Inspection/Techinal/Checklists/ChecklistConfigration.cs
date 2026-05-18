using Inspection.Domain.Models.Inspection.Techinal.Checklists;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inspection.Techinal.Checklists
{
    public class ChecklistConfiguration : IEntityTypeConfiguration<Checklist>
    {
        public void Configure(EntityTypeBuilder<Checklist> builder)
        {
            builder.ToTable("Checklist", "Inspection");

            builder.HasKey(ct => ct.Id);

            builder.Property(ct => ct.Tenant_ID).IsRequired().HasMaxLength(50);
            builder.Property(ct => ct.ChecklistNumber).HasMaxLength(100);
            builder.Property(ct => ct.RunningNumber).HasDefaultValue(1);
            builder.Property(ct => ct.Location).HasMaxLength(250).IsRequired(false);
            builder.Property(ct => ct.Remarks).HasMaxLength(500);

            // Audit Fields
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.Mod_Date).IsRequired(false);

            builder.Property(ct => ct.JoborderId).IsRequired();
            builder.Property(ct => ct.CustomerId).IsRequired();

            // Relationships

            // Equipment
            builder.HasOne(ct => ct.Equipment)
                   .WithMany()
                   .HasForeignKey(ct => ct.EquipmentId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Inspector
            builder.HasOne(ct => ct.Inspector)
                   .WithMany()
                   .HasForeignKey(ct => ct.InspectorId)
                   .OnDelete(DeleteBehavior.Restrict);

            // ChecklistTemplate
            builder.HasOne(ct => ct.ChecklistTemplate)
                   .WithMany()
                   .HasForeignKey(ct => ct.ChecklistTemplateId)
                   .OnDelete(DeleteBehavior.Restrict);

            // InspectionStandard
            builder.HasOne(ct => ct.InspectionStandard)
                   .WithMany()
                   .HasForeignKey(ct => ct.StandardId)
                   .OnDelete(DeleteBehavior.Restrict);

            // InspectionType
            builder.HasOne(ct => ct.InspectionType)
                   .WithMany()
                   .HasForeignKey(ct => ct.InspectionTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(cl => cl.JobOrder)
                 .WithMany()
                 .HasForeignKey(cl => cl.JoborderId)
                 .OnDelete(DeleteBehavior.Restrict);

            // ChecklistLines
            builder.HasMany(ct => ct.ChecklistLines)
                   .WithOne(cl => cl.Checklist)
                   .HasForeignKey(cl => cl.ChecklistId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Customer 
            builder.HasOne(cl => cl.Customer)
                   .WithMany()
                   .HasForeignKey(cl => cl.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
