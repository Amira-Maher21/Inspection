using Inspection.Domain.Models.MenuManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.MenuManagement
{
    public class MenuConfig : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu", "Syst");
            builder.HasKey(e => e.Menu_ID);
            builder.Property(e => e.Menu_ID).HasMaxLength(20);
            builder.Property(e => e.Icon).HasMaxLength(200);
            builder.Property(e => e.Is_DashBoard).HasDefaultValue(false);
            builder.Property(e => e.Is_Report).HasDefaultValue(false);
            builder.Property(e => e.Menu_Name).HasMaxLength(200);
            builder.Property(e => e.Parent_ID).HasMaxLength(20);
            builder.Property(e => e.Program_ID).HasMaxLength(6);
            builder.Property(e => e.WebRoute).HasMaxLength(500);

            builder.HasOne(d => d.Program).WithMany(p => p.Menus)
               .HasForeignKey(d => d.Program_ID)
               .HasConstraintName("FK_Menu_Program");
        }
    }
}