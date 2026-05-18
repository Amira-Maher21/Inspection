using Inspection.Domain.Models.Inspection.Techinal.ChecklistTemplates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inspection.Techinal.Checklists.ChecklistTemplateLines
{
    public class ChecklistTemplateLineConfigration
        : IEntityTypeConfiguration<ChecklistTemplateLine>
    {
        public void Configure(EntityTypeBuilder<ChecklistTemplateLine> builder)
        {
            builder.ToTable("ChecklistTemplateLine", "Inspection");

            // =========================
            // Primary Key
            // =========================
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();


            builder.Property(x => x.ChecklistTemplateId)
                   .IsRequired();

            builder.HasOne(x => x.ChecklistTemplate)
                   .WithMany()
                   .HasForeignKey(x => x.ChecklistTemplateId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.DisplayOrder)
                   .IsRequired();

            builder.HasCheckConstraint(
                "CK_ChecklistTemplateLine_DisplayOrder",
                "[DisplayOrder] > 0"
            );

            builder.HasIndex(x => new { x.ChecklistTemplateId, x.DisplayOrder })
                   .IsUnique()
                   .HasDatabaseName("UX_ChecklistTemplateLine_Template_DisplayOrder");

            builder.Property(x => x.SectionName)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(x => x.ItemText)
                   .IsRequired()
                   .HasMaxLength(500);


            builder.Property(x => x.Tenant_ID)
                   .IsRequired()
                   .HasMaxLength(50);


            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                   .IsRequired();

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(x => x.Mod_Date)
                   .IsRequired(false);
        }
    }
}
