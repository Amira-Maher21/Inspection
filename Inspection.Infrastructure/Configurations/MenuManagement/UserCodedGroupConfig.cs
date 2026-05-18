using Inspection.Domain.Models.MenuManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.MenuManagement
{
    public class User_CodedGroupConfig : IEntityTypeConfiguration<User_Code_dGroup>
    {
        public void Configure(EntityTypeBuilder<User_Code_dGroup> builder)
        {
            builder.ToTable("User_Code_dGroup", "Sec");
            // builder.HasKey(e => new { e.Tenant_ID, e.User_CodeId, e.User_group_ID }); ;

            builder.HasKey(x => x.Id);
            builder.Property(e => e.Tenant_ID).HasMaxLength(10);

            builder.HasOne(d => d.User_Code).WithMany(p => p.User_Code_dGroups)
               .HasForeignKey(d => d.User_CodeId)
               .HasConstraintName("FK_User_Code_dGroup_User_Code");

            builder.HasOne(d => d.User_Group).WithMany(p => p.User_Code_dGroups)
                .HasForeignKey(d => new { d.User_group_ID })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Code_dGroup_User_Group");
        }
    }
}