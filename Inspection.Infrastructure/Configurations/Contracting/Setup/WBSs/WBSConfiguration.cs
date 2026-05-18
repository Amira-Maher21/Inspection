using Inspection.Domain.Models.Contracting.Setup.WBSs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Contracting.Setup.WBSs
{
    public class WBSConfiguration : IEntityTypeConfiguration<WBS>
    {
        public void Configure(EntityTypeBuilder<WBS> builder)
        {
            builder.ToTable("WBS", "Contracting");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tenant_ID).IsRequired();
            builder.Property(x => x.CompanyId).IsRequired();

            builder.Property(x => x.OperationId).IsRequired();

            builder.Property(x => x.WBSCode)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.WBSName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.LevelNo).IsRequired();

            builder.Property(x => x.IsLeaf)
                   .IsRequired()
                   .HasDefaultValue(false);


            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.OperationId, x.WBSCode })
                   .IsUnique();

            // Self Reference
            builder.HasOne<WBS>()
                   .WithMany()
                   .HasForeignKey(x => x.ParentWBSId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}