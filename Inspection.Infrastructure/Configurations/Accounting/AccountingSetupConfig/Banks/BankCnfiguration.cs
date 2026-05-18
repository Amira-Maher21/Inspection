using Inspection.Domain.Models.Accounting.AccountingSetup.Banks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.AccountingSetupConfig.Banks
{

    public class BankCnfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.ToTable("Bank", "Accounting");


            //Property
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Code)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(200);
            builder.Property(x => x.SwiftCode)
                   .IsRequired()
                   .HasMaxLength(20);

            //IsUnique
            builder.HasIndex(x => new { x.Tenant_ID, x.Code }).IsUnique();

            builder.Property(x => x.Tenant_ID)
                      .IsRequired()
                      .HasMaxLength(100);
            builder.Property(x => x.In_User)
                       .IsRequired()
                       .HasMaxLength(100);

            builder.Property(x => x.Mod_User)
                      .HasMaxLength(100);
            builder.Property(x => x.Mod_Date);
        }
    }
}