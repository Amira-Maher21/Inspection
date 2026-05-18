using Inspection.Domain.Models.Contracting.Setup.SubcontractBOQs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Contracting.Setup.SubcontractBOQs
{
    public class SubcontractBOQConfiguration : IEntityTypeConfiguration<SubcontractBOQ>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<SubcontractBOQ> builder)
        {
            builder.ToTable("SubcontractBOQ", "Contracting");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Unique Index
            // (Tenant + Company + SubcontractBOQNumber)
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.SubcontractBOQNumber }).IsUnique();

            // Properties
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.OperationId).IsRequired();
            builder.Property(x => x.SubcontractBOQNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.RevisionNumber).IsRequired();
            builder.Property(x => x.DocumentStatus).IsRequired();

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Relationships

            // Operation
            builder.HasOne(x => x.Operation)
                   .WithMany()
                   .HasForeignKey(x => x.OperationId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Lines
            builder.HasMany(x => x.SubcontractBOQLines)
                   .WithOne(x => x.SubcontractBOQ)
                   .HasForeignKey(x => x.SubcontractBOQId)
                   .OnDelete(DeleteBehavior.Cascade);

            // CHECK CONSTRAINTS

            // DocumentStatus enum (adjust values based on your enum)
            builder.HasCheckConstraint(
                "CK_SubcontractBOQ_DocumentStatus",
                "[DocumentStatus] IN (1,2,3)"
            );
        }
    }
}