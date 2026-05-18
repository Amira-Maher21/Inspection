using Inspection.Domain.Models.MenuManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.MenuManagement
{
    public class TenantCodeConfig : IEntityTypeConfiguration<Tenant_Code>
    {
        public void Configure(EntityTypeBuilder<Tenant_Code> builder)
        {
            builder.ToTable("Tenant_Code", "Syst");
            builder.HasKey(e => e.Tenant_ID).HasName("PK_Tenant_codes");
            builder.Property(e => e.Tenant_ID).HasMaxLength(10);
            builder.Property(e => e.LocaleCode).HasMaxLength(10);
            builder.Property(e => e.Tenant_Name).HasMaxLength(100);
        }
    }
}