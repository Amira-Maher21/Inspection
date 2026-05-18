using Inspection.Domain.Models.Inventory.Transaction.ScrapReasons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.Transaction.ScrapReasons
{
    public class ScrapReasonConfiguration : IEntityTypeConfiguration<ScrapReason>
    {
        public void Configure(EntityTypeBuilder<ScrapReason> builder)
        {
            builder.ToTable("ScrapReason", "Inventory");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tenant_ID)
             .IsRequired()
             .HasMaxLength(100);

            builder.Property(x => x.CompanyId)
                .IsRequired();

            builder.Property(x => x.Code)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(300);

            builder.HasOne(x => x.ChartOfAccount)
                   .WithMany()
                   .HasForeignKey(x => x.ChartOfAccountId)
                   .OnDelete(DeleteBehavior.Restrict);



            // ================= Audit =================

            builder.Property(x => x.In_User)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                .IsRequired();

            builder.Property(x => x.Mod_User)
                .HasMaxLength(100);

            builder.Property(x => x.Mod_Date);
            // ================= Index =================

            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId })
                .IsUnique();
        }
    }
}