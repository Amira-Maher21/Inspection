using Inspection.Domain.Models.MenuManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.MenuManagement
{
    public class MenuLocalizationConfig : IEntityTypeConfiguration<MenuLocalization>
    {
        public void Configure(EntityTypeBuilder<MenuLocalization> builder)
        {
            builder.ToTable("MenuLocalization", "Syst");

            builder.HasKey(e => new { e.Menu_ID, e.LocaleCode }).HasName("PK_MenuLocalization_1");

            builder.Property(e => e.Menu_ID).HasMaxLength(20);
            builder.Property(e => e.LocaleCode).HasMaxLength(10);
            builder.Property(e => e.Caption).HasMaxLength(500);
            builder.Property(e => e.Tooltip).HasMaxLength(500);

            builder.HasOne(d => d.Menu).WithMany(p => p.MenuLocalizations)
                   .HasForeignKey(d => d.Menu_ID)
                   .HasConstraintName("FK_MenuLocalization_Menu");
        }
    }
}