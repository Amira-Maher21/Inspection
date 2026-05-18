using Inspection.Domain.Models.Accounting.AccountingSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.AccountingSystem
{
    public class DefaultAccountGroupConfiguration : IEntityTypeConfiguration<DefaultAccountGroup>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<DefaultAccountGroup> builder)
        {

            builder.ToTable("DefaultAccountGroup", "Accounting");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.GroupCode)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.GroupName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.EntityType)
 .IsRequired()
 .HasConversion<int>();

            builder.Property(x => x.Tenant_ID)
                   .IsRequired()
                   .HasMaxLength(100);

            // Audit Fields (Mandatory)
            // Audit

            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);

            builder.Property(x => x.In_Date).IsRequired();

            builder.Property(x => x.Mod_User).HasMaxLength(100);

            builder.Property(x => x.Mod_Date);

            builder.HasIndex(x => new { x.Tenant_ID, x.GroupCode })
                   .IsUnique();

        }
    }
}