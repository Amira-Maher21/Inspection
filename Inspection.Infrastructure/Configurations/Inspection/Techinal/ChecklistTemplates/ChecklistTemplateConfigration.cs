using Inspection.Domain.Models.Inspection.Techinal.ChecklistTemplates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Persistence.Configurations.Inspection
{
    public class ChecklistTemplateConfiguration : IEntityTypeConfiguration<ChecklistTemplate>
    {
        public void Configure(EntityTypeBuilder<ChecklistTemplate> builder)
        {
            builder.ToTable("ChecklistTemplate", "Inspection");

            builder.HasKey(ct => ct.Id);

            // Properties
            builder.Property(ct => ct.Name)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(ct => ct.Tenant_ID)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(ct => ct.ChecklistTemplateNumber)
                   .HasMaxLength(100);

            builder.Property(ct => ct.Disabled)
                   .HasDefaultValue(false);

            builder.Property(ct => ct.RunningNumber)
                   .HasDefaultValue(1);

            builder.Property(ct => ct.Version)
                   .HasDefaultValue(1);

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Relationships
            builder.HasOne(ct => ct.EquipmentType)
                   .WithMany()
                   .HasForeignKey(ct => ct.EquipmentTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ct => ct.InspectionStandard)
                   .WithMany()
                   .HasForeignKey(ct => ct.StandardId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ct => ct.Company)
                   .WithMany()
                   .HasForeignKey(ct => ct.CompanyId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ct => ct.Series)
                   .WithMany()
                   .HasForeignKey(ct => ct.SeriesId)
                   .OnDelete(DeleteBehavior.SetNull);


            // 1️⃣ Unique Index on EquipmentType + Standard + Version for Active Templates
            builder.HasIndex(ct => new { ct.EquipmentTypeId, ct.StandardId, ct.Version })
         .HasDatabaseName("UX_ChecklistTemplate_Active")
         .IsUnique()
         .HasFilter("[Disabled] = 0");




        }
    }
}
