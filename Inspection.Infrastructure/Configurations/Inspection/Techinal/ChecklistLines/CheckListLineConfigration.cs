using Inspection.Domain.Models.Inspection.Techinal.ChecklistLines;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inspection.Techinal.ChecklistLines
{
    public class ChecklistLineConfiguration : IEntityTypeConfiguration<ChecklistLine>
    {
        public void Configure(EntityTypeBuilder<ChecklistLine> builder)
        {
            builder.ToTable("ChecklistLine", "Inspection");

            builder.HasKey(cl => cl.Id);

            builder.Property(cl => cl.MeasuredValue)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(cl => cl.Status)
                   .IsRequired();

            builder.Property(cl => cl.Remarks)
                   .HasMaxLength(500)
                   .IsRequired(false);

            builder.Property(cl => cl.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(cl => cl.In_Date)
                   .IsRequired();

            builder.Property(cl => cl.Mod_User)
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(cl => cl.Mod_Date)
                   .IsRequired(false);

            // Relationships

            // Checklist
            builder.HasOne(cl => cl.Checklist)
                   .WithMany(c => c.ChecklistLines)
                   .HasForeignKey(cl => cl.ChecklistId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cl => cl.ChecklistTemplateLine)
                   .WithMany()
                   .HasForeignKey(cl => cl.ChecklistTemplateLineId)
                   .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
