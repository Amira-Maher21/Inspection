using Inspection.Domain.Models.Accounting.Assets.AssetAccountingEvents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Assets.AssetAccountingEvents
{
    public class AssetAccountingEventConfiguration
        : IEntityTypeConfiguration<AssetAccountingEvent>
    {
        public void Configure(EntityTypeBuilder<AssetAccountingEvent> builder)
        {
            builder.ToTable("AssetAccountingEvent", "Accounting");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.Tenant_ID, x.Code })
                   .IsUnique()
                   .HasDatabaseName("UQ_AssetAccountingEvent_Tenant_Code");

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Tenant_ID)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Code)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.AssetEventType)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.SourceModule)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.IsReversible)
                   .IsRequired();

            builder.Property(x => x.Disabled)
                       .IsRequired().HasDefaultValue(false);

            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                   .IsRequired();

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100);

            builder.Property(x => x.Mod_Date);
        }
    }
}
