using Inspection.Domain.Models.MenuManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.MenuManagement
{
    public class ScreenPermissionConfig : IEntityTypeConfiguration<Screen_permission>
    {
        public void Configure(EntityTypeBuilder<Screen_permission> builder)
        {
            builder.ToTable("Screen_permission", "Sec");
            builder.HasKey(e => new { e.Tenant_ID, e.User_group_ID, e.Screen_ID }).HasName("PK_Screen_permissions");

            builder.Property(e => e.Tenant_ID).HasMaxLength(10);
            builder.Property(e => e.User_group_ID).HasMaxLength(10);
            builder.Property(e => e.Screen_ID).HasMaxLength(100);

            builder.HasOne(d => d.User_Group).WithMany(p => p.Screen_permissions)
                   .HasForeignKey(d => new { d.User_group_ID })
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Screen_permissions_User_groups");
        }
    }
}