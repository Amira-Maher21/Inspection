using Inspection.Domain.Models.Contracting.Setup.Commitment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Contracting.Setup.Commitments
{

    public class CommitmentConfig : IEntityTypeConfiguration<Commitment>
    {
        public void Configure(EntityTypeBuilder<Commitment> builder)
        {
            builder.ToTable("Commitment", "Contracting");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Unique Index
            // (Tenant + Company + DocumentNo)
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.DocumentNo }).IsUnique();

            // Properties
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.DocumentNo).IsRequired().HasMaxLength(50);

            // Enums
            builder.Property(x => x.CommitmentType).IsRequired();

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Required Relationships
            builder.Property(x => x.OperationId).IsRequired();
            builder.Property(x => x.SupplierId).IsRequired();

            // CommitmentLine
            builder.HasMany(x => x.CommitmentLines)
                   .WithOne(x => x.Commitment)
                   .HasForeignKey(x => x.CommitmentId)
                   .OnDelete(DeleteBehavior.Cascade);


        }
    }
}