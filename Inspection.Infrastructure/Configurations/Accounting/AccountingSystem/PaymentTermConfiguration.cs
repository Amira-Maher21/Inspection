using Inspection.Domain.Models.Accounting.AccountingSystem.PaymentTerms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.AccountingSystem
{
    public class PaymentTermConfiguration : IEntityTypeConfiguration<PaymentTerm>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<PaymentTerm> builder)
        {
            builder.ToTable("PaymentTerm", "Accounting");

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

            builder.Property(x => x.DaysDue);

            builder.Property(x => x.DiscountPercentage).HasColumnType("decimal(18, 2)");


            builder.Property(x => x.Description)
                   .HasMaxLength(300);

            // Audit Fields
            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                   .IsRequired();

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100);

            builder.HasIndex(x => new { x.Tenant_ID, x.Code }).IsUnique();
        }
    }
}