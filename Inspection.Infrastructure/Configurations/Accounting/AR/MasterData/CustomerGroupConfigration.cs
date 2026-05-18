using Inspection.Domain.Models.Accounting.AR.MasterData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.AR.MasterData
{
    public class CustomerGroupConfigration : IEntityTypeConfiguration<CustomerGroup>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<CustomerGroup> builder)
        {

            builder.ToTable("CustomerGroup", "Accounting");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.GroupCode)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.GroupName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.CreditLimit)
                   .HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.PaymentTerm)
                   .WithMany()
                   .HasForeignKey(x => x.PaymentTermsId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.TaxCategory)
                   .WithMany()
                   .HasForeignKey(x => x.TaxCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.DefaultAccountGroup)
               .WithMany()
               .HasForeignKey(x => x.DefaultAccountGroupId)
               .OnDelete(DeleteBehavior.Restrict);

            //talent ID
            builder.Property(x => x.Tenant_ID)
                   .IsRequired()
                   .HasMaxLength(100);

            // Audit Fields (Mandatory)

            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);

            builder.Property(x => x.In_Date).IsRequired();

            builder.Property(x => x.Mod_User).HasMaxLength(100);

            builder.Property(x => x.Mod_Date);

            builder.HasIndex(x => new { x.Tenant_ID, x.GroupCode, }).IsUnique();

        }
    }
}