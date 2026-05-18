using Inspection.Domain.Models.MenuManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.MenuManagement
{
    internal class ScreenCodeConfig : IEntityTypeConfiguration<Screen_Code>
    {
        public void Configure(EntityTypeBuilder<Screen_Code> builder)
        {
            builder.ToTable("Screen_Code", "Syst");
            builder.HasKey(e => e.Screen_ID).HasName("PK_Screen_codes");

            builder.Property(e => e.Screen_ID).HasMaxLength(100);
            builder.Property(e => e.FieldNameCondition).HasMaxLength(150);
            builder.Property(e => e.Menu_ID).HasMaxLength(20);
            builder.Property(e => e.Program_ID).HasMaxLength(5);
            builder.Property(e => e.Screen_Name).HasMaxLength(100);
            builder.Property(e => e.TabelMasterName).HasMaxLength(220);

            builder.HasOne(sc => sc.Menu)
                   .WithOne(m => m.ScreenCode)
                   .HasForeignKey<Screen_Code>(sc => sc.Menu_ID)
                   .HasPrincipalKey<Menu>(m => m.Menu_ID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}