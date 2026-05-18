using Inspection.Domain.Models.Accounting.Assets.AssetAccountingEventAccounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Assets.AssetAccountingEventAccounts
{
    public class AssetAccountingEventAccountConfiguration : IEntityTypeConfiguration<AssetAccountingEventAccount>
    {
        public void Configure(EntityTypeBuilder<AssetAccountingEventAccount> builder)
        {
            builder.ToTable("AssetAccountingEventAccount", "Accounting");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.AssetAccountingEvent)
                   .WithMany()
                   .HasForeignKey(x => x.AssetAccountingEventId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.DebitAccountRole)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.CreditAccountRole)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.AmountSource)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Disabled)
                   .IsRequired();

            builder.Property(x => x.Tenant_ID)
                   .IsRequired()
                   .HasMaxLength(100);

            // Audit Columns
            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                   .IsRequired();

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100);

            builder.Property(x => x.Mod_Date);

            builder.HasIndex(x => new { x.Tenant_ID, x.AssetAccountingEventId, x.DebitAccountRole, x.CreditAccountRole })
                   .IsUnique();
        }
    }
}
