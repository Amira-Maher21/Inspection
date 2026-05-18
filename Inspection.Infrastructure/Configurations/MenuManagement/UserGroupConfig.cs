using Inspection.Domain.Models.MenuManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.MenuManagement
{
    public class UserGroupConfig : IEntityTypeConfiguration<User_Group>
    {
        public void Configure(EntityTypeBuilder<User_Group> builder)
        {
            builder.ToTable("User_Group", "Sec");
            //builder.HasKey(e => new { e.Tenant_ID, e.User_group_ID }).HasName("PK_User_groups");
            builder.HasKey(x => x.User_group_ID);

            builder.Property(e => e.Tenant_ID).HasMaxLength(10);
            builder.Property(e => e.User_group_ID).HasMaxLength(10);
            builder.Property(e => e.User_group_Name).HasMaxLength(50);

            builder.HasOne(d => d.Tenant).WithMany(p => p.User_Groups)
                   .HasForeignKey(d => d.Tenant_ID)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_User_groups_Tenant_codes");
        }
    }
}