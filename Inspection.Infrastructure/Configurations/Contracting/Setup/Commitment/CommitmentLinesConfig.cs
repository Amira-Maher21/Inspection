using Inspection.Domain.Models.Contracting.Setup.Commitment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Contracting.Setup.Commitments
{

    public class CommitmentLinesConfig : IEntityTypeConfiguration<CommitmentLine>
    {
        public void Configure(EntityTypeBuilder<CommitmentLine> builder)
        {
            builder.ToTable("CommitmentLine", "Contracting");
            // Primary Key
            builder.HasKey(x => x.Id);

            // Indexes
            builder.HasIndex(x => x.CommitmentId);

            // Properties
            builder.Property(x => x.CommittedQty).IsRequired().HasPrecision(18, 4);
            builder.Property(x => x.CommittedRate).IsRequired().HasPrecision(18, 4);
            builder.Property(x => x.CommittedAmount).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.InvoicedAmount).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.RemainingAmount).IsRequired().HasPrecision(18, 2);

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Required FKs
            builder.Property(x => x.CommitmentId).IsRequired();
            builder.Property(x => x.OperationId).IsRequired();
            builder.Property(x => x.WBSId).IsRequired();
            builder.Property(x => x.CostCodeId).IsRequired();

            // Relationships
            builder.HasOne(x => x.Operation)
                 .WithMany()
                 .HasForeignKey(x => x.OperationId)
                 .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.WBS)
       .WithMany()
       .HasForeignKey(x => x.WBSId)
       .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Activity)
                   .WithMany()
                   .HasForeignKey(x => x.ActivityId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.CostCode)
                   .WithMany()
                   .HasForeignKey(x => x.CostCodeId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.SubcontractBOQ)
                   .WithMany()
                   .HasForeignKey(x => x.SubcontractBOQId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ProductionOrder)
                   .WithMany()
                   .HasForeignKey(x => x.ProductionOrderId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.BOQLine)
                   .WithMany()
                   .HasForeignKey(x => x.BOQLineId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Parent Commitment
            builder.HasOne(x => x.Commitment)
                   .WithMany(x => x.CommitmentLines)
                   .HasForeignKey(x => x.CommitmentId);

            // CHECK CONSTRAINTS




        }
    }
}