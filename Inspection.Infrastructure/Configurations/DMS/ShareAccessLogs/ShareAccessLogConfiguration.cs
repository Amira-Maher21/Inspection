using Inspection.Domain.Models.DMS.ShareAccessLogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.DMS.ShareAccessLogs
{
    public class ShareAccessLogConfiguration
        : IEntityTypeConfiguration<ShareAccessLog>
    {
        public void Configure(EntityTypeBuilder<ShareAccessLog> builder)
        {
            builder.ToTable("ShareAccessLog", "DMS");


            builder.HasKey(x => x.Id);




            builder.Property(x => x.AccessedAt);


            builder.Property(x => x.AccessIp)
                   .HasColumnType("nvarchar(45)");

            builder.Property(x => x.UserAgent)
                   .HasColumnType("nvarchar(max)");

            builder.Property(x => x.Action)
                  .HasConversion<int>()
                  .IsRequired(false);

            builder.Property(x => x.DocumentShareId)
                   .IsRequired();


            builder.HasOne(x => x.DocumentShare)
                   .WithMany()
                   .HasForeignKey(x => x.DocumentShareId)
                   .OnDelete(DeleteBehavior.Cascade);

            // REQUIRED FIELDS
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CompanyId).IsRequired();
            // AUDIT
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);
        }
    }
}