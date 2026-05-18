using Inspection.Domain.Models.Accounting.PR.MasterData.Suppliers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.PR.MasterData.Suppliers
{
    public class SupplierGroupConfiguration : IEntityTypeConfiguration<SupplierGroup>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<SupplierGroup> builder)
        {
            builder.ToTable("SupplierGroup", "Accounting");

            builder.HasKey(x => x.Id);

            // Tenant
            builder.Property(x => x.Tenant_ID)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Code)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);


            builder.Property(x => x.Notes)
                   .IsRequired(false);


            builder.HasOne(x => x.DefaultAccountGroup)
                   .WithMany()
                   .HasForeignKey(x => x.DefaultAccountGroupId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.PaymentTerm)
                   .WithMany()
                   .HasForeignKey(x => x.PaymentTermsId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.TaxCategory)
                   .WithMany()
                   .HasForeignKey(x => x.TaxCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Audit
            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                   .IsRequired();

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100);

            builder.Property(x => x.Mod_Date);

            builder.HasIndex(x => new { x.Tenant_ID, x.Code })
                   .IsUnique();

        }
    }
}
