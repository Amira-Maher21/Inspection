using Inspection.Domain.Models.MenuManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.MenuManagement
{
    public class User_CodeConfig : IEntityTypeConfiguration<User_Code>
    {
        public void Configure(EntityTypeBuilder<User_Code> builder)
        {
            builder.ToTable("User_Code", "Sec");
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.Tenant_ID, x.User_ID }).IsUnique();

            builder.Property(e => e.Tenant_ID).HasMaxLength(10);
            builder.Property(e => e.User_ID).HasMaxLength(10);
            builder.Property(e => e.Email).HasMaxLength(100);
            builder.Property(e => e.Password).HasMaxLength(50);
            builder.Property(e => e.User_Name).HasMaxLength(75);

            builder.HasOne(d => d.Tenant).WithMany(p => p.User_Codes)
                   .HasForeignKey(d => d.Tenant_ID)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_User_Codes_Tenant_codes");
        }
    }
}